using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 棋子统一管理器（GamePlay 核心系统）
///
/// 重构目标：把「按时间推进」的逻辑从每个棋子身上收回来，由这里唯一的一个 Update 统一驱动。
/// 原先每个棋子自己跑 3 条协程（攻击间隔、血条、包围检测），棋子一多就变成：
///   棋子数 x 每秒轮询次数 次全盘 BFS，帧率直接崩掉。
///
/// 现在集中在这里的四件事：
///   1. 攻击计时 —— 每帧只做一次时间比较，到点才结算，并用帧预算把同时到点的攻击摊到后续帧；
///   2. 血条刷新 —— 脏标记驱动，只有血量变化过的棋子才会刷新；
///   3. 包围/气判定 —— 只在棋盘发生变化（落子/移动/阵亡）后重算一次，取代每 0.05 秒的轮询；
///   4. 位置兜底 —— 低频 O(n) 检查，取代原来每帧 O(n^2) 的两两距离比较。
///
/// 同时维护棋盘网格索引，把原来 O(n) 的全量坐标扫描优化成 O(1) 的格子查询。
/// </summary>
public class ChessPieceMgr : SingletonAutoMono<ChessPieceMgr>
{
    #region 帧预算参数

    /// <summary>每帧最多结算的攻击次数，避免大量棋子同时到点时出现周期性掉帧</summary>
    private const int MaxAttacksPerFrame = 4;

    /// <summary>攻击间隔下限，防止配置为 0 时退化成每帧无限攻击</summary>
    private const float MinAttackInterval = 0.05f;

    /// <summary>位置兜底检查间隔（秒）</summary>
    private const float PositionCheckInterval = 0.5f;

    #endregion

    #region 注册表（对外只读，UI / 关卡管理器从这里取数据）

    private readonly List<ChessPiece> allPieces = new List<ChessPiece>(128);
    private readonly List<ChessPiece> playerPieces = new List<ChessPiece>(64);
    private readonly List<ChessPiece> enemyPieces = new List<ChessPiece>(64);
    private readonly List<ChessPiece> player1Pieces = new List<ChessPiece>(64);
    private readonly List<ChessPiece> player2Pieces = new List<ChessPiece>(64);

    public List<ChessPiece> AllPieces => allPieces;
    public List<ChessPiece> PlayerPieces => playerPieces;
    public List<ChessPiece> EnemyPieces => enemyPieces;
    public List<ChessPiece> Player1Pieces => player1Pieces;
    public List<ChessPiece> Player2Pieces => player2Pieces;

    #endregion

    #region 棋盘网格索引

    private static readonly int[] NeighborDx = { 0, 0, -1, 1 };
    private static readonly int[] NeighborDy = { 1, -1, 0, 0 };

    private ChessBoard board;
    private int boardWidth = 8;
    private int boardHeight = 8;
    private float cellSize = 1f;
    private Vector2 boardOffset;

    private ChessPiece[] grid;          // 格子 -> 棋子，O(1) 查询
    private bool boardDirty = true;     // 棋盘变化后需要重算"气 / 包围"

    // 连通块重算用的复用缓冲（用时间戳代替数组清零，零 GC）
    private int[] visitStamp;
    private int[] libertyStamp;
    private int[] groupBuffer;
    private int stamp;
    private int libertyMark;

    #endregion

    #region 运行时缓冲

    private readonly List<ChessPiece> dirtyHpBars = new List<ChessPiece>(32);   // 血条待刷新队列
    private readonly List<ChessPiece> attackBuffer = new List<ChessPiece>(32);  // 攻击目标扫描缓冲
    private int attackCursor;                                                    // 攻击计时的轮转起点
    private float nextPositionCheckTime;

    #endregion

    #region 棋盘绑定与查询

    /// <summary>
    /// 绑定棋盘（ChessBoard.Awake 时调用）。切换场景会重建索引并清空注册表。
    /// </summary>
    public void BindBoard(ChessBoard chessBoard)
    {
        board = chessBoard;
        if (board == null)
        {
            grid = null;
            return;
        }

        boardWidth = Mathf.Max(1, board.boardWidth);
        boardHeight = Mathf.Max(1, board.boardHeight);
        cellSize = board.cellSize <= 0f ? 1f : board.cellSize;
        boardOffset = board.boardOffset;

        int total = boardWidth * boardHeight;
        grid = new ChessPiece[total];
        visitStamp = new int[total];
        libertyStamp = new int[total];
        groupBuffer = new int[total];
        stamp = 0;
        libertyMark = 0;

        // 换场景时旧场景的棋子已经销毁，直接清空，避免残留引用
        allPieces.Clear();
        playerPieces.Clear();
        enemyPieces.Clear();
        player1Pieces.Clear();
        player2Pieces.Clear();
        dirtyHpBars.Clear();
        attackCursor = 0;

        boardDirty = true;
    }

    /// <summary>世界坐标 -> 格子索引（不在棋盘内返回 -1）</summary>
    public int WorldToIndex(Vector3 worldPos)
    {
        if (grid == null) return -1;

        int x = Mathf.RoundToInt((worldPos.x - boardOffset.x) / cellSize);
        int y = Mathf.RoundToInt((worldPos.y - boardOffset.y) / cellSize);
        if (x < 0 || x >= boardWidth || y < 0 || y >= boardHeight) return -1;

        return y * boardWidth + x;
    }

    /// <summary>格子索引 -> 世界坐标（格子中心）</summary>
    public Vector3 IndexToWorld(int index)
    {
        int x = index % boardWidth;
        int y = index / boardWidth;
        return new Vector3(boardOffset.x + x * cellSize, boardOffset.y + y * cellSize, 0f);
    }

    /// <summary>O(1) 获取指定位置所在格子上的棋子（替代原来的全量距离扫描）</summary>
    public ChessPiece GetPiece(Vector3 worldPos)
    {
        if (grid == null) return null;

        int index = WorldToIndex(worldPos);
        return index < 0 ? null : grid[index];
    }

    /// <summary>O(1) 获取指定格子上的棋子</summary>
    public ChessPiece GetPieceAtCell(int x, int y)
    {
        if (grid == null || x < 0 || x >= boardWidth || y < 0 || y >= boardHeight) return null;

        return grid[y * boardWidth + x];
    }

    /// <summary>该位置是否没有棋子</summary>
    public bool IsCellEmpty(Vector3 worldPos)
    {
        return GetPiece(worldPos) == null;
    }

    /// <summary>棋盘尺寸（格数）</summary>
    public int BoardWidth => boardWidth;

    /// <summary>棋盘尺寸（格数）</summary>
    public int BoardHeight => boardHeight;

    /// <summary>当前绑定的棋盘</summary>
    public ChessBoard Board => board;

    #endregion

    #region 注册 / 注销

    /// <summary>
    /// 注册棋子（棋子的 OnEnable 与 SetData 都会调用，可重复调用）。
    /// 阵营分组与棋盘索引都在这里统一维护，外部不需要再手动往列表里 Add。
    /// </summary>
    public void Register(ChessPiece piece)
    {
        if (piece == null) return;

        if (!piece.registered)
        {
            piece.registered = true;
            allPieces.Add(piece);
        }

        SyncFaction(piece);     // 阵营是在实例化之后才赋值的，这里重新分桶
        OccupyCell(piece);      // 保证网格索引指向最新位置
    }

    /// <summary>注销棋子（棋子的 OnDisable / 阵亡 / 被清除时调用，可重复调用）</summary>
    public void Unregister(ChessPiece piece)
    {
        if (piece == null) return;

        if (piece.registered)
        {
            piece.registered = false;
            allPieces.Remove(piece);
            playerPieces.Remove(piece);
            enemyPieces.Remove(piece);
            player1Pieces.Remove(piece);
            player2Pieces.Remove(piece);
        }

        ReleaseCell(piece);
    }

    /// <summary>按照棋子当前阵营重新分桶</summary>
    private void SyncFaction(ChessPiece piece)
    {
        List<ChessPiece> target = GetFactionList(piece.color);
        if (target.Contains(piece)) return;

        playerPieces.Remove(piece);
        enemyPieces.Remove(piece);
        player1Pieces.Remove(piece);
        player2Pieces.Remove(piece);
        target.Add(piece);
    }

    private List<ChessPiece> GetFactionList(ChessPiece.PieceFaction faction)
    {
        switch (faction)
        {
            case ChessPiece.PieceFaction.Enemy: return enemyPieces;
            case ChessPiece.PieceFaction.Player1: return player1Pieces;
            case ChessPiece.PieceFaction.Player2: return player2Pieces;
            default: return playerPieces;
        }
    }

    #endregion

    #region 生成棋子

    /// <summary>所有角色共用的棋子预制体（放在 Resources 下，不需要 AssetBundle）</summary>
    private const string PiecePrefabResPath = "Object/棋子";

    private static GameObject piecePrefab;

    /// <summary>
    /// 生成一个棋子：实例化唯一的那份棋子预制体，再按角色装配图片与动画。
    /// 位置由调用方决定（棋盘落子传对齐后的格子坐标）。
    /// </summary>
    public ChessPiece SpawnPiece(Vector3 position, T_Role role, ChessPiece.PieceFaction faction)
    {
        if (role == null)
        {
            Debug.LogError("生成棋子失败：角色数据为空");
            return null;
        }

        if (piecePrefab == null)
            piecePrefab = Resources.Load<GameObject>(PiecePrefabResPath);

        if (piecePrefab == null)
        {
            Debug.LogError($"找不到棋子预制体：Resources/{PiecePrefabResPath}.prefab");
            return null;
        }

        // 优先复用池子里的棋子（池子里的对象可能被外部销毁，取到空的就继续取）
        ChessPiece piece = null;
        while (piece == null && piecePool.Count > 0)
            piece = piecePool.Pop();

        if (piece != null)
        {
            piece.transform.SetParent(null);
            piece.transform.position = position;
            piece.gameObject.name = string.IsNullOrEmpty(role.f_icon) ? "棋子" : role.f_icon;
            piece.gameObject.SetActive(true);
        }
        else
        {
            GameObject obj = Instantiate(piecePrefab, position, Quaternion.identity);
            if (!string.IsNullOrEmpty(role.f_icon)) obj.name = role.f_icon;

            piece = obj.GetComponent<ChessPiece>();
            if (piece == null)
            {
                Debug.LogError($"棋子预制体上没有挂 ChessPiece 脚本：Resources/{PiecePrefabResPath}.prefab");
                return null;
            }
        }

        piece.color = faction;   // 先定阵营，SetData 里要靠它选玩家/敌人那套美术
        piece.SetData(role);     // 换图片换动画 + 初始化数值 + 注册进管理器

        return piece;
    }

    #endregion

    #region 棋盘索引维护

    private void OccupyCell(ChessPiece piece)
    {
        if (grid == null) return;

        int index = WorldToIndex(piece.transform.position);
        if (index < 0) return;
        if (piece.cellIndex == index && grid[index] == piece) return;   // 位置没有变化

        ReleaseCell(piece);

        // 格子已被别的棋子占用时先不入索引，交给位置兜底检查重新安置
        if (grid[index] == null)
        {
            grid[index] = piece;
            piece.cellIndex = index;
        }

        boardDirty = true;
    }

    private void ReleaseCell(ChessPiece piece)
    {
        int index = piece.cellIndex;
        if (grid != null && index >= 0 && index < grid.Length && grid[index] == piece)
            grid[index] = null;

        piece.cellIndex = -1;
    }

    /// <summary>棋子移动后由棋子通知管理器刷新索引</summary>
    public void NotifyMoved(ChessPiece piece)
    {
        OccupyCell(piece);
        boardDirty = true;
    }

    /// <summary>请求下一帧重算棋盘状态（兼容旧的 CheckIsSurround 接口）</summary>
    public void RequestBoardRefresh()
    {
        boardDirty = true;
    }

    #endregion

    #region 统一帧更新

    private void Update()
    {
        if (grid == null) return;   // 场景里还没有棋盘（例如主菜单）

        // 1. 统一推进所有棋子的帧序列动画（替代每个棋子一个 Animator）
        TickSpriteAnimation();

        // 2. 包围状态只在棋盘变化后重算一次
        if (boardDirty)
        {
            boardDirty = false;
            RecomputeSurrounded();
        }

        // 3. 统一推进所有棋子的攻击计时
        TickAttackTimers();

        // 4. 统一刷新血量变化过的棋子的血条
        FlushHpBars();

        // 5. 低频位置兜底
        TickPositionCheck();
    }

    /// <summary>
    /// 统一驱动帧序列动画：每个棋子每帧只做一次时间比较，帧号没变就不写 Sprite，
    /// 64 个棋子每帧总共也就几次赋值，比每个棋子挂一个 Animator 便宜得多。
    /// </summary>
    private void TickSpriteAnimation()
    {
        int count = allPieces.Count;
        if (count == 0) return;

        float now = Time.time;
        for (int i = 0; i < count; i++)
        {
            ChessPiece piece = allPieces[i];
            if (piece != null) piece.TickAnimation(now);
        }
    }

    /// <summary>
    /// 统一推进攻击计时：每个棋子每帧只做一次时间比较，到点才真正结算攻击。
    /// 帧预算把同时到点的攻击摊到后续帧，避免出现"集体开火"的周期性卡顿。
    /// </summary>
    private void TickAttackTimers()
    {
        int count = allPieces.Count;
        if (count == 0) return;

        // 轮转扫描起点，保证列表靠前的棋子不会一直抢走帧预算
        attackCursor++;
        if (attackCursor >= count) attackCursor = 0;

        float now = Time.time;
        int executed = 0;

        for (int i = 0; i < count; i++)
        {
            int index = attackCursor + i;
            if (index >= count) index -= count;

            // 攻击可能打死棋子、本帧内就从列表里移除了，这里要重新取一次长度
            if (index >= allPieces.Count) continue;

            ChessPiece piece = allPieces[index];
            if (piece == null || !piece.registered) continue;
            if (piece.nextAttackTime <= 0f || now < piece.nextAttackTime) continue;   // 未激活 / 未到点

            if (executed >= MaxAttacksPerFrame) break;   // 超出本帧预算，剩下的下一帧继续结算
            executed++;

            ScheduleNextAttack(piece);
            PerformAttack(piece);
        }
    }

    /// <summary>安排棋子的下一次攻击时间（攻击间隔的合法性也在这里收紧）</summary>
    public void ScheduleNextAttack(ChessPiece piece)
    {
        float interval = Mathf.Max(MinAttackInterval, piece.roleProperty.f_atkInterval);
        piece.nextAttackTime = Time.time + interval;
    }

    /// <summary>标记血条为脏（棋子扣血时调用），真正的刷新在帧更新里统一做</summary>
    public void MarkHpDirty(ChessPiece piece)
    {
        if (piece == null || piece.hpDirty) return;

        piece.hpDirty = true;
        dirtyHpBars.Add(piece);
    }

    private void FlushHpBars()
    {
        if (dirtyHpBars.Count == 0) return;

        for (int i = 0; i < dirtyHpBars.Count; i++)
        {
            ChessPiece piece = dirtyHpBars[i];
            if (piece == null) continue;

            piece.hpDirty = false;
            piece.RefreshHpBar();
        }

        dirtyHpBars.Clear();
    }

    /// <summary>
    /// 位置兜底检查（默认 0.5 秒一次）：
    /// 修正索引与坐标不一致的情况，并把落在同一格的棋子挪到空位。
    /// 原实现在 ChessBoard.Update 里每帧做 O(n^2) 两两距离比较，是帧率下降的主因之一。
    /// </summary>
    private void TickPositionCheck()
    {
        if (Time.time < nextPositionCheckTime) return;
        nextPositionCheckTime = Time.time + PositionCheckInterval;

        for (int i = allPieces.Count - 1; i >= 0; i--)
        {
            ChessPiece piece = allPieces[i];
            if (piece == null)
            {
                PruneDestroyedPieces();    // 被外部直接销毁的兜底清理
                return;
            }

            int index = WorldToIndex(piece.transform.position);
            if (index >= 0 && piece.cellIndex == index && grid[index] == piece) continue;   // 正常

            if (index < 0 || grid[index] != null)
            {
                // 坐标跑到棋盘外，或与别的棋子重叠：挪到最近的空位
                RelocateToFreeCell(piece);
            }
            else
            {
                // 只是索引没跟上（外部直接改过坐标）：重新入格
                grid[index] = piece;
                piece.cellIndex = index;
                boardDirty = true;
            }
        }
    }

    private void RelocateToFreeCell(ChessPiece piece)
    {
        ReleaseCell(piece);

        for (int i = 0; i < grid.Length; i++)
        {
            if (grid[i] != null) continue;

            piece.MoveTo(IndexToWorld(i));   // MoveTo 内部会重新入格
            return;
        }
    }

    /// <summary>清理被外部直接销毁的棋子（正常路径不会走到）</summary>
    private void PruneDestroyedPieces()
    {
        for (int i = allPieces.Count - 1; i >= 0; i--)
        {
            if (allPieces[i] == null) allPieces.RemoveAt(i);
        }

        playerPieces.RemoveAll(piece => piece == null);
        enemyPieces.RemoveAll(piece => piece == null);
        player1Pieces.RemoveAll(piece => piece == null);
        player2Pieces.RemoveAll(piece => piece == null);
        dirtyHpBars.RemoveAll(piece => piece == null);
    }

    #endregion

    #region 包围 / 气

    /// <summary>
    /// 重算全盘的"气"并刷新每个棋子的被围状态。
    /// 只在棋盘真正发生变化时执行一次（落子 / 移动 / 阵亡），而不是每个棋子各自轮询。
    /// 8x8 棋盘一次完整重算是常数级开销，且全程复用缓冲区、零 GC。
    /// </summary>
    private void RecomputeSurrounded()
    {
        if (grid == null) return;

        // 与原逻辑保持一致：某一方把整个棋盘占满时不再判定包围，
        // 否则满盘时所有棋子的气都是 0，会整盘显示 4 倍伤害标识
        int cellTotal = grid.Length;
        if (playerPieces.Count == cellTotal || enemyPieces.Count == cellTotal ||
            player1Pieces.Count == cellTotal || player2Pieces.Count == cellTotal)
        {
            for (int i = 0; i < allPieces.Count; i++)
            {
                ChessPiece piece = allPieces[i];
                if (piece != null) piece.ApplySurroundedState(false);
            }
            return;
        }

        stamp++;
        libertyMark++;

        for (int cell = 0; cell < grid.Length; cell++)
        {
            ChessPiece piece = grid[cell];
            if (piece == null || visitStamp[cell] == stamp) continue;

            // 1. 洪水填充同阵营连通块，同时统计整块的气
            int groupCount = 0;
            int liberties = 0;
            groupBuffer[groupCount++] = cell;
            visitStamp[cell] = stamp;

            for (int head = 0; head < groupCount; head++)
            {
                int current = groupBuffer[head];
                int cx = current % boardWidth;
                int cy = current / boardWidth;

                for (int d = 0; d < 4; d++)
                {
                    int nx = cx + NeighborDx[d];
                    int ny = cy + NeighborDy[d];
                    if (nx < 0 || nx >= boardWidth || ny < 0 || ny >= boardHeight) continue;   // 棋盘外按墙处理

                    int neighbor = ny * boardWidth + nx;
                    ChessPiece neighborPiece = grid[neighbor];

                    if (neighborPiece == null)
                    {
                        if (libertyStamp[neighbor] != libertyMark)   // 同一格气只算一次
                        {
                            libertyStamp[neighbor] = libertyMark;
                            liberties++;
                        }
                    }
                    else if (visitStamp[neighbor] != stamp && neighborPiece.color == piece.color)
                    {
                        visitStamp[neighbor] = stamp;
                        groupBuffer[groupCount++] = neighbor;
                    }
                }
            }

            // 2. 把结果写回整块棋子（气为 0 即被围：显示 4 倍伤害标识）
            bool surrounded = liberties == 0;
            for (int i = 0; i < groupCount; i++)
            {
                ChessPiece member = grid[groupBuffer[i]];
                if (member == null) continue;

                member.ApplySurroundedState(surrounded);
            }
        }
    }

    /// <summary>查询某个位置上的棋子是否被围（O(1)，读取已缓存的状态）</summary>
    public bool IsSurroundedAt(Vector3 worldPos)
    {
        ChessPiece piece = GetPiece(worldPos);
        return piece != null && piece.isSurrounded;
    }

    #endregion

    #region 攻击

    /// <summary>结算一次攻击（由帧更新统一驱动）</summary>
    private void PerformAttack(ChessPiece attacker)
    {
        if (attacker == null) return;
        // 敌方棋子全部阵亡时不用再算了
        if (attacker.color == ChessPiece.PieceFaction.Enemy && playerPieces.Count == 0) return;

        ChessPiece target = FindRandomTarget(attacker);
        if (target == null) return;

        // 命中概率与原逻辑保持一致
        float probability = (float)(0.3 + (attacker.roleProperty.f_atk - target.roleProperty.f_defense) * 0.007);
        if (Random.value >= probability) return;

        FireBullet(attacker, target);
        // 被围住的棋子承受 4 倍伤害
        target.ApplyDamage(target.isSurrounded ? 4 : 1);
    }

    /// <summary>
    /// 在攻击范围内的棋子里随机挑一个敌对目标。
    /// 用棋盘索引按菱形范围逐格取棋子，不再生成攻击点列表、也不再遍历全量棋子。
    /// </summary>
    private ChessPiece FindRandomTarget(ChessPiece attacker)
    {
        int range = attacker.roleProperty.f_block;
        if (range <= 0) return null;

        int cell = attacker.cellIndex;
        if (cell < 0) cell = WorldToIndex(attacker.transform.position);
        if (cell < 0) return null;

        int cx = cell % boardWidth;
        int cy = cell / boardWidth;

        attackBuffer.Clear();

        for (int y = cy - range; y <= cy + range; y++)
        {
            if (y < 0 || y >= boardHeight) continue;

            int dy = Mathf.Abs(y - cy);
            for (int x = cx - range; x <= cx + range; x++)
            {
                if (x < 0 || x >= boardWidth) continue;
                if (x == cx && y == cy) continue;
                if (Mathf.Abs(x - cx) + dy > range) continue;    // 菱形范围（曼哈顿距离）

                ChessPiece other = grid[y * boardWidth + x];
                if (other == null || other == attacker) continue;
                if (!AreEnemies(attacker.color, other.color)) continue;

                attackBuffer.Add(other);
            }
        }

        if (attackBuffer.Count == 0) return null;

        return attackBuffer[Random.Range(0, attackBuffer.Count)];
    }

    private static bool AreEnemies(ChessPiece.PieceFaction self, ChessPiece.PieceFaction other)
    {
        switch (self)
        {
            case ChessPiece.PieceFaction.Player: return other == ChessPiece.PieceFaction.Enemy;
            case ChessPiece.PieceFaction.Enemy: return other == ChessPiece.PieceFaction.Player;
            case ChessPiece.PieceFaction.Player1: return other == ChessPiece.PieceFaction.Player2;
            case ChessPiece.PieceFaction.Player2: return other == ChessPiece.PieceFaction.Player1;
            default: return false;
        }
    }

    private static void FireBullet(ChessPiece attacker, ChessPiece target)
    {
        // 法师（7/8/9）用各自的子弹，其余职业用普通子弹
        int profession = attacker.roleProperty.f_profession;
        bool isMageBullet = profession == 7 || profession == 8 || profession == 9;
        string bulletRes = profession switch
        {
            7 => "Object/火法师子弹",
            8 => "Object/水法师子弹",
            9 => "Object/光法师子弹",
            _ => "Object/Bullet",
        };

        GameObject bulletObj = PoolMgr.Instance.GetObj(bulletRes);
        if (bulletObj == null) return;

        Bullet bullet = bulletObj.GetComponent<Bullet>();
        if (bullet == null) return;

        Vector3 from = attacker.transform.position;
        Vector3 to = target.transform.position;

        bulletObj.transform.position = from;
        bullet.ChangeMoveDir(to - from);

        if (isMageBullet)
            bullet.ChangeFlipX(from.x - to.x);
        else
            bullet.ChangeSkillText(attacker.roleProperty.f_jnwz, attacker.roleProperty.f_jnwzys);

        bullet.SetTarget(target);
    }

    #endregion

    #region 阵亡 / 清除

    /// <summary>棋子对象池：避免频繁 Instantiate / Destroy 造成卡顿</summary>
    private readonly Stack<ChessPiece> piecePool = new Stack<ChessPiece>(32);
    private Transform poolRoot;

    /// <summary>
    /// 回收棋子：失活放进池子，下次生成直接复用。
    /// 对象池带来一个必须处理的点：棋子不再真的销毁，如果它正被棋盘选中，
    /// 必须把棋盘的选中引用清掉，否则棋盘会一直以为还有棋子被选中，导致落子点不出来。
    /// </summary>
    private void RecyclePiece(ChessPiece piece)
    {
        if (piece == null) return;

        ChessBoard board = ChessBoard.chessBoard;
        if (board != null && board.selectedPiece == piece)
        {
            board.selectedPiece = null;
            board.ClearValidMovePositions();
        }

        piece.ClearValidMovePositions();
        Unregister(piece);

        if (poolRoot == null)
        {
            GameObject root = new GameObject("棋子池");
            root.transform.SetParent(transform, false);
            poolRoot = root.transform;
        }

        piece.gameObject.SetActive(false);
        piece.transform.SetParent(poolRoot, false);
        piecePool.Push(piece);
    }

    /// <summary>
    /// 棋子阵亡：音效、成就计数、从容器与棋盘索引中移除，然后回收进对象池。
    /// 索引与列表会立刻注销，所以回收期间它不会再被当作攻击目标或可点击棋子。
    /// </summary>
    public void Kill(ChessPiece piece)
    {
        if (piece == null) return;

        MusicMgr.Instance.PlaySound("史莱姆死亡");
        if (piece.color == ChessPiece.PieceFaction.Enemy)
            GameAchieveMgr.Instance.enemyCount++;

        GameObjectMgr.Instance.isClickPiece = false;
        RecyclePiece(piece);
    }

    /// <summary>直接移除棋子（不走阵亡结算，例如看广告清除敌方棋子）</summary>
    public void Despawn(ChessPiece piece)
    {
        RecyclePiece(piece);
    }

    /// <summary>清除棋盘上的所有棋子（切换关卡 / 退出对局时调用），对象回收进池子留到下一关复用</summary>
    public void ClearAll()
    {
        for (int i = allPieces.Count - 1; i >= 0; i--)
        {
            RecyclePiece(allPieces[i]);
        }

        allPieces.Clear();
        playerPieces.Clear();
        enemyPieces.Clear();
        player1Pieces.Clear();
        player2Pieces.Clear();
        dirtyHpBars.Clear();
        attackCursor = 0;

        if (grid != null) System.Array.Clear(grid, 0, grid.Length);

        boardDirty = true;
    }

    #endregion
}

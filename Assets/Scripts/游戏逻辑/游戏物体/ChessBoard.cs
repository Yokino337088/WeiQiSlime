using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using static ChessPiece;
//using static UnityEditor.PlayerSettings;

public class ChessBoard : MonoBehaviour
{
    [Header("棋盘设置")]
    public float cellSize = 1.01f; // 每个格子的大小
    public Vector2 boardOffset = new Vector2(-4, -4); // 棋盘左下角的偏移量
    public int boardWidth = 8; // 棋盘的宽度（格子数）
    public int boardHeight = 8; // 棋盘的高度（格子数）

    public ChessPiece selectedPiece; // 当前选中的棋子

    public GameObject point;
    public static ChessBoard chessBoard;

    List<T_Role> nowLevelRole = new List<T_Role>();

    private Camera mainCamera;   // 缓存主相机，避免每次点击都做 Camera.main 查找

    private void Awake()
    {
        chessBoard = this;

        // 棋盘是子系统的数据源：绑定后由 ChessPieceMgr 统一维护网格索引与帧更新
        ChessPieceMgr.Instance.BindBoard(this);

        if (GameLevelMgr.Instance.nowLevelInfo != null)
        {
            if (GameLevelMgr.Instance.nowLevelInfo.f_level != 0 && SceneManager.GetActiveScene().buildIndex != 2)
            {
                foreach (var role in GameObjectMgr.Instance.AllRoleList)
                {
                    if (role.f_level == GameLevelMgr.Instance.nowLevelInfo.f_level)
                        nowLevelRole.Add(role);
                }
            }
        }

    }

    private void Start()
    {
        InputMgr.Instance.StartOrCloseInputMgr(true);
    }

    private void OnEnable()
    {
        // 订阅点击事件
        InputMgr.Instance.OnScreenTapped += OnScreenTapped;
    }

    private void OnDestroy()
    {
        // 取消订阅点击事件
        if (InputMgr.Instance != null)
        {
            InputMgr.Instance.OnScreenTapped -= OnScreenTapped;
        }
    }

    /// <summary>
    /// 点击屏幕时的回调
    /// </summary>
    private void OnScreenTapped(Vector2 screenPosition)
    {
        if (mainCamera == null) mainCamera = Camera.main;

        // 得到点击屏幕的世界坐标
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(screenPosition);
        // 2D游戏要确保z坐标等于0
        worldPosition.z = 0;

        // 直接用棋盘网格索引取该格子上的棋子（O(1)），不再走物理射线检测：
        // 省掉每次点击的物理查询，也不用担心物理状态不同步导致点不中棋子
        ChessPiece piece = ChessPieceMgr.Instance.GetPiece(worldPosition);
        if (piece != null)
        {
            HandlePieceClick(piece);
        }
        else //点的是空格子，走落子/移动逻辑
        {
            HandleBoardClick(worldPosition);
        }
    }

    /// <summary>
    /// 处理棋子点击
    /// </summary>
    private void HandlePieceClick(ChessPiece piece)
    {
        //不能点击AI的棋子
        if (piece.color == ChessPiece.PieceFaction.Enemy)
            return;
        //不能点击对方的棋子
        if (GameDataMgr.Instance.PlayerRound == 1)
        {
            if (piece.color == ChessPiece.PieceFaction.Player2)
                return;
        }
        if (GameDataMgr.Instance.PlayerRound == 2)
        {
            if (piece.color == ChessPiece.PieceFaction.Player1)
                return;
        }
        if (selectedPiece != null)
        {
            // 如果已经有选中的棋子，取消选中
            selectedPiece.Deselect();
            selectedPiece.ClearValidMovePositions(); // 清除之前的可移动位置
        }
        // 选中当前点击的棋子
        selectedPiece = piece;
        selectedPiece.Select();

        GameObjectMgr.Instance.isClickPiece = true;
        // 计算并显示可移动的空位置
        selectedPiece.CalculateValidMovePositions();

        if (selectedPiece.validMovePositions.Count == 0)
        {
            selectedPiece.Deselect();
            selectedPiece = null;
            GameObjectMgr.Instance.isClickPiece = false;
        }
        else
            selectedPiece.ShowValidMovePositions();

    }

    /// <summary>
    /// 处理棋盘点击
    /// </summary>
    private void HandleBoardClick(Vector3 worldPosition)
    {
        //如果处于副本场景
        if (SceneManager.GetActiveScene().buildIndex == 1 || SceneManager.GetActiveScene().buildIndex == 3)
        {
            //如果玩家在UI面板选中了棋子的类型
            if (GameObjectMgr.Instance.playerRoleInfo != null && GameDataMgr.Instance.playerMobility > 0 && IsPositionValid(worldPosition) && GameDataMgr.Instance.playCoin - GameObjectMgr.Instance.playerRoleInfo.f_exp >= 0 && GetPiece(worldPosition) == null && GameObjectMgr.Instance.isClickPiece == false && selectedPiece == null)
            {
                MusicMgr.Instance.PlaySound("史莱姆落子");
                //共用一个棋子预制体，生成时按角色动态装配图片与动画
                ChessPiece playerPiece = ChessPieceMgr.Instance.SpawnPiece(
                    GetSnappedPosition(worldPosition),
                    GameObjectMgr.Instance.playerRoleInfo,
                    ChessPiece.PieceFaction.Player);

                GameDataMgr.Instance.playerMobility--;
                if (GameDataMgr.Instance.playerMobility < 0)
                    GameDataMgr.Instance.playerMobility = 0;
                //更新UI
                UIMgr.Instance.GetPanel<GamePanel>(panel =>
                {
                    panel.ChangePlayerMobility(GameDataMgr.Instance.playerMobility);
                });

                //扣除玩家金币
                GameDataMgr.Instance.playCoin -= playerPiece.roleProperty.f_exp;
                //记录玩家的消耗
                GameDataMgr.Instance.playerSpend += playerPiece.roleProperty.f_exp;
                //更新UI
                UIMgr.Instance.GetPanel<GamePanel>(panel =>
                {
                    panel.ChangePlayerCoin(GameDataMgr.Instance.playCoin);
                });

            }
            //如果玩家只是点击了棋盘,并且已经选中了棋子
            else
            {
                if (selectedPiece != null && GameDataMgr.Instance.playerMobility > 0)
                {
                    // 目标位置就是屏幕点击的位置
                    Vector2 targetPosition = (Vector2)worldPosition;

                    // 检查目标位置是否在可移动的空位置列表中
                    foreach (Vector2 pos in selectedPiece.validMovePositions)
                    {
                        if (Vector3.Distance(pos, targetPosition) <= 0.5f)
                        {
                            // 移动棋子到目标位置
                            selectedPiece.MoveTo(pos);
                            selectedPiece.Deselect();
                            //玩家的行动力减1
                            GameDataMgr.Instance.playerMobility--;
                            if (GameDataMgr.Instance.playerMobility <= 0)
                                GameDataMgr.Instance.playerMobility = 0;
                            //更新UI
                            UIMgr.Instance.GetPanel<GamePanel>(panel =>
                            {
                                panel.ChangePlayerMobility(GameDataMgr.Instance.playerMobility);
                            });
                            //EventCenter.Instance.EventTrigger(E_EventType.E_IsSurrounded);
                        }
                        GameObjectMgr.Instance.isClickPiece = false;
                    }
                    // 清除可移动位置
                    selectedPiece.ClearValidMovePositions();
                    selectedPiece = null; // 清除选中的棋子
                }
            }
        }

        //如果处于pvp的场景
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            //如果玩家在UI面板选中了棋子的类型
            if (GameObjectMgr.Instance.playerRoleInfo != null && IsPositionValid(worldPosition) && GetPiece(worldPosition) == null && GameObjectMgr.Instance.isClickPiece == false)
            {
                //如果是玩家1的回合
                if (GameDataMgr.Instance.PlayerRound == 1 && GameDataMgr.Instance.player1Coin - GameObjectMgr.Instance.playerRoleInfo.f_exp >= 0)
                {
                    MusicMgr.Instance.PlaySound("史莱姆落子");
                    //共用一个棋子预制体，生成时按角色动态装配图片与动画
                    ChessPiece player1Piece = ChessPieceMgr.Instance.SpawnPiece(
                        GetSnappedPosition(worldPosition),
                        GameObjectMgr.Instance.playerRoleInfo,
                        ChessPiece.PieceFaction.Player1);

                    //扣除金币，更新UI
                    GameDataMgr.Instance.player1Coin -= player1Piece.roleProperty.f_exp;
                    UIMgr.Instance.GetPanel<PvpPanel>(panel =>
                    {
                        panel.ChangePlayer1Coin(GameDataMgr.Instance.player1Coin);
                        panel.Player1EndOfDrop();
                    });

                    //EventCenter.Instance.EventTrigger(E_EventType.E_IsSurrounded);
                }
                else if (GameDataMgr.Instance.PlayerRound == 2 && GameDataMgr.Instance.player2Coin - GameObjectMgr.Instance.playerRoleInfo.f_exp >= 0)//如果是玩家2的回合
                {
                    MusicMgr.Instance.PlaySound("史莱姆落子");
                    //玩家2用敌人那套美术
                    ChessPiece player2Piece = ChessPieceMgr.Instance.SpawnPiece(
                        GetSnappedPosition(worldPosition),
                        GameObjectMgr.Instance.playerRoleInfo,
                        ChessPiece.PieceFaction.Player2);

                    //扣除金币，更新UI
                    GameDataMgr.Instance.player2Coin -= player2Piece.roleProperty.f_exp;
                    UIMgr.Instance.GetPanel<PvpPanel>(panel =>
                    {
                        panel.ChangePlayer2Coin(GameDataMgr.Instance.player2Coin);
                        panel.Player2EndOfDrop();
                    });

                    // EventCenter.Instance.EventTrigger(E_EventType.E_IsSurrounded);
                }
            }
            else//如果玩家只是点击了棋盘,并且已经选中了棋子
            {
                if (selectedPiece != null)
                {
                    // 目标位置就是屏幕点击的位置
                    Vector2 targetPosition = (Vector2)worldPosition;

                    // 检查目标位置是否在可移动的空位置列表中
                    foreach (Vector2 pos in selectedPiece.validMovePositions)
                    {
                        if (Vector3.Distance(pos, targetPosition) <= 0.5f)
                        {
                            // 移动棋子到目标位置
                            selectedPiece.MoveTo(pos);
                            selectedPiece.Deselect();

                            //EventCenter.Instance.EventTrigger(E_EventType.E_IsSurrounded);
                        }
                        GameObjectMgr.Instance.isClickPiece = false;
                    }
                    // 清除可移动位置
                    selectedPiece.ClearValidMovePositions();
                    selectedPiece = null; // 清除选中的棋子                                        
                    //如果是玩家1的回合
                    if (GameDataMgr.Instance.PlayerRound == 1)
                    {
                        UIMgr.Instance.GetPanel<PvpPanel>(panel =>
                        {
                            panel.Player1EndOfDrop();
                        });
                    }
                    //如果是玩家2的回合
                    else if (GameDataMgr.Instance.PlayerRound == 2)
                    {
                        UIMgr.Instance.GetPanel<PvpPanel>(panel =>
                        {
                            panel.Player2EndOfDrop();
                        });
                    }
                }
            }
        }

    }

    /// <summary>
    /// 将世界坐标对齐到棋盘格子
    /// </summary>
    public Vector3 GetSnappedPosition(Vector3 worldPosition)
    {
        float snappedX = boardOffset.x + Mathf.Round((worldPosition.x - boardOffset.x) / cellSize) * cellSize;
        float snappedY = boardOffset.y + Mathf.Round((worldPosition.y - boardOffset.y) / cellSize) * cellSize;
        return new Vector3(snappedX, snappedY, 0);
    }

    /// <summary>
    /// 检查目标位置是否在棋盘的有效范围内
    /// </summary>
    public bool IsPositionValid(Vector3 position)
    {
        const float tolerance = 0.6f; // 1厘米容差
        return position.x >= boardOffset.x - tolerance
               && position.x <= boardOffset.x + (boardWidth - 1 * cellSize) + tolerance
               && position.y >= boardOffset.y - tolerance
               && position.y <= boardOffset.y + (boardHeight - 1 * cellSize) + tolerance;
    }

    /// <summary>
    /// 清除可移动点显示（兼容旧接口：清除当前选中棋子的提示点）
    /// </summary>
    public void ClearValidMovePositions()
    {
        if (selectedPiece != null) selectedPiece.ClearValidMovePositions();
    }



    /// <summary>
    /// 获取指定位置上的棋子（走棋盘网格索引，O(1)；安卓上物理检测不准，一直用的是坐标判断）
    /// </summary>
    public ChessPiece GetPiece(Vector2 position)
    {
        return ChessPieceMgr.Instance.GetPiece(position);
    }

    /// <summary>
    /// 获取重叠的棋子（网格索引下同一格最多只有一个棋子）
    /// </summary>
    public List<ChessPiece> GetPiecesOverlap(Vector2 position)
    {
        List<ChessPiece> resultPieces = new List<ChessPiece>(2);

        ChessPiece piece = ChessPieceMgr.Instance.GetPiece(position);
        if (piece == null)
            return resultPieces;

        Vector2 piecePos = piece.transform.position;
        if ((piecePos - position).sqrMagnitude <= 0.25f * 0.25f)
            resultPieces.Add(piece);

        return resultPieces;
    }

    /// <summary>
    /// 判断该位置的棋子（及其连通块）是否被围住。
    /// 判定已由 ChessPieceMgr 在棋盘变化时统一算好并缓存，这里直接读取，O(1)。
    /// </summary>
    public bool CheckIfSurrounded(Vector2 position)
    {
        return ChessPieceMgr.Instance.IsSurroundedAt(position);
    }

    /// <summary>
    /// 获取指定菱形个数内，基于指定中心点的棋盘格子上的点坐标
    /// </summary>
    /// <param name="centerPos">中心点的网格坐标</param>
    /// <param name="diamondCount">菱形的范围</param>
    /// <returns>菱形范围内的所有点坐标</returns>
    public List<Vector2> GetDiamondPoints(Vector2 centerPos, int diamondCount)
    {
        List<Vector2> allPoints = new List<Vector2>();

        // 将中心点转换为网格坐标
        int centerX = Mathf.RoundToInt((centerPos.x - boardOffset.x) / cellSize);
        int centerY = Mathf.RoundToInt((centerPos.y - boardOffset.y) / cellSize);

        // 遍历菱形范围
        for (int atkRange = 1; atkRange <= diamondCount; atkRange++)
        {
            // 遍历当前范围内的所有点
            for (int y = centerY - atkRange; y <= centerY + atkRange; y++)
            {
                for (int x = centerX - atkRange; x <= centerX + atkRange; x++)
                {
                    // 计算曼哈顿距离
                    int distX = Mathf.Abs(x - centerX);
                    int distY = Mathf.Abs(y - centerY);
                    if (distX + distY <= atkRange)
                    {
                        // 检查点是否在棋盘范围内
                        if (x >= 0 && x < boardWidth && y >= 0 && y < boardHeight)
                        {
                            // 计算世界坐标
                            float worldX = boardOffset.x + x * cellSize;
                            float worldY = boardOffset.y + y * cellSize;
                            Vector2 pos = new Vector2(worldX, worldY);

                            if (IsPositionValid(pos))
                                allPoints.Add(pos);
                        }
                    }
                }
            }
        }
        return allPoints;
    }

    public void PlaceRandomly()
    {
        // 随机落子逻辑
        //Debug.Log("AI 随机落子");

        // 存储所有空位置的列表
        List<Vector2> emptyPositions = new List<Vector2>();

        // 遍历棋盘网格，找到所有空位置
        for (int x = 0; x < boardWidth; x++)
        {
            for (int y = 0; y < boardHeight; y++)
            {
                Vector2 position = new Vector2(boardOffset.x + x * cellSize,
                                               boardOffset.y + y * cellSize);

                // 检查该位置是否为空
                if (GetPiece(position) == null)
                {
                    emptyPositions.Add(position);
                }
            }
        }

        // 如果有空位置，随机选择一个
        if (emptyPositions.Count > 0)
        {
            int randomIndex = Random.Range(0, emptyPositions.Count);
            Vector2 randomPosition = emptyPositions[randomIndex];

            // 在随机位置落子
            AIPlacePiece(randomPosition);
        }
        else
        {
            //Debug.Log("棋盘已满，无法落子");
        }

    }

    private void AIPlacePiece(Vector2 position)
    {
        if (GetPiece(position) != null)
            return;

        if (nowLevelRole.Count == 0)
        {
            Debug.LogError("本关没有配置可用角色，无法放置敌方棋子");
            return;
        }

        //随机选择棋子
        T_Role roleInfo = nowLevelRole[Random.Range(0, nowLevelRole.Count)];

        //共用一个棋子预制体，生成时按角色动态装配图片与动画
        ChessPieceMgr.Instance.SpawnPiece(GetSnappedPosition(position), roleInfo, ChessPiece.PieceFaction.Enemy);
    }

    public void TrainPlacePlayerPiece(int x, int y)
    {
        Vector2 position = new Vector2(boardOffset.x + x * cellSize, boardOffset.y + y * cellSize);

        GameObjectMgr.Instance.playerRoleInfo = GameObjectMgr.Instance.AllRoleList[0];
        ChessPieceMgr.Instance.SpawnPiece(GetSnappedPosition(position),
            GameObjectMgr.Instance.playerRoleInfo, ChessPiece.PieceFaction.Player);
    }

    public void TrainPlaceAIPiece(int x, int y)
    {
        Vector2 position = new Vector2(boardOffset.x + x * cellSize, boardOffset.y + y * cellSize);

        GameObjectMgr.Instance.AIRoleInfo = GameObjectMgr.Instance.AllRoleList[0];
        ChessPieceMgr.Instance.SpawnPiece(GetSnappedPosition(position),
            GameObjectMgr.Instance.AIRoleInfo, ChessPiece.PieceFaction.Enemy);
    }

    /// <summary>
    /// 看广告随机放置7级棋子
    /// </summary>
    public void RandomPlaceTopPiece()
    {
        // 存储所有空位置的列表
        List<Vector2> emptyPositions = new List<Vector2>();

        // 遍历棋盘网格，找到所有空位置
        for (int x = 0; x < boardWidth; x++)
        {
            for (int y = 0; y < boardHeight; y++)
            {
                Vector2 position = new Vector2(boardOffset.x + x * cellSize,
                                               boardOffset.y + y * cellSize);

                // 检查该位置是否为空
                if (GetPiece(position) == null)
                {
                    emptyPositions.Add(position);
                }
            }
        }

        // 如果有空位置，随机选择一个
        if (emptyPositions.Count > 0)
        {
            int randomIndex = Random.Range(0, emptyPositions.Count);
            Vector2 randomPosition = emptyPositions[randomIndex];

            T_Role topInfo = GameObjectMgr.Instance.maoDie;
            MusicMgr.Instance.PlaySound("史莱姆落子");
            //共用一个棋子预制体，生成时按角色动态装配图片与动画
            ChessPieceMgr.Instance.SpawnPiece(GetSnappedPosition(randomPosition), topInfo, ChessPiece.PieceFaction.Player);

            UIMgr.Instance.GetPanel<GamePanel>(panel =>
            {
                panel.ChangeTip(topInfo.f_name);
            });


            //特效
            ABResMgr.Instance.LoadResAsync<GameObject>("effect", "下落特效", (obj) =>
            {
                Instantiate(obj, GetSnappedPosition(randomPosition), Quaternion.identity);
            });
        }
    }

    /// <summary>
    /// 当棋盘满了，看广告删除10个棋子
    /// </summary>
    public void DeleteTenAIPiece()
    {
        for (int i = 0; i < 10; i++)
        {
            List<ChessPiece> enemies = GameObjectMgr.Instance.AIChess;
            if (enemies.Count == 0) break;   // 兜底：不足 10 个时不再取

            ChessPiece piece = enemies[Random.Range(0, enemies.Count)];
            ChessPieceMgr.Instance.Despawn(piece);   // 注销索引与容器，再销毁
        }
        RandomPlaceTopPiece();
        GameLevelMgr.Instance.SetRelifeIsShow();
    }

}
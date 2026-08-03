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

    public List<Vector2> validMovePositions = new List<Vector2>(); // 可移动的空位置

    public GameObject point;
    public static ChessBoard chessBoard;
    //用于储存可视化移动点的列表
    private List<GameObject> pointObjects = new List<GameObject>();

    private List<GameObject> atkPoints = new List<GameObject>();

    List<T_Role> nowLevelRole = new List<T_Role>();

    private Coroutine checkPieceIsOverlap;

    private float proximityThreshold = 0.15f;

    private void Awake()
    {
        chessBoard = this;

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

        //checkPieceIsOverlap = StartCoroutine(CheckProximity());
    }

    private void Update()
    {
        CheckProximity();
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

        //StopCoroutine(CheckProximity());
    }

    /// <summary>
    /// 点击屏幕时的回调
    /// </summary>
    private void OnScreenTapped(Vector2 screenPosition)
    {
        //Debug.Log("屏幕点击位置: " + screenPosition);
        // 得到点击屏幕的世界坐标
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        // 2D游戏要确保z坐标等于0
        worldPosition.z = 0;
        //Debug.Log("世界坐标: " + worldPosition);

        RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);
        if (hit.collider != null)
        {
            //Debug.Log("点击对象: " + hit.collider.name);
            ChessPiece piece = hit.collider.GetComponent<ChessPiece>();
            if (piece != null)
            {
                //Debug.Log("点击棋子: " + piece.name);
                HandlePieceClick(piece);
            }
        }
        else //必须要检测点击的坐标是否处于棋盘内
        {
            //Debug.Log("点击棋盘");
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
                ABResMgr.Instance.LoadResAsync<GameObject>("playerpiece", GameObjectMgr.Instance.playerRoleInfo.f_icon, (obj) =>
                {
                    MusicMgr.Instance.PlaySound("史莱姆落子");
                    ChessPiece playerPiece = Instantiate(obj, GetSnappedPosition(worldPosition), Quaternion.identity).GetComponent<ChessPiece>();

                    //设置棋子的阵营
                    playerPiece.color = ChessPiece.PieceFaction.Player;
                    //初始化棋子的数值
                    playerPiece.SetData(GameObjectMgr.Instance.playerRoleInfo);
                    playerPiece.needCheckSurrounding = true;
                    //GameObjectMgr.Instance.isPlayerSelect = false;
                    //print(playerPiece.roleProperty.f_name);
                    //将棋子添加至容器中，便于管理
                    GameObjectMgr.Instance.playerChess.Add(playerPiece);
                    GameObjectMgr.Instance.allChessList.Add(playerPiece);

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
                    ABResMgr.Instance.LoadResAsync<GameObject>("playerpiece", GameObjectMgr.Instance.playerRoleInfo.f_icon, (obj) =>
                    {
                        MusicMgr.Instance.PlaySound("史莱姆落子");
                        ChessPiece playerPiece = Instantiate(obj, GetSnappedPosition(worldPosition), Quaternion.identity).GetComponent<ChessPiece>();
                        //设置棋子的阵营
                        playerPiece.color = ChessPiece.PieceFaction.Player1;
                        //初始化棋子的数值
                        playerPiece.SetData(GameObjectMgr.Instance.playerRoleInfo);
                        playerPiece.needCheckSurrounding = true;
                        //将棋子添加至容器中，便于管理
                        GameObjectMgr.Instance.player1List.Add(playerPiece);
                        GameObjectMgr.Instance.allChessList.Add(playerPiece);

                        //扣除金币，更新UI
                        GameDataMgr.Instance.player1Coin -= playerPiece.roleProperty.f_exp;
                        UIMgr.Instance.GetPanel<PvpPanel>(panel =>
                        {
                            panel.ChangePlayer1Coin(GameDataMgr.Instance.player1Coin);
                            panel.Player1EndOfDrop();
                        });

                    });
                    //EventCenter.Instance.EventTrigger(E_EventType.E_IsSurrounded);
                }
                else if (GameDataMgr.Instance.PlayerRound == 2 && GameDataMgr.Instance.player2Coin - GameObjectMgr.Instance.playerRoleInfo.f_exp >= 0)//如果是玩家2的回合
                {
                    ABResMgr.Instance.LoadResAsync<GameObject>("enemypiece", GameObjectMgr.Instance.playerRoleInfo.f_icon, (obj) =>
                    {
                        MusicMgr.Instance.PlaySound("史莱姆落子");
                        ChessPiece playerPiece = Instantiate(obj, GetSnappedPosition(worldPosition), Quaternion.identity).GetComponent<ChessPiece>();
                        //设置棋子的阵营
                        playerPiece.color = ChessPiece.PieceFaction.Player2;
                        //初始化棋子的数值
                        playerPiece.SetData(GameObjectMgr.Instance.playerRoleInfo);
                        playerPiece.needCheckSurrounding = true;
                        //将棋子添加至容器中，便于管理
                        GameObjectMgr.Instance.player2List.Add(playerPiece);
                        GameObjectMgr.Instance.allChessList.Add(playerPiece);

                        //扣除金币，更新UI
                        GameDataMgr.Instance.player2Coin -= playerPiece.roleProperty.f_exp;
                        UIMgr.Instance.GetPanel<PvpPanel>(panel =>
                        {
                            panel.ChangePlayer2Coin(GameDataMgr.Instance.player2Coin);
                            panel.Player2EndOfDrop();
                        });

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
    /// 计算棋子可移动的空位置
    /// </summary>
    private void CalculateValidMovePositions(ChessPiece piece)
    {
        validMovePositions.Clear();

        Vector2 startPosition = (Vector2)piece.transform.position;
        int moveRange = piece.roleProperty.f_move;

        while (moveRange > 0)
        {
            // 检查上下左右四个方向
            Vector2[] directions = new Vector2[]
            {
                    new Vector2(0, cellSize * moveRange),  // 上
                    new Vector2(0, -cellSize * moveRange), // 下
                    new Vector2(-cellSize * moveRange, 0), // 左
                    new Vector2(cellSize * moveRange, 0)   // 右
            };

            foreach (Vector2 dir in directions)
            {
                Vector2 neighbor = startPosition + dir;
                ChessPiece neighborPiece = GetPiece(neighbor);

                if (IsPositionValid(neighbor))
                {
                    if (neighborPiece == null) // 空位
                    {
                        validMovePositions.Add(neighbor);
                    }
                }
            }

            moveRange--; // 每搜索一层，moveRange 减 1
        }
    }


    /// <summary>
    /// 显示可移动的空位置
    /// </summary>
    private void ShowValidMovePositions()
    {
        foreach (Vector2 position in validMovePositions)
        {
            Debug.Log($"可移动位置: {position}");
            // 在这里可以添加可视化逻辑，例如显示高亮方块
            GameObject obj = Instantiate(point, position, Quaternion.identity);
            pointObjects.Add(obj);
        }
    }

    /// <summary>
    /// 清除可移动的空位置
    /// </summary>
    public void ClearValidMovePositions()
    {
        validMovePositions.Clear();
        // 在这里可以清除可视化逻辑，例如隐藏高亮方块
        foreach (GameObject obj in pointObjects)
        {
            Destroy(obj);
        }
        pointObjects.Clear();
    }



    /// <summary>
    /// 安全版棋子检测方法（适配安卓平台）
    /// </summary>
    public ChessPiece GetPiece(Vector2 position)
    {
        //安卓平台上的物理检测有点问题，不能用
        if (GameObjectMgr.Instance.allChessList == null)
            return null;

        //改用距离检测
        foreach (var piece in GameObjectMgr.Instance.allChessList)
        {
            Vector2 piecePos = piece.transform.position;
            float distanceSqr = (piecePos - position).sqrMagnitude;

            if (distanceSqr <= 0.5f * 0.5f)
                return piece;
        }
        return null;
    }

    /// <summary>
    /// 获取重叠的棋子
    /// </summary>
    public List<ChessPiece> GetPiecesOverlap(Vector2 position)
    {
        List<ChessPiece> resultPieces = new List<ChessPiece>();

        //安卓平台上的物理检测有点问题，不能用
        if (GameObjectMgr.Instance.allChessList == null)
            return resultPieces;

        //改用距离检测
        foreach (var piece in GameObjectMgr.Instance.allChessList)
        {
            Vector2 piecePos = piece.transform.position;
            float distanceSqr = (piecePos - position).sqrMagnitude;

            if (distanceSqr <= 0.25f * 0.25f)
            {
                resultPieces.Add(piece);
                if (resultPieces.Count >= 2)
                {
                    return resultPieces;
                }
            }
        }
        return resultPieces;
    }

    /// <summary>
    /// 获取棋子的方法
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    public ChessPiece GetPiece2(Vector2 position)
    {
        if (IsPositionValid(position))
        {
            // 确保物理状态同步
            Physics2D.SyncTransforms();

            // 获取棋子所在的层级
            int layerMask = 1 << LayerMask.NameToLayer("ChessPiece");

            // 使用 OverlapCircleAll 来检测圆形碰撞体，增大检测半径
            Collider2D[] colliders = Physics2D.OverlapCircleAll(position, 0.5f, layerMask);
            foreach (Collider2D collider in colliders)
            {
                ChessPiece chess = collider.GetComponent<ChessPiece>();
                if (chess != null)
                {
                    return chess;
                }
            }
        }
        return null;
    }

    /// <summary>
    /// 获取与目标棋子相连的所有同色棋子
    /// </summary>
    private List<Vector2> GetConnectedGroup(Vector2 position, ChessPiece.PieceFaction color)
    {
        // 存储相连同色棋子位置的列表
        List<Vector2> connectedGroup = new List<Vector2>();
        // 存储已访问位置的哈希集
        HashSet<Vector2> visited = new HashSet<Vector2>();
        // 用于广度优先搜索的队列
        Queue<Vector2> queue = new Queue<Vector2>();


        if (GetPiece(position) != null && GetPiece(position).color == color)
        {
            // 将起始位置加入队列和已访问集合
            queue.Enqueue(position);
            visited.Add(position);
        }

        while (queue.Count > 0)
        {
            // 取出队列中的当前位置
            Vector2 current = queue.Dequeue();
            // 将当前位置加入相连同色棋子列表
            connectedGroup.Add(current);

            // 检查上下左右四个方向
            Vector2[] directions = new Vector2[]
            {
                new Vector2(0, cellSize),  // 上
                new Vector2(0, -cellSize), // 下
                new Vector2(-cellSize, 0), // 左
                new Vector2(cellSize, 0)   // 右
            };

            foreach (Vector2 dir in directions)
            {
                // 计算相邻位置
                Vector2 neighbor = current + dir;
                if (IsPositionValid(neighbor) && !visited.Contains(neighbor))
                {
                    // 获取相邻位置的棋子
                    ChessPiece neighborPiece = GetPiece(neighbor);
                    if (neighborPiece != null && neighborPiece.color == color)
                    {
                        // 将相邻位置加入队列和已访问集合
                        queue.Enqueue(neighbor);
                        visited.Add(neighbor);
                    }
                }
            }
        }

        return connectedGroup;
    }

    /// <summary>
    /// 计算连通区域的气
    /// </summary>
    private int CalculateLiberties(List<Vector2> group)
    {
        // 存储气的位置的哈希集
        HashSet<Vector2> liberties = new HashSet<Vector2>();

        foreach (Vector2 position in group)
        {
            // 检查上下左右四个方向
            Vector2[] directions = new Vector2[]
            {
                new Vector2(0, cellSize),  // 上
                new Vector2(0, -cellSize), // 下
                new Vector2(-cellSize, 0), // 左
                new Vector2(cellSize, 0)   // 右
            };

            foreach (Vector2 dir in directions)
            {
                // 计算相邻位置
                Vector2 neighbor = position + dir;
                if (IsPositionValid(neighbor))
                {
                    // 获取相邻位置的棋子
                    ChessPiece neighborPiece = GetPiece(neighbor);
                    if (neighborPiece == null) // 空位
                    {
                        // 将空位加入气的集合
                        liberties.Add(neighbor);
                    }
                }
            }
        }

        return liberties.Count;
    }

    /// <summary>
    /// 判断连通区域是否被敌方棋子围住
    /// </summary>
    public bool CheckIfSurrounded(Vector2 position)
    {
        // 获取指定位置的棋子
        ChessPiece piece = GetPiece(position);
        if (piece == null)
            return false;

        if (GameObjectMgr.Instance.AIChess.Count == 81 || GameObjectMgr.Instance.playerChess.Count == 81)
            return false;

        // 获取连通区域
        List<Vector2> connectedGroup = GetConnectedGroup(position, piece.color);

        // 计算气
        int liberties = CalculateLiberties(connectedGroup);

        // 判断是否被围住
        if (liberties == 0)
        {
            foreach (Vector2 position2 in connectedGroup)
            {
                ChessPiece piece1 = GetPiece(position2);
                if (piece1 != null)
                    piece1.damageBar.gameObject.SetActive(true);
            }
            //Debug.Log("棋子或连通区域被围住");
            return true;
        }
        else
        {
            foreach (Vector2 position2 in connectedGroup)
            {
                ChessPiece piece1 = GetPiece(position2);
                if (piece1 != null)
                    piece1.damageBar.gameObject.SetActive(false);
            }
            //Debug.Log("棋子或连通区域未被围住");
            return false;
        }
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

    public List<Vector2> GetDiamondPointsAndroid(Vector2 centerPos, int diamondCount)
    {
        List<Vector2> allPoints = new List<Vector2>();
        Physics2D.SyncTransforms(); // 同步物理状态

        // 使用Floor确保网格坐标一致性
        int centerX = Mathf.FloorToInt((centerPos.x - boardOffset.x) / cellSize);
        int centerY = Mathf.FloorToInt((centerPos.y - boardOffset.y) / cellSize);

        for (int atkRange = 1; atkRange <= diamondCount; atkRange++)
        {
            for (int y = centerY - atkRange; y <= centerY + atkRange; y++)
            {
                for (int x = centerX - atkRange; x <= centerX + atkRange; x++)
                {
                    if (Mathf.Abs(x - centerX) + Mathf.Abs(y - centerY) <= atkRange)
                    {
                        if (x >= 0 && x < boardWidth && y >= 0 && y < boardHeight)
                        {
                            // 直接计算世界坐标，避免累积误差
                            Vector2 pos = new Vector2(
                                boardOffset.x + (x * cellSize),
                                boardOffset.y + (y * cellSize)
                            );

                            if (IsPositionValid(pos))
                            {
                                allPoints.Add(pos);
                                Debug.Log($"生成攻击点: {pos}"); // 安卓设备调试
                            }
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

        //随机选择棋子


        T_Role roleInfo = nowLevelRole[Random.Range(0, nowLevelRole.Count)];

        ABResMgr.Instance.LoadResAsync<GameObject>("enemypiece", roleInfo.f_icon, (obj) =>
        {
            ChessPiece aiPiece = GameObject.Instantiate(obj, ChessBoard.chessBoard.GetSnappedPosition(position), Quaternion.identity).GetComponent<ChessPiece>();
            //设置棋子的阵营
            aiPiece.color = ChessPiece.PieceFaction.Enemy;
            //初始化棋子的数值
            aiPiece.SetData(roleInfo);
            //将棋子添加至容器中，便于管理
            GameObjectMgr.Instance.AIChess.Add(aiPiece);
            GameObjectMgr.Instance.allChessList.Add(aiPiece);
        });

        

    }

    private void DelayDestroyPoints()
    {
        foreach (var point in atkPoints)
        {
            Destroy(point.gameObject);
            atkPoints.Remove(point);
        }
    }

    public void TrainPlacePlayerPiece(int x, int y)
    {
        Vector2 position = new Vector2(boardOffset.x + x * cellSize, boardOffset.y + y * cellSize);

        GameObjectMgr.Instance.playerRoleInfo = GameObjectMgr.Instance.AllRoleList[0];
        ABResMgr.Instance.LoadResAsync<GameObject>("playerpiece", GameObjectMgr.Instance.playerRoleInfo.f_icon, (obj) =>
        {
            ChessPiece playerPiece = Instantiate(obj, GetSnappedPosition(position), Quaternion.identity).GetComponent<ChessPiece>();
            //设置棋子的阵营
            playerPiece.color = ChessPiece.PieceFaction.Player;
            //初始化棋子的数值
            playerPiece.SetData(GameObjectMgr.Instance.playerRoleInfo);

            //将棋子添加至容器中，便于管理
            GameObjectMgr.Instance.playerChess.Add(playerPiece);
            GameObjectMgr.Instance.allChessList.Add(playerPiece);
        });
    }

    public void TrainPlaceAIPiece(int x, int y)
    {
        Vector2 position = new Vector2(boardOffset.x + x * cellSize, boardOffset.y + y * cellSize);

        GameObjectMgr.Instance.AIRoleInfo = GameObjectMgr.Instance.AllRoleList[0];

        ABResMgr.Instance.LoadResAsync<GameObject>("enemypiece", GameObjectMgr.Instance.AIRoleInfo.f_icon, (obj) =>
        {
            ChessPiece aiPiece = GameObject.Instantiate(obj, ChessBoard.chessBoard.GetSnappedPosition(position), Quaternion.identity).GetComponent<ChessPiece>();
            //设置棋子的阵营
            aiPiece.color = ChessPiece.PieceFaction.Enemy;
            //初始化棋子的数值
            aiPiece.SetData(GameObjectMgr.Instance.AIRoleInfo);
            //将棋子添加至容器中，便于管理
            GameObjectMgr.Instance.AIChess.Add(aiPiece);
            GameObjectMgr.Instance.allChessList.Add(aiPiece);
        });
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
            ABResMgr.Instance.LoadResAsync<GameObject>("playerpiece",topInfo.f_icon, (obj) =>
            {
                MusicMgr.Instance.PlaySound("史莱姆落子");
                ChessPiece playerPiece = Instantiate(obj, GetSnappedPosition(randomPosition), Quaternion.identity).GetComponent<ChessPiece>();

                //设置棋子的阵营
                playerPiece.color = ChessPiece.PieceFaction.Player;
                //初始化棋子的数值
                playerPiece.SetData(topInfo);

                //将棋子添加至容器中，便于管理
                GameObjectMgr.Instance.playerChess.Add(playerPiece);
                GameObjectMgr.Instance.allChessList.Add(playerPiece);

                UIMgr.Instance.GetPanel<GamePanel>(panel =>
                {
                    panel.ChangeTip(topInfo.f_name);
                });
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
            ChessPiece piece = GameObjectMgr.Instance.AIChess[UnityEngine.Random.Range(0, GameObjectMgr.Instance.AIChess.Count)];
            GameObjectMgr.Instance.AIChess.Remove(piece);
            GameObjectMgr.Instance.allChessList.Remove(piece);
            Destroy(piece.gameObject);
        }
        RandomPlaceTopPiece();
        GameLevelMgr.Instance.SetRelifeIsShow();
    }

    /// <summary>
    /// 检测可移动点是否已被棋子占满
    /// </summary>
    private bool CheckVaildPosIsFull(List<Vector2> vector2s)
    {
        bool isFull = true;

        foreach (Vector2 pos in vector2s)
        {
            ChessPiece piece = GetPiece(pos);
            if (piece == null)
            {
                isFull = false;
                break;
            }
        }
        return isFull;
    }

    private IEnumerator CheckPieceIsOverlap()
    {
        while (true)
        {
            // 遍历棋盘网格，找到所有空位置
            for (int x = 0; x < boardWidth; x++)
            {
                for (int y = 0; y < boardHeight; y++)
                {
                    Vector2 position = new Vector2(boardOffset.x + x * cellSize, boardOffset.y + y * cellSize);
                    List<ChessPiece> pieces = GetPiecesOverlap(position);
                    if (pieces.Count >= 2)
                    {
                        foreach (ChessPiece piece in pieces)
                        {
                            switch (piece.color)
                            {
                                case PieceFaction.Player:
                                    GameObjectMgr.Instance.playerChess.Remove(piece);
                                    break;
                                case PieceFaction.Enemy:
                                    GameObjectMgr.Instance.AIChess.Remove(piece);
                                    break;
                            }
                            GameObjectMgr.Instance.allChessList.Remove(piece);
                            Destroy(piece.gameObject);
                        }
                    }
                }
            }
            yield return new WaitForSeconds(1f);
        }
    }

    public void CheckProximity()
    {

        for (int i = 0; i < GameObjectMgr.Instance.allChessList.Count - 1; i++)
        {
            for (int j = i + 1; j < GameObjectMgr.Instance.allChessList.Count; j++)
            {
                Vector2 pos1 = GameObjectMgr.Instance.allChessList[i].transform.position;
                Vector2 pos2 = GameObjectMgr.Instance.allChessList[j].transform.position;
                Vector2 diff = pos1 - pos2;
                float distanceSqr = diff.x * diff.x + diff.y * diff.y;
                float proximityThresholdSqr = proximityThreshold * proximityThreshold;
                if (distanceSqr <= proximityThresholdSqr)
                {
                    // 这里放置距离满足条件时执行的代码
                    ChangePiecePos(GameObjectMgr.Instance.allChessList[i]);
                    ChangePiecePos(GameObjectMgr.Instance.allChessList[j]);
                }                
            }
        }



    }

    /// <summary>
    /// 改变重叠棋子的位置
    /// </summary>
    /// <param name="piece"></param>
    private void ChangePiecePos(ChessPiece piece)
    {
        // 遍历棋盘网格，找到所有空位置
        for (int x = 0; x < boardWidth; x++)
        {
            for (int y = 0; y < boardHeight; y++)
            {
                Vector2 position = new Vector2(boardOffset.x + x * cellSize, boardOffset.y + y * cellSize);

                if(GetPiece(position)==null)
                    piece.MoveTo(position);
            }
        }
    }
}
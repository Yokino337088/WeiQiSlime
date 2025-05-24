using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class ChessPiece : MonoBehaviour
{
    /// <summary>
    /// 棋子阵营
    /// </summary>
    public enum PieceFaction { Player, Enemy, Player1, Player2 }

    public PieceFaction color; // 棋子颜色
    public int moveRange = 1; // 移动力属性
    public Vector2 gridPosition; // 棋子在棋盘上的网格位置（使用 Vector2）
    public bool isSelected = false; // 是否被选中

    /// <summary>
    /// 角色属性
    /// </summary>
    public RoleProperty roleProperty = new RoleProperty();

    // 棋子血量
    public int hp;


    // 棋子血条
    public GameObject hpBar;
    // 4 倍伤害标识
    public GameObject damageBar;

    private Vector3 hpBarSize;
    private List<GameObject> objectsToDestroy = new List<GameObject>();

    public float hpScaleX;

    // 缓存常用的单例实例
    private static ChessBoard chessBoardInstance;
    private static GameObjectMgr gameObjectMgrInstance;
    private static PoolMgr poolMgrInstance;
    private static GameAchieveMgr gameAchieveMgrInstance;

    //攻击携程
    private Coroutine attackCoroutine;
    //修改血条携程
    private Coroutine hpCoroutine;
    //被围携程
    private Coroutine checkSurrounding;

    public bool isSurrounded;

    // 标记是否需要检查包围状态
    public bool needCheckSurrounding = false;

    public List<Vector2> validMovePositions = new List<Vector2>(); // 可移动的空位置
    //用于储存可视化移动点的列表
    private List<GameObject> pointObjects = new List<GameObject>();

    private void Awake()
    {
        // 缓存单例实例
        if (chessBoardInstance == null) chessBoardInstance = ChessBoard.chessBoard;
        if (gameObjectMgrInstance == null) gameObjectMgrInstance = GameObjectMgr.Instance;
        if (poolMgrInstance == null) poolMgrInstance = PoolMgr.Instance;
        if (gameAchieveMgrInstance == null) gameAchieveMgrInstance = GameAchieveMgr.Instance;
    }

    private void Start()
    {
        damageBar.SetActive(false);
        hpBarSize = hpBar.transform.localScale;
        // 修改为通过 MonoMgr 启动协程
        attackCoroutine = StartCoroutine(AttackIntervalCoroutine());
        checkSurrounding = MonoMgr.Instance.StartCoroutine(CheckSurrounding(), "checkSurrounding");
        hpScaleX = hpBar.transform.localScale.x;
        hpCoroutine = StartCoroutine(ChangeHpBar());
       
    }


    /// <summary>
    /// 攻击携程
    /// </summary>
    /// <returns></returns>
    private IEnumerator AttackIntervalCoroutine()
    {
        WaitForSeconds waitTime = new WaitForSeconds(roleProperty.f_atkInterval);
        while (true)
        {
            Attack();
            yield return waitTime;
        }
    }

    /// <summary>
    /// 被围携程
    /// </summary>
    /// <returns></returns>
    private IEnumerator CheckSurrounding()
    {
        while (true)
        {
            isSurrounded = chessBoardInstance.CheckIfSurrounded(transform.position);
            damageBar.SetActive(isSurrounded);
            if(isSurrounded)
                ClearValidMovePositions();
            yield return new WaitForSeconds(0.05f);
        }
    }



    public void CheckIsSurround()
    {
        isSurrounded = ChessBoard.chessBoard.CheckIfSurrounded(transform.position);
        damageBar.SetActive(isSurrounded);
    }

    public void SetData(T_Role role)
    {
        roleProperty.SetData(role);
        hp = roleProperty.f_hp;
    }

    /// <summary>
    /// 选中棋子
    /// </summary>
    public void Select()
    {
        isSelected = true;
        Debug.Log("棋子被选中: " + gameObject.name);
    }

    /// <summary>
    /// 取消选中棋子
    /// </summary>
    public void Deselect()
    {
        isSelected = false;
        //Debug.Log("棋子取消选中: " + gameObject.name);
    }

    /// <summary>
    /// 移动棋子到目标位置
    /// </summary>
    public void MoveTo(Vector3 targetPosition)
    {
        if (chessBoardInstance.GetPiece(targetPosition) != null)
            return;
        // 目标点没有棋子才能移动
        if (chessBoardInstance.GetPiece(targetPosition) == null)
        {
            MusicMgr.Instance.PlaySound("史莱姆落子");
            
            transform.position = targetPosition;
            
        }
    }

    /// <summary>
    /// 棋子攻击
    /// </summary>
    public void Attack()
    {
        if (this.color==PieceFaction.Enemy && GameObjectMgr.Instance.playerChess.Count == 0)
            return;

        // 选择攻击的敌人棋子
        ChessPiece enemyPiece = null;
        // 棋子攻击范围内的点
        List<Vector2> atkPoints = chessBoardInstance.GetDiamondPoints(this.gameObject.transform.position, this.roleProperty.f_block);


        // 棋子攻击范围内的敌方棋子
        List<ChessPiece> chessPieces = new List<ChessPiece>();

        // 缓存不同阵营的棋子列表
        List<ChessPiece> aiChess = gameObjectMgrInstance.AIChess;
        List<ChessPiece> playerChess = gameObjectMgrInstance.playerChess;
        List<ChessPiece> player1List = gameObjectMgrInstance.player1List;
        List<ChessPiece> player2List = gameObjectMgrInstance.player2List;
        // 遍历攻击范围内的点
        foreach (Vector2 vector in atkPoints)
        {
            switch (color)
            {
                case PieceFaction.Player:
                    foreach (var piece in aiChess)
                    {
                        Vector2 piecePos = piece.transform.position;
                        float distanceSqr = (piecePos - vector).sqrMagnitude;
                        if (distanceSqr <= 0.15f * 0.15f)
                            chessPieces.Add(piece);
                    }
                    break;
                case PieceFaction.Enemy:
                    foreach (var piece in playerChess)
                    {
                        Vector2 piecePos = piece.transform.position;
                        float distanceSqr = (piecePos - vector).sqrMagnitude;
                        if (distanceSqr <= 0.15f * 0.15f)
                            chessPieces.Add(piece);
                    }
                    break;
                case PieceFaction.Player1:
                    foreach (var piece in player2List)
                    {
                        Vector2 piecePos = piece.transform.position;
                        float distanceSqr = (piecePos - vector).sqrMagnitude;
                        if (distanceSqr <= 0.15f * 0.15f)
                            chessPieces.Add(piece);
                    }
                    break;
                case PieceFaction.Player2:
                    foreach (var piece in player1List)
                    {
                        Vector2 piecePos = piece.transform.position;
                        float distanceSqr = (piecePos - vector).sqrMagnitude;
                        if (distanceSqr <= 0.15f * 0.15f)
                            chessPieces.Add(piece);
                    }
                    break;
            }
        }

        // 如果攻击范围内有敌人棋子
        if (chessPieces.Count > 0)
        {
            enemyPiece = chessPieces[Random.Range(0, chessPieces.Count)];
        }
        if (chessPieces.Count == 0)
            return;

        if (enemyPiece != null)
        {
            // 生成一个 0 到 1 之间的随机数
            float randomValue = Random.value;
            // 计算攻击概率
            float probability = (float)(0.3 + (this.roleProperty.f_atk - enemyPiece.roleProperty.f_defense) * 0.007);

            if (randomValue < probability)
            {
                //// 减少生命值
                //int damage = chessBoardInstance.CheckIfSurrounded(enemyPiece.transform.position) ? 4 : 1;
                //enemyPiece.hp -= damage;

                if (roleProperty.f_profession == 7)
                {
                    GameObject bulletObj = poolMgrInstance.GetObj("Object/火法师子弹");
                    bulletObj.transform.position = this.transform.position;
                    Bullet bullet = bulletObj.GetComponent<Bullet>();
                    bullet.ChangeMoveDir(enemyPiece.transform.position - this.transform.position);
                    bullet.ChangeFlipX(this.transform.position.x - enemyPiece.transform.position.x);
                    //bullet.ChangeRotation(enemyPiece.transform.position - this.transform.position);
                    bullet.SetTarget(enemyPiece);
                }
                else if (roleProperty.f_profession == 8)
                {
                    GameObject bulletObj = poolMgrInstance.GetObj("Object/水法师子弹");
                    bulletObj.transform.position = this.transform.position;
                    Bullet bullet = bulletObj.GetComponent<Bullet>();
                    bullet.ChangeMoveDir(enemyPiece.transform.position - this.transform.position);
                    bullet.ChangeFlipX(this.transform.position.x - enemyPiece.transform.position.x);
                    //bullet.ChangeRotation(enemyPiece.transform.position - this.transform.position);
                    bullet.SetTarget(enemyPiece);
                }
                else if (roleProperty.f_profession == 9)
                {
                    GameObject bulletObj = poolMgrInstance.GetObj("Object/光法师子弹");
                    bulletObj.transform.position = this.transform.position;
                    Bullet bullet = bulletObj.GetComponent<Bullet>();
                    bullet.ChangeMoveDir(enemyPiece.transform.position - this.transform.position);
                    bullet.ChangeFlipX(this.transform.position.x - enemyPiece.transform.position.x);
                    //bullet.ChangeRotation(enemyPiece.transform.position - this.transform.position);
                    bullet.SetTarget(enemyPiece);
                }
                else
                {
                    GameObject bulletObj = poolMgrInstance.GetObj("Object/Bullet");
                    bulletObj.transform.position = this.transform.position;
                    Bullet bullet = bulletObj.GetComponent<Bullet>();
                    bullet.ChangeMoveDir(enemyPiece.transform.position - this.transform.position);
                    bullet.ChangeSkillText(this.roleProperty.f_jnwz, this.roleProperty.f_jnwzys);
                    bullet.SetTarget(enemyPiece);
                    
                }

                DelayDeductionHp(enemyPiece);
                

            }
        }
    }

    private void OnEnable()
    {

    }

    void OnDisable()
    {
        // 对象禁用时通过 MonoMgr 停止协程
        if (attackCoroutine != null)
        {
            StopCoroutine(attackCoroutine);
        }
        if (hpCoroutine != null)
        {
            StopCoroutine(hpCoroutine);
        }
        if (checkSurrounding != null)
        {
           MonoMgr.Instance.StopCoroutine(checkSurrounding);
        }

        
    }

    // 外部调用时，不直接 Destroy，而是加入列表
    public void MarkForDestroy(GameObject obj)
    {
        objectsToDestroy.Add(obj);
    }

    
    /// <summary>
    /// 修改血条
    /// </summary>
    /// <returns></returns>
    private IEnumerator ChangeHpBar()
    {
        while (true)
        {
            if (hp > 0)
                hpBar.transform.localScale = new Vector3(hpScaleX * hp / roleProperty.f_hp, 1, 1);

            yield return new WaitForSeconds(0.1f);
        }
    }

    

    /// <summary>
    /// 扣血
    /// </summary>
    /// <param name="enemyPiece"></param>
    private void DelayDeductionHp(ChessPiece enemyPiece)
    {

        if (enemyPiece != null)
        {
            // 减少生命值
            int damage = ChessBoard.chessBoard.CheckIfSurrounded(enemyPiece.transform.position) ? 4 : 1;
            enemyPiece.hp -= damage;

            // 如果生命值为 0，就处理死亡逻辑
            if (enemyPiece.hp <= 0)
            {
                MusicMgr.Instance.PlaySound("史莱姆死亡");
                enemyPiece.hp = 0;

                switch (enemyPiece.color)
                {
                    case PieceFaction.Player:
                        GameObjectMgr.Instance.playerChess.Remove(enemyPiece);
                        break;
                    case PieceFaction.Enemy:
                        GameObjectMgr.Instance.AIChess.Remove(enemyPiece);
                        gameAchieveMgrInstance.enemyCount++;
                        //gameAchieveMgrInstance.CompleteAchievement(4);
                        break;
                    case PieceFaction.Player1:
                        GameObjectMgr.Instance.player1List.Remove(enemyPiece);
                        break;
                    case PieceFaction.Player2:
                        GameObjectMgr.Instance.player2List.Remove(enemyPiece);
                        break;
                }

                gameObjectMgrInstance.allChessList.Remove(enemyPiece);
                enemyPiece.ClearValidMovePositions();
                DestroyImmediate(enemyPiece.gameObject);                
                GameObjectMgr.Instance.isClickPiece = false;
            }

        }

    }

   

    /// <summary>
    /// 显示可移动的空位置
    /// </summary>
    public void ShowValidMovePositions()
    {
        if (validMovePositions.Count == 0)
            return;
        foreach (Vector2 position in validMovePositions)
        {
            Debug.Log($"可移动位置: {position}");
            // 在这里可以添加可视化逻辑，例如显示高亮方块
            GameObject obj = Instantiate(ChessBoard.chessBoard.point, position, Quaternion.identity);
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
    /// 计算棋子可移动的空位置
    /// </summary>
    public void CalculateValidMovePositions()
    {
        validMovePositions.Clear();

        Vector2 startPosition = (Vector2)transform.position;
        int moveRange = roleProperty.f_move;

        while (moveRange > 0)
        {
            // 检查上下左右四个方向
            Vector2[] directions = new Vector2[]
            {
                    new Vector2(0, ChessBoard.chessBoard.cellSize * moveRange),  // 上
                    new Vector2(0, -ChessBoard.chessBoard.cellSize * moveRange), // 下
                    new Vector2(-ChessBoard.chessBoard.cellSize * moveRange, 0), // 左
                    new Vector2(ChessBoard.chessBoard.cellSize * moveRange, 0)   // 右
            };

            foreach (Vector2 dir in directions)
            {
                Vector2 neighbor = startPosition + dir;
                ChessPiece neighborPiece = ChessBoard.chessBoard.GetPiece(neighbor);

                if (ChessBoard.chessBoard.IsPositionValid(neighbor))
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
}
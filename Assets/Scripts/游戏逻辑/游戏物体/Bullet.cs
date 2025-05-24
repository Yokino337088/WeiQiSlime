using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static ChessPiece;

public class Bullet : MonoBehaviour
{
    // 移动方向
    private Vector2 moveDir;
    // 移动速度
    public float speed;
    // 攻击目标
    private ChessPiece targetPiece;
    // 技能文字
    public TextMeshPro textMeshPro;

    // 缓存 PoolMgr 实例
    private static PoolMgr poolMgrInstance;
    // 缓存 ChessBoard 实例
    private static ChessBoard chessBoardInstance;

    private SpriteRenderer sp;

    private void Awake()
    {
        // 在 Awake 中缓存实例，避免多次查找
        if (poolMgrInstance == null)
        {
            poolMgrInstance = PoolMgr.Instance;
        }
        if (chessBoardInstance == null)
        {
            chessBoardInstance = ChessBoard.chessBoard;
        }
        sp = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        Invoke(nameof(PushToPool), 2f);
        
    }

    void Update()
    {
        transform.Translate(speed * moveDir * Time.deltaTime);

        if (targetPiece != null)
        {
            // 比较平方距离替代 Vector2.Distance
            float sqrDistance = (this.transform.position - targetPiece.transform.position).sqrMagnitude;
            if (sqrDistance <= 0.05f * 0.05f)
            {
                
                ReturnToPool();
            }
        }
        else
        {
            ReturnToPool();
        }
    }

    

    /// <summary>
    /// 改变移动方向
    /// </summary>
    /// <param name="dir"></param>
    public void ChangeMoveDir(Vector2 dir)
    {
        moveDir = dir;
    }

    public void ChangeRotation(Vector2 direction)
    {
        // 使用LookRotation方法创建一个旋转，使物体看向目标方向
        Quaternion rotation = Quaternion.LookRotation(direction);
        // 设置物体的旋转
        transform.rotation = rotation;
    }

    /// <summary>
    /// 设置攻击目标
    /// </summary>
    /// <param name="target"></param>
    public void SetTarget(ChessPiece target)
    {
        targetPiece = target;
    }

    /// <summary>
    /// 设置技能文字的方法
    /// </summary>
    /// <param name="text"></param>
    public void ChangeSkillText(string text, string color)
    {
        textMeshPro.text = text;
        Color textColor = ColorStringMapper.GetColorFromString(color);
        textMeshPro.color = textColor;
    }

    

    private void PushToPool()
    {
        ReturnToPool();
    }

    /// <summary>
    /// 将弹幕放回缓存池的统一方法
    /// </summary>
    private void ReturnToPool()
    {
        poolMgrInstance.PushObj(this.gameObject);
    }

    public void ChangeFlipX(float x)
    {
        if (x > 0)
            sp.flipX = true;
        else
            sp.flipX = false;
    }

    private void DelayDeductionHp(ChessPiece enemyPiece)
    {
        // 减少生命值
        int damage = chessBoardInstance.CheckIfSurrounded(enemyPiece.transform.position) ? 4 : 1;
        enemyPiece.hp -= damage;

        // 如果生命值为 0，就处理死亡逻辑
        if (enemyPiece.hp <= 0)
        {
            enemyPiece.hp = 0;

            switch (enemyPiece.color)
            {
                case PieceFaction.Player:
                    GameObjectMgr.Instance.playerChess.Remove(enemyPiece);
                    break;
                case PieceFaction.Enemy:
                    GameObjectMgr.Instance.AIChess.Remove(enemyPiece);
                    GameAchieveMgr.Instance.enemyCount++;
                    //gameAchieveMgrInstance.CompleteAchievement(4);
                    break;
                case PieceFaction.Player1:
                    GameObjectMgr.Instance.player1List.Remove(enemyPiece);
                    break;
                case PieceFaction.Player2:
                    GameObjectMgr.Instance.player2List.Remove(enemyPiece);
                    break;
            }

            GameObjectMgr.Instance.allChessList.Remove(enemyPiece);
            //MarkForDestroy(enemyPiece.gameObject);
            //Destroy(enemyPiece.gameObject);
            DestroyImmediate(enemyPiece.gameObject);
            //PoolMgr.Instance.PushObj(enemyPiece.gameObject);
        }
    }
}

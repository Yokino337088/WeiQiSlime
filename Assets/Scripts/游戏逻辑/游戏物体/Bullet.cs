using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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

    private SpriteRenderer sp;

    private void Awake()
    {
        // 在 Awake 中缓存实例，避免多次查找
        if (poolMgrInstance == null)
        {
            poolMgrInstance = PoolMgr.Instance;
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
    /// 设置技能文字的方法（内容没变化时不重复赋值，避免每次出弹幕都重建文字网格）
    /// </summary>
    /// <param name="text"></param>
    public void ChangeSkillText(string text, string color)
    {
        if (textMeshPro.text != text)
        {
            textMeshPro.text = text;
            textMeshPro.color = ColorStringMapper.GetColorFromString(color);
        }
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
}

using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 棋子：只保留数据与表现，身上不再有任何 Update / 协程。
///
/// 原先每个棋子各自跑 3 条协程（攻击间隔、血条、包围检测），棋子一多，Unity 的协程调度
/// 加上每条协程里的全盘扫描就会把帧率拖垮。现在这些「按时间推进」的逻辑全部由
/// <see cref="ChessPieceMgr"/> 用一个 Update 统一驱动，棋子只负责响应结果。
/// </summary>
public class ChessPiece : MonoBehaviour
{
    /// <summary>
    /// 棋子阵营
    /// </summary>
    public enum PieceFaction { Player, Enemy, Player1, Player2 }

    // ===== 以下字段会被预制体序列化（名称与顺序请保持不变，已有的 AB 资源依赖它们） =====
    public PieceFaction color;                              // 棋子阵营
    public int moveRange = 1;                               // 移动力（历史字段，实际取 roleProperty.f_move）
    public Vector2 gridPosition;                            // 网格位置（历史字段）
    public bool isSelected = false;                         // 是否被选中
    public RoleProperty roleProperty = new RoleProperty();  // 角色属性
    public int hp;                                          // 棋子血量
    public GameObject hpBar;                                // 棋子血条
    public GameObject damageBar;                            // 4 倍伤害（被围）标识
    public float hpScaleX;                                  // 血条满血时的横向缩放
    public bool isSurrounded;                               // 是否被完全包围（由 ChessPieceMgr 统一维护）
    public bool needCheckSurrounding = false;               // 历史字段（包围状态已由管理器统一维护）
    public List<Vector2> validMovePositions = new List<Vector2>();  // 可移动的空位置
    // ===== 序列化字段结束 =====

    // ===== 表现层引用（所有角色共用一个棋子预制体，生成时按角色换图换动画，见 PieceArt） =====
    public SpriteRenderer bodyRenderer;     // 角色立绘
    public SpriteRenderer baseRenderer;     // 底座（可选，没有配置底座图时不显示）
    public SpriteRenderer surroundRenderer; // 被围标识

    // ===== 以下为运行时状态（不序列化，由 ChessPieceMgr 维护） =====
    internal bool registered;           // 是否已注册进 ChessPieceMgr
    internal int cellIndex = -1;        // 占据的棋盘格子索引（-1 表示未入索引）
    internal float nextAttackTime;      // 下一次攻击的时间点（<= 0 表示尚未激活）
    internal bool hpDirty;              // 血条是否需要刷新
    private bool damageBarVisible;      // 4 倍伤害标识当前是否显示

    // 帧序列动画状态（替代每个棋子一个 Animator，由 ChessPieceMgr 统一按时间推进）
    private Sprite[] animFrames;            // 待机动画帧
    private float animInterval = 0.2f;      // 每帧停留时间
    private float animStartTime;            // 动画开始时间（用绝对时间算帧号，不会累积误差）
    private int animFrameIndex;             // 当前显示到第几帧
    private Sprite[] surroundFrames;        // 被围标识动画帧
    private float surroundInterval = 0.2f;
    private float surroundStartTime;
    private int surroundFrameIndex;

    // 用于储存可视化移动点的列表
    private readonly List<GameObject> pointObjects = new List<GameObject>();

    // 上下左右四个方向（提出来避免每次计算可移动点都重新分配数组）
    private static readonly Vector2[] Directions = { Vector2.up, Vector2.down, Vector2.left, Vector2.right };

    private void Awake()
    {
        damageBarVisible = false;
        if (damageBar != null) damageBar.SetActive(false);

        if (hpBar != null) hpScaleX = hpBar.transform.localScale.x;
    }

    private void OnEnable()
    {
        // 注册进统一管理器：阵营分组与棋盘索引都由它负责
        ChessPieceMgr.Instance.Register(this);
    }

    private void OnDisable()
    {
        ChessPieceMgr.Instance.Unregister(this);
        isSelected = false;     // 对象池复用：被回收时清掉选中标记
    }

    /// <summary>
    /// 装配待机动画帧（由 PieceArt 按配置调用）
    /// </summary>
    internal void SetAnimation(Sprite[] frames, float interval)
    {
        animFrames = frames;
        animInterval = interval > 0f ? interval : 0.2f;
        animFrameIndex = 0;
        animStartTime = Time.time;

        if (bodyRenderer == null || frames == null || frames.Length == 0) return;
        bodyRenderer.sprite = frames[0];
    }

    /// <summary>
    /// 装配被围标识的动画帧（由 PieceArt 按配置调用）
    /// </summary>
    internal void SetSurroundAnimation(Sprite[] frames, float interval)
    {
        surroundFrames = frames;
        surroundInterval = interval > 0f ? interval : 0.2f;
        surroundFrameIndex = 0;
        surroundStartTime = Time.time;

        if (surroundRenderer == null || frames == null || frames.Length == 0) return;
        surroundRenderer.sprite = frames[0];
    }

    /// <summary>
    /// 帧序列动画（由 ChessPieceMgr 每帧统一调用，替代原来的 Animator）。
    /// 帧号直接用「当前时间 - 开始时间」算出来，只有帧号变化时才写 Sprite，
    /// 所以 64 个棋子每帧总共也就几次赋值，开销可以忽略。
    /// </summary>
    internal void TickAnimation(float now)
    {
        Sprite[] frames = animFrames;
        if (frames != null && frames.Length > 1 && bodyRenderer != null)
        {
            int frame = (int)((now - animStartTime) / animInterval) % frames.Length;
            if (frame != animFrameIndex)
            {
                animFrameIndex = frame;
                bodyRenderer.sprite = frames[frame];
            }
        }

        // 被围标识只在显示的时候才需要动
        if (!damageBarVisible) return;

        Sprite[] surround = surroundFrames;
        if (surround != null && surround.Length > 1 && surroundRenderer != null)
        {
            int frame = (int)((now - surroundStartTime) / surroundInterval) % surround.Length;
            if (frame != surroundFrameIndex)
            {
                surroundFrameIndex = frame;
                surroundRenderer.sprite = surround[frame];
            }
        }
    }

    /// <summary>
    /// 初始化棋子数据（棋子生成后必须调用）：装美术、激活攻击计时与血条刷新
    /// </summary>
    public void SetData(T_Role role)
    {
        roleProperty.SetData(role);
        hp = roleProperty.f_hp;

        // 所有角色共用一个预制体：按角色换上对应的图片与动画
        PieceArt.Apply(this, roleProperty.f_icon, color);

        ChessPieceMgr mgr = ChessPieceMgr.Instance;
        mgr.ScheduleNextAttack(this);   // 与原来一致：先等一个攻击间隔再开始攻击
        mgr.MarkHpDirty(this);          // 血条交给管理器下一帧统一刷新
        mgr.Register(this);             // 阵营是实例化之后才赋值的，这里再同步一次
    }

    /// <summary>
    /// 选中棋子
    /// </summary>
    public void Select()
    {
        isSelected = true;
    }

    /// <summary>
    /// 取消选中棋子
    /// </summary>
    public void Deselect()
    {
        isSelected = false;
    }

    /// <summary>
    /// 移动棋子到目标位置（目标格已有棋子时不动）
    /// </summary>
    public void MoveTo(Vector3 targetPosition)
    {
        ChessPieceMgr mgr = ChessPieceMgr.Instance;
        if (!mgr.IsCellEmpty(targetPosition)) return;

        MusicMgr.Instance.PlaySound("史莱姆落子");
        transform.position = targetPosition;
        mgr.NotifyMoved(this);   // 刷新棋盘索引并触发包围状态重算
    }

    /// <summary>
    /// 受到伤害：扣血、刷新血条、阵亡结算都在这里收口
    /// </summary>
    public void ApplyDamage(int damage)
    {
        if (hp <= 0) return;

        hp -= damage;
        ChessPieceMgr.Instance.MarkHpDirty(this);

        if (hp <= 0)
        {
            hp = 0;
            ChessPieceMgr.Instance.Kill(this);
        }
    }

    /// <summary>
    /// 刷新血条（由 ChessPieceMgr 统一调度，只有血量变化过的棋子才会被调用）
    /// </summary>
    internal void RefreshHpBar()
    {
        if (hpBar == null || roleProperty.f_hp <= 0) return;

        float ratio = Mathf.Clamp01((float)hp / roleProperty.f_hp);
        hpBar.transform.localScale = new Vector3(hpScaleX * ratio, 1f, 1f);
    }

    /// <summary>
    /// 更新被围状态与 4 倍伤害标识（由 ChessPieceMgr 统一调用，状态没变化时不做任何事）
    /// </summary>
    internal void ApplySurroundedState(bool value)
    {
        if (damageBarVisible == value) return;

        damageBarVisible = value;
        isSurrounded = value;
        if (damageBar != null) damageBar.SetActive(value);

        if (value)
        {
            // 被围标识刚显示出来，动画从头一帧开始播
            surroundFrameIndex = 0;
            surroundStartTime = Time.time;
            if (surroundRenderer != null && surroundFrames != null && surroundFrames.Length > 0)
                surroundRenderer.sprite = surroundFrames[0];

            // 与原逻辑保持一致：被围住后清掉可移动点提示
            ClearValidMovePositions();
        }
    }

    /// <summary>
    /// 兼容旧接口：请求重算棋盘包围状态
    /// </summary>
    public void CheckIsSurround()
    {
        ChessPieceMgr.Instance.RequestBoardRefresh();
    }

    /// <summary>
    /// 显示可移动的空位置
    /// </summary>
    public void ShowValidMovePositions()
    {
        if (validMovePositions.Count == 0) return;

        ChessBoard board = ChessBoard.chessBoard;
        if (board == null || board.point == null) return;

        for (int i = 0; i < validMovePositions.Count; i++)
        {
            GameObject obj = Instantiate(board.point, validMovePositions[i], Quaternion.identity);
            pointObjects.Add(obj);
        }
    }

    /// <summary>
    /// 清除可移动的空位置
    /// </summary>
    public void ClearValidMovePositions()
    {
        validMovePositions.Clear();

        for (int i = 0; i < pointObjects.Count; i++)
        {
            if (pointObjects[i] != null) Destroy(pointObjects[i]);
        }
        pointObjects.Clear();
    }

    /// <summary>
    /// 计算棋子可移动的空位置（用棋盘索引做 O(1) 的占位判断）
    /// </summary>
    public void CalculateValidMovePositions()
    {
        validMovePositions.Clear();

        ChessBoard board = ChessBoard.chessBoard;
        if (board == null) return;

        ChessPieceMgr mgr = ChessPieceMgr.Instance;
        Vector2 startPosition = transform.position;
        int moveRange = roleProperty.f_move;

        for (int range = 1; range <= moveRange; range++)
        {
            float distance = board.cellSize * range;

            for (int d = 0; d < Directions.Length; d++)
            {
                Vector2 neighbor = startPosition + Directions[d] * distance;

                if (!board.IsPositionValid(neighbor)) continue;
                if (!mgr.IsCellEmpty(neighbor)) continue;

                validMovePositions.Add(neighbor);
            }
        }
    }
}

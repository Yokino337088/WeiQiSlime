using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 棋子美术配置表：把「角色图标名」映射到对应的图片与帧动画。
///
/// 之前每个角色（还有玩家/敌人两套）都有自己的棋子预制体，一共 56 个预制体，
/// 但它们只有图片和动画不一样，结构完全相同。现在场景上只用一个棋子预制体
/// （Resources/Object/棋子.prefab），生成棋子时按角色从这张表里取图片与动画帧装上去。
///
/// 为什么存帧序列而不是 AnimatorController：每个棋子挂一个 Animator，64 个棋子就是
/// 64 个动画状态机每帧都要跑，是棋子数量上来后最大的 CPU 开销之一。这些动画其实都是
/// 纯图片帧序列，改成由 ChessPieceMgr 统一按时间换 Sprite，开销几乎为零。
///
/// 表内容可以用编辑器工具重新生成：
/// 菜单「围棋史莱姆 / 生成棋子美术配置表」会扫描 Assets/Editor/ArtRes/playerpiece、
/// enemypiece 里现有的预制体，把图片与动画帧自动填进来（美术换了图重跑一次即可）。
/// </summary>
[CreateAssetMenu(fileName = "PieceArtConfig", menuName = "围棋史莱姆/棋子美术配置")]
public class PieceArtConfig : ScriptableObject
{
    /// <summary>
    /// 一个角色的美术资源
    /// </summary>
    [Serializable]
    public class Entry
    {
        [Tooltip("角色图标名，与 T_Role.f_icon 一致（也就是旧预制体的名字）")]
        public string icon;

        [Tooltip("角色立绘首帧（等于 frames[0]，方便在面板里直接看到图）")]
        public Sprite sprite;

        [Tooltip("待机动画的图片帧（按顺序）")]
        public Sprite[] frames;

        [Tooltip("待机动画每帧停留时间（秒）")]
        public float frameInterval = 0.2f;

        [Tooltip("底座图（可选，例如萌新的史莱姆底座），为空表示不用底座")]
        public Sprite baseSprite;

        [Tooltip("被围标识的动画帧（按顺序）")]
        public Sprite[] surroundFrames;

        [Tooltip("被围标识每帧停留时间（秒）")]
        public float surroundInterval = 0.142857f;
    }

    [Header("玩家方（Player / Player1）")]
    public List<Entry> playerEntries = new List<Entry>();

    [Header("敌方（Enemy / Player2）")]
    public List<Entry> enemyEntries = new List<Entry>();
}

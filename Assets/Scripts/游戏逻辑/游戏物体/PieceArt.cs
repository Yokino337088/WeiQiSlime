using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 棋子美术运行时服务：读配置表、按角色给棋子换图片与动画。
///
/// 配置表放在 Resources 下（Resources/PieceArtConfig.asset），
/// 表里引用的图片与动画会被一起打进包，不需要额外的 AssetBundle。
/// </summary>
public static class PieceArt
{
    /// <summary>配置表在 Resources 下的路径</summary>
    private const string ConfigResPath = "PieceArtConfig";

    private static PieceArtConfig config;
    private static Dictionary<string, PieceArtConfig.Entry> playerMap;
    private static Dictionary<string, PieceArtConfig.Entry> enemyMap;

    // 只对同一个角色报一次错，避免刷屏
    private static readonly HashSet<string> warnedIcons = new HashSet<string>();

    /// <summary>配置表（首次访问时加载）</summary>
    public static PieceArtConfig Config
    {
        get
        {
            if (config == null) LoadConfig();
            return config;
        }
    }

    private static void LoadConfig()
    {
        config = Resources.Load<PieceArtConfig>(ConfigResPath);
        playerMap = BuildMap(config != null ? config.playerEntries : null);
        enemyMap = BuildMap(config != null ? config.enemyEntries : null);

        if (config == null)
        {
            Debug.LogError($"找不到棋子美术配置表，请确认 {ConfigResPath}.asset 放在 Assets/Resources 下" +
                           "（可用菜单「围棋史莱姆/生成棋子美术配置表」生成）");
        }
    }

    private static Dictionary<string, PieceArtConfig.Entry> BuildMap(List<PieceArtConfig.Entry> entries)
    {
        Dictionary<string, PieceArtConfig.Entry> map = new Dictionary<string, PieceArtConfig.Entry>();
        if (entries == null) return map;

        for (int i = 0; i < entries.Count; i++)
        {
            PieceArtConfig.Entry entry = entries[i];
            if (entry == null || string.IsNullOrEmpty(entry.icon)) continue;

            map[entry.icon] = entry;   // 同名以最后一个为准
        }
        return map;
    }

    /// <summary>
    /// 按角色取美术数据；找不到返回 null
    /// </summary>
    public static PieceArtConfig.Entry GetEntry(string icon, ChessPiece.PieceFaction faction)
    {
        if (string.IsNullOrEmpty(icon)) return null;
        if (config == null) LoadConfig();

        Dictionary<string, PieceArtConfig.Entry> map = IsPlayerSide(faction) ? playerMap : enemyMap;
        if (map == null) return null;

        PieceArtConfig.Entry entry;
        return map.TryGetValue(icon, out entry) ? entry : null;
    }

    /// <summary>
    /// 阵营对应的美术表：玩家和玩家1 用玩家美术，敌人和玩家2 用敌人美术
    /// </summary>
    private static bool IsPlayerSide(ChessPiece.PieceFaction faction)
    {
        return faction == ChessPiece.PieceFaction.Player || faction == ChessPiece.PieceFaction.Player1;
    }

    /// <summary>
    /// 把角色对应的图片与动画装到棋子身上（棋子生成时调用）
    /// </summary>
    public static void Apply(ChessPiece piece, string icon, ChessPiece.PieceFaction faction)
    {
        if (piece == null) return;

        PieceArtConfig.Entry entry = GetEntry(icon, faction);
        if (entry == null)
        {
            if (warnedIcons.Add(icon))
            {
                Debug.LogError($"棋子美术配置里没有角色「{icon}」（阵营 {faction}），" +
                               "请用菜单「围棋史莱姆/生成棋子美术配置表」补上");
            }
            return;
        }

        // 角色立绘与待机动画（帧序列交给 ChessPieceMgr 统一驱动，不用 Animator）
        Sprite[] frames = entry.frames;
        if (piece.bodyRenderer != null && (frames == null || frames.Length == 0) && entry.sprite != null)
            piece.bodyRenderer.sprite = entry.sprite;
        piece.SetAnimation(frames, entry.frameInterval);

        // 底座：配置里没给底座图就隐藏（例如萌新有底座，其他角色没有）
        if (piece.baseRenderer != null) piece.baseRenderer.sprite = entry.baseSprite;

        // 被围标识的帧动画
        piece.SetSurroundAnimation(entry.surroundFrames, entry.surroundInterval);
    }
}

using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

/// <summary>
/// 棋子美术配置表生成工具。
///
/// 现在所有棋子共用一个预制体（Resources/Object/棋子.prefab），角色的图片与动画帧靠
/// Resources/PieceArtConfig.asset 这张表来查。这个工具会扫描旧的棋子预制体
/// （Assets/Editor/ArtRes/playerpiece、enemypiece），把每个角色的
/// 「立绘首帧 / 待机动画帧 / 底座 / 被围标识动画帧」提取出来写进表里。
///
/// 美术换图或新增角色后，重新跑一次菜单即可。
/// </summary>
public static class PieceArtConfigGenerator
{
    private const string PlayerPrefabDir = "Assets/Editor/ArtRes/playerpiece";
    private const string EnemyPrefabDir = "Assets/Editor/ArtRes/enemypiece";
    private const string ConfigPath = "Assets/Resources/PieceArtConfig.asset";

    [MenuItem("围棋史莱姆/生成棋子美术配置表")]
    public static void Generate()
    {
        PieceArtConfig config = AssetDatabase.LoadAssetAtPath<PieceArtConfig>(ConfigPath);
        if (config == null)
        {
            string dir = Path.GetDirectoryName(ConfigPath);
            if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir)) Directory.CreateDirectory(dir);

            config = ScriptableObject.CreateInstance<PieceArtConfig>();
            AssetDatabase.CreateAsset(config, ConfigPath);
        }

        config.playerEntries = Collect(PlayerPrefabDir);
        config.enemyEntries = Collect(EnemyPrefabDir);

        EditorUtility.SetDirty(config);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        Debug.Log($"棋子美术配置表已更新：玩家 {config.playerEntries.Count} 个，敌人 {config.enemyEntries.Count} 个（{ConfigPath}）");
    }

    /// <summary>
    /// 扫描一个目录下的棋子预制体，提取每个角色的美术数据
    /// </summary>
    private static List<PieceArtConfig.Entry> Collect(string dir)
    {
        List<PieceArtConfig.Entry> entries = new List<PieceArtConfig.Entry>();
        if (!Directory.Exists(dir)) return entries;

        foreach (string guid in AssetDatabase.FindAssets("t:Prefab", new[] { dir }))
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);
            if (prefab == null) continue;

            // 预制体上有两个 Animator：名字以「围」开头的那个是被围标识，另一个是角色待机动画
            Animator bodyAnimator = null;
            Animator surroundAnimator = null;
            foreach (Animator animator in prefab.GetComponentsInChildren<Animator>(true))
            {
                if (animator.gameObject.name.StartsWith("围")) surroundAnimator = animator;
                else if (bodyAnimator == null) bodyAnimator = animator;
            }
            if (bodyAnimator == null) continue;

            SpriteRenderer bodyRenderer = bodyAnimator.GetComponent<SpriteRenderer>();
            SpriteRenderer rootRenderer = prefab.GetComponent<SpriteRenderer>();

            PieceArtConfig.Entry entry = new PieceArtConfig.Entry
            {
                icon = Path.GetFileNameWithoutExtension(path),
                // 角色图不在根物体上时，根物体那张图就是底座（例如萌新）
                baseSprite = bodyAnimator.gameObject != prefab && rootRenderer != null ? rootRenderer.sprite : null,
            };

            entry.frames = ReadFrames(bodyAnimator.runtimeAnimatorController, out entry.frameInterval);
            entry.surroundFrames = surroundAnimator != null
                ? ReadFrames(surroundAnimator.runtimeAnimatorController, out entry.surroundInterval)
                : null;
            entry.sprite = entry.frames != null && entry.frames.Length > 0
                ? entry.frames[0]
                : (bodyRenderer != null ? bodyRenderer.sprite : null);

            entries.Add(entry);
        }

        entries.Sort((a, b) => string.CompareOrdinal(a.icon, b.icon));
        return entries;
    }

    /// <summary>
    /// 取动画控制器里的图片帧序列（这些动画都是纯图片帧序列，一帧一张 Sprite）。
    /// 被围标识用的是 AnimatorOverrideController，animationClips 拿到的已经是覆盖后的剪辑。
    /// </summary>
    private static Sprite[] ReadFrames(RuntimeAnimatorController controller, out float interval)
    {
        interval = 0.2f;
        if (controller == null) return null;

        AnimationClip[] clips = controller.animationClips;
        if (clips == null || clips.Length == 0 || clips[0] == null) return null;

        AnimationClip clip = clips[0];
        List<Sprite> frames = new List<Sprite>();

        foreach (EditorCurveBinding binding in AnimationUtility.GetObjectReferenceCurveBindings(clip))
        {
            ObjectReferenceKeyframe[] keys = AnimationUtility.GetObjectReferenceCurve(clip, binding);
            if (keys == null || keys.Length == 0) continue;

            for (int i = 0; i < keys.Length; i++)
            {
                Sprite sprite = keys[i].value as Sprite;
                if (sprite != null) frames.Add(sprite);
            }

            if (keys.Length > 1) interval = keys[1].time - keys[0].time;
        }

        return frames.Count > 0 ? frames.ToArray() : null;
    }
}

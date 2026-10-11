#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// 调试菜单：一键准备性能测试环境（全部关卡解锁 + 全部棋子解锁 + 一亿金币）。
///
/// 两套解锁机制都是从代码里实际读出来的：
///
/// 1) 关卡解锁 = T_Level.isShow
///    warList / adventureList / trainList 三张列表里装的是**全部**关卡
///    （GameLevelMgr.LoadLevelData 按 f_gklx 1战争/2冒险/3新手 分类装入），
///    每个关卡自己的 isShow 才是「是否已解锁」——过关时代码把下一关的 isShow 置 true，
///    关卡选择界面（ChooseLevelPanel）只创建 isShow == true 的按钮。
///
/// 2) 棋子解锁 = T_Role.isUnlock
///    GameDataMgr 的四张职业列表（closeCombatList / archerList / wizardList /
///    supplyTruckList，按 f_id 前缀 1~4 分类）里同样是全部角色，
///    isUnlock 才是「是否已解锁」（TavernPanel 看广告随机解锁就是把某个角色的
///    isUnlock 置 true 再 SaveRoleData）。
///
/// 存档位置：Application.persistentDataPath/Data/*.tang
///   游戏启动时 Main.ReadTheFile() 会读回来；若是**第一次启动**（PlayerPrefs 里没有
///   IsFirstLaunch），走的是不读档的分支，本工具会把这个键补上，保证存档能生效。
///
/// 只放在 Assets/Editor 下，不会打进包。
/// </summary>
public static class DebugCheatMenu
{
    /// <summary>测试用金币（一亿）</summary>
    public const long TestCoin = 100000000L;

    private const string MenuRoot = "围棋史莱姆/调试/";
    private const string FirstLaunchKey = "IsFirstLaunch";

    /// <summary>三张关卡列表的存档名；下标 + 1 就是 T_Level.f_gklx（1 战争 / 2 冒险 / 3 新手）</summary>
    private static readonly string[] LevelSaveKeys = { "warList", "adventureList", "trainList" };

    /// <summary>四张棋子列表的存档名；下标 + 1 就是 T_Role.f_id 的前缀（1 近战 / 2 弓箭 / 3 法师 / 4 补给车）</summary>
    private static readonly string[] RoleSaveKeys = { "closeCombatList", "archerList", "wizardList", "supplyTruckList" };

    /// <summary>编辑器下只需要读一次表</summary>
    private static bool tablesLoaded;

    [MenuItem(MenuRoot + "一键准备性能测试环境（全解锁 + 一亿金币）", false, 1)]
    public static void PrepareTestEnvironment()
    {
        int levels = UnlockAllLevels();
        int roles = UnlockAllRoles();
        long coin = GiveCoin(TestCoin);

        Debug.Log($"[调试] 测试环境已就绪：新解锁 {levels} 个关卡、{roles} 个棋子，金币 {coin:N0}。" +
                  (Application.isPlaying
                      ? "（已同步到正在运行的游戏）"
                      : "（存档已写好，重新运行游戏后生效）"));
    }

    [MenuItem(MenuRoot + "只解锁全部关卡", false, 2)]
    public static void UnlockAllLevelsMenu()
    {
        int levels = UnlockAllLevels();
        Debug.Log($"[调试] 新解锁 {levels} 个关卡");
    }

    [MenuItem(MenuRoot + "只解锁全部棋子", false, 3)]
    public static void UnlockAllRolesMenu()
    {
        int roles = UnlockAllRoles();
        Debug.Log($"[调试] 新解锁 {roles} 个棋子");
    }

    [MenuItem(MenuRoot + "只给一亿金币", false, 4)]
    public static void GiveCoinMenu()
    {
        long coin = GiveCoin(TestCoin);
        Debug.Log($"[调试] 金币已设为 {coin:N0}");
    }

    #region 关卡解锁

    /// <summary>
    /// 把所有关卡的 isShow 置 true 并存档；返回本次新解锁的关卡数。
    /// 运行中走内存里的列表（不重新读表，否则会换掉 T_Level 实例，
    /// 破坏 GameLevelMgr 里依赖引用相等的 Contains 判断）。
    /// </summary>
    private static int UnlockAllLevels()
    {
        if (!EnsureTables()) return 0;

        int unlocked = 0;

        if (Application.isPlaying)
        {
            GameLevelMgr mgr = GameLevelMgr.Instance;
            unlocked += UnlockLevelList(mgr.warList);
            unlocked += UnlockLevelList(mgr.adventureList);
            unlocked += UnlockLevelList(mgr.trainList);
            mgr.SaveLevelData();
        }
        else
        {
            for (int i = 0; i < LevelSaveKeys.Length; i++)
            {
                List<T_Level> list = BinaryDataMgr.Instance.Load<List<T_Level>>(LevelSaveKeys[i]);
                if (list == null) list = new List<T_Level>();
                list.RemoveAll(level => level == null);

                // 补进表里属于这一类、但存档里还没有的关卡（已存在的条目带着 minSpend 等进度数据）
                HashSet<string> exist = new HashSet<string>();
                for (int k = 0; k < list.Count; k++) exist.Add(list[k].f_gkid);

                foreach (T_Level level in BinaryDataMgr.Instance.GetTable<T_LevelContainer>().dataDic.Values)
                {
                    if (level == null || level.f_gklx != i + 1) continue;
                    if (exist.Add(level.f_gkid)) list.Add(level);
                }

                unlocked += UnlockLevelList(list);
                list.Sort(CompareLevelId);
                BinaryDataMgr.Instance.Save(list, LevelSaveKeys[i]);
            }
        }

        return unlocked;
    }

    private static int UnlockLevelList(List<T_Level> list)
    {
        if (list == null) return 0;

        int changed = 0;
        for (int i = 0; i < list.Count; i++)
        {
            T_Level level = list[i];
            if (level == null || level.isShow) continue;

            level.isShow = true;
            changed++;
        }
        return changed;
    }

    /// <summary>
    /// 关卡 id（形如 "1_10"）的自然排序，让关卡列表按顺序显示
    /// </summary>
    private static int CompareLevelId(T_Level a, T_Level b)
    {
        if (a == null || b == null) return 0;

        string[] pa = (a.f_gkid ?? string.Empty).Split('_');
        string[] pb = (b.f_gkid ?? string.Empty).Split('_');
        int len = Mathf.Min(pa.Length, pb.Length);

        for (int i = 0; i < len; i++)
        {
            int va, vb;
            bool oa = int.TryParse(pa[i], out va);
            bool ob = int.TryParse(pb[i], out vb);

            if (oa && ob)
            {
                if (va != vb) return va.CompareTo(vb);
            }
            else
            {
                int c = string.CompareOrdinal(pa[i], pb[i]);
                if (c != 0) return c;
            }
        }
        return pa.Length.CompareTo(pb.Length);
    }

    #endregion

    #region 棋子解锁

    /// <summary>
    /// 把所有角色的 isUnlock 置 true 并存档；返回本次新解锁的棋子数
    /// </summary>
    private static int UnlockAllRoles()
    {
        if (!EnsureTables()) return 0;

        int unlocked = 0;
        bool playing = Application.isPlaying;

        for (int type = 1; type <= 4; type++)
        {
            List<T_Role> list = playing
                ? GetRuntimeRoleList(GameDataMgr.Instance, type)
                : BinaryDataMgr.Instance.Load<List<T_Role>>(RoleSaveKeys[type - 1]);

            if (list == null)
            {
                if (playing) continue;
                list = new List<T_Role>();
            }

            list.RemoveAll(role => role == null);

            // 补进表里属于该职业、但列表里还没有的角色
            HashSet<string> exist = new HashSet<string>();
            for (int i = 0; i < list.Count; i++) exist.Add(list[i].f_id);

            foreach (T_Role role in BinaryDataMgr.Instance.GetTable<T_RoleContainer>().dataDic.Values)
            {
                if (role == null || string.IsNullOrEmpty(role.f_id)) continue;
                if (GetRoleType(role) != type) continue;
                if (exist.Add(role.f_id)) list.Add(role);
            }

            unlocked += UnlockRoleList(list);

            // 运行中由 GameDataMgr.SaveRoleData 统一写回，编辑器下逐个写
            if (!playing) BinaryDataMgr.Instance.Save(list, RoleSaveKeys[type - 1]);
        }

        if (playing) GameDataMgr.Instance.SaveRoleData();

        return unlocked;
    }

    private static int UnlockRoleList(List<T_Role> list)
    {
        if (list == null) return 0;

        int changed = 0;
        for (int i = 0; i < list.Count; i++)
        {
            T_Role role = list[i];
            if (role == null || role.isUnlock) continue;

            role.isUnlock = true;
            changed++;
        }
        return changed;
    }

    private static List<T_Role> GetRuntimeRoleList(GameDataMgr mgr, int type)
    {
        switch (type)
        {
            case 1: return mgr.closeCombatList;
            case 2: return mgr.archerList;
            case 3: return mgr.wizardList;
            case 4: return mgr.supplyTruckList;
            default: return null;
        }
    }

    /// <summary>
    /// 角色所属职业：取 f_id（形如 "1_11"）下划线前的数字，1近战 2弓箭 3法师 4补给车
    /// </summary>
    private static int GetRoleType(T_Role role)
    {
        if (role == null || string.IsNullOrEmpty(role.f_id)) return 0;

        int sep = role.f_id.IndexOf('_');
        string head = sep > 0 ? role.f_id.Substring(0, sep) : role.f_id;

        int type;
        return int.TryParse(head, out type) ? type : 0;
    }

    #endregion

    /// <summary>
    /// 设置金币：运行中改内存并让 GameDataMgr 存档，否则直接写 playerData 存档
    /// </summary>
    private static long GiveCoin(long coin)
    {
        if (Application.isPlaying)
        {
            GameDataMgr.Instance.playCoin = coin;
            GameDataMgr.Instance.SavePlayerCoin();
        }
        else
        {
            PlayerData data = BinaryDataMgr.Instance.Load<PlayerData>("playerData");
            if (data == null) data = new PlayerData();

            data.playerCoin = coin;
            BinaryDataMgr.Instance.Save(data, "playerData");
        }
        return coin;
    }

    /// <summary>
    /// 确保角色表 / 关卡表已加载（编辑器里没有游戏运行时需要自己读一次表）
    /// </summary>
    private static bool EnsureTables()
    {
        // Play 模式下游戏已经读过表了，这里绝不能再读一次——那会换掉一批实例，
        // 导致 GameLevelMgr / TavernPanel 里依赖引用相等的判断失效
        if (!Application.isPlaying && !tablesLoaded)
        {
            BinaryDataMgr.Instance.InitData();
            tablesLoaded = true;
        }

        T_LevelContainer levelTable = BinaryDataMgr.Instance.GetTable<T_LevelContainer>();
        T_RoleContainer roleTable = BinaryDataMgr.Instance.GetTable<T_RoleContainer>();

        if (levelTable == null || roleTable == null)
        {
            Debug.LogError("[调试] 读不到数据表，确认 Assets/StreamingAssets/Binary/ 下的 " +
                           "T_Level.tang、T_Role.tang 存在");
            return false;
        }

        // 第一次启动的分支不读档，补上这个键，保证下次启动会读存档
        if (!PlayerPrefs.HasKey(FirstLaunchKey))
        {
            PlayerPrefs.SetInt(FirstLaunchKey, 1);
            PlayerPrefs.Save();
            Debug.Log("[调试] 已补上 IsFirstLaunch 键（否则游戏第一次启动不会读存档）");
        }

        return true;
    }
}
#endif

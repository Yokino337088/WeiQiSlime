using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum E_RoleType
{
    CloseCombat,
    Archer,
    Wizard,
    SupplyTruck
}

public class GameDataMgr : SingletonAutoMono<GameDataMgr>
{
    //玩家金币
    public long playCoin = 100;
    //敌人金币
    public int AICoin;

    /// <summary>
    /// 玩家1的金币
    /// </summary>
    public int player1Coin;
    /// <summary>
    /// 玩家2的金币
    /// </summary>
    public int player2Coin;

    //玩家行动力
    public int playerMobility = 0;
    //敌人行动力
    public int enemyMobility = 0;

    /// <summary>
    /// 玩家在对局中花费的金币数
    /// </summary>
    public int playerSpend;

    /// <summary>
    /// 玩家回合，是玩家1还是玩家2
    /// </summary>
    public int PlayerRound;

    public bool isload = false;

    public bool isShowTavernPanel = false;

    /// <summary>
    /// 最少的金币数
    /// </summary>
    public int MinLevelSpend
    {
        get
        {
            if(LoadMinSpendData(GameLevelMgr.Instance.nowLevelInfo)!=null)
                GameLevelMgr.Instance.nowLevelInfo.minSpend = LoadMinSpendData(GameLevelMgr.Instance.nowLevelInfo).minSpend;
            if (playerSpend < GameLevelMgr.Instance.nowLevelInfo.minSpend)
            {
                GameLevelMgr.Instance.nowLevelInfo.minSpend = playerSpend;
                //对数据进行存档
                SaveMinSpendData(GameLevelMgr.Instance.nowLevelInfo);
                return LoadMinSpendData(GameLevelMgr.Instance.nowLevelInfo).minSpend;
            }
            return LoadMinSpendData(GameLevelMgr.Instance.nowLevelInfo).minSpend;
        }
    }

    //装载角色数据的列表
    public List<T_Role> closeCombatList = new List<T_Role>();
    public List<T_Role> archerList = new List<T_Role>();
    public List<T_Role> wizardList = new List<T_Role>();
    public List<T_Role> supplyTruckList = new List<T_Role>();

    //计时器
    private float playerMobilityTimer = 0f;
    private float enemyMobilityTimer = 0f;

    private float delayTime = 1.5f;

    private void Update()
    {
        //当处于游戏场景的时候才去增加行动力
        if (SceneManager.GetActiveScene().buildIndex == 1|| SceneManager.GetActiveScene().buildIndex == 3)
        {

            // 更新敌人行动力计时器
            enemyMobilityTimer += Time.deltaTime;
            if (enemyMobilityTimer >= delayTime)
            {
                enemyMobilityTimer = 0f; // 重置计时器
                IncrementEnemyMobility();
            }

            // 更新玩家行动力计时器
            playerMobilityTimer += Time.deltaTime;
            if (playerMobilityTimer >= delayTime)
            {
                playerMobilityTimer = 0f; // 重置计时器
                IncrementPlayerMobility();
            }


        }
    }

    /// <summary>
    /// 增加玩家行动力
    /// </summary>
    private void IncrementPlayerMobility()
    {
        playerMobility++;

        if (playerMobility >= 5)
            playerMobility = 5;

        UIMgr.Instance.GetPanel<GamePanel>((panel) =>
        {
            panel.ChangePlayerMobility(playerMobility);
        });
    }



    /// <summary>
    /// 增加敌人行动力
    /// </summary>
    private void IncrementEnemyMobility()
    {
        enemyMobility++;

        if (enemyMobility >= 5)
            enemyMobility = 5;

        UIMgr.Instance.GetPanel<GamePanel>((panel) =>
        {
            panel.ChangeEnemyMobility(enemyMobility);
        });
    }

    /// <summary>
    /// 读取玩家的金币存档
    /// </summary>
    public void LoadPlayerCoin()
    {
        if(BinaryDataMgr.Instance.Load<PlayerData>("playerData")!=null)
            playCoin = BinaryDataMgr.Instance.Load<PlayerData>("playerData").playerCoin;
    }

    /// <summary>
    /// 储存玩家的金币
    /// </summary>
    public void SavePlayerCoin()
    {
        PlayerData playerData = new PlayerData();
        playerData.playerCoin = playCoin;
        BinaryDataMgr.Instance.Save(playerData, "playerData");
    }

    /// <summary>
    /// 加载表中的角色数据
    /// </summary>
    public void LoadRoleData()
    {
        Dictionary<string, T_Role> roleContainer = BinaryDataMgr.Instance.GetTable<T_RoleContainer>().dataDic;
        int[] ints = new int[2];

        foreach (var key in roleContainer.Keys)
        {
            ints = TextUtil.SplitStrToIntArr(key, 7);
            switch (ints[0])
            {
                case 1:
                    closeCombatList.Add(roleContainer[key]);
                    break;
                case 2:
                    archerList.Add(roleContainer[key]);
                    break;
                case 3:
                    wizardList.Add(roleContainer[key]);
                    break;
                case 4:
                    supplyTruckList.Add(roleContainer[key]);
                    break;
            }
        }
    }

    /// <summary>
    /// 对角色数据进行存档
    /// </summary>
    public void SaveRoleData()
    {
        BinaryDataMgr.Instance.Save(closeCombatList, "closeCombatList");
        BinaryDataMgr.Instance.Save(archerList, "archerList");
        BinaryDataMgr.Instance.Save(wizardList, "wizardList");
        BinaryDataMgr.Instance.Save(supplyTruckList, "supplyTruckList");
    }

    /// <summary>
    /// 对角色数据进行读档
    /// </summary>
    public void GetRoleData()
    {
        if(BinaryDataMgr.Instance.Load<List<T_Role>>("closeCombatList")!=null)
            closeCombatList = BinaryDataMgr.Instance.Load<List<T_Role>>("closeCombatList");
        if(BinaryDataMgr.Instance.Load<List<T_Role>>("archerList") != null)
            archerList = BinaryDataMgr.Instance.Load<List<T_Role>>("archerList");
        if(BinaryDataMgr.Instance.Load<List<T_Role>>("wizardList") != null)
            wizardList = BinaryDataMgr.Instance.Load<List<T_Role>>("wizardList");
        if(BinaryDataMgr.Instance.Load<List<T_Role>>("supplyTruckList") != null)
            supplyTruckList = BinaryDataMgr.Instance.Load<List<T_Role>>("supplyTruckList");
    }

    /// <summary>
    /// 对最小的金币数进行存档
    /// </summary>
    /// <param name="levelInfo"></param>
    public void SaveMinSpendData(T_Level levelInfo)
    {

        if (levelInfo.f_gklx == 1)
        {
            switch (levelInfo.f_gkname)
            {
                case "战争关卡1":
                    BinaryDataMgr.Instance.Save(levelInfo, "warMinSpend1");
                    break;
                case "战争关卡2":
                    BinaryDataMgr.Instance.Save(levelInfo, "warMinSpend2");
                    break;
                case "战争关卡3":
                    BinaryDataMgr.Instance.Save(levelInfo, "warMinSpend3");
                    break;
                case "战争关卡4":
                    BinaryDataMgr.Instance.Save(levelInfo, "warMinSpend4");
                    break;
                case "战争关卡5":
                    BinaryDataMgr.Instance.Save(levelInfo, "warMinSpend5");
                    break;
                case "战争关卡6":
                    BinaryDataMgr.Instance.Save(levelInfo, "warMinSpend6");
                    break;
                case "战争关卡7":
                    BinaryDataMgr.Instance.Save(levelInfo, "warMinSpend7");
                    break;
                case "战争关卡8":
                    BinaryDataMgr.Instance.Save(levelInfo, "warMinSpend8");
                    break;
                case "战争关卡9":
                    BinaryDataMgr.Instance.Save(levelInfo, "warMinSpend9");
                    break;
                case "战争关卡10":
                    BinaryDataMgr.Instance.Save(levelInfo, "warMinSpend10");
                    break;
                case "战争关卡11":
                    BinaryDataMgr.Instance.Save(levelInfo, "warMinSpend11");
                    break;
                case "战争关卡12":
                    BinaryDataMgr.Instance.Save(levelInfo, "warMinSpend12");
                    break;
                case "战争关卡13":
                    BinaryDataMgr.Instance.Save(levelInfo, "warMinSpend13");
                    break;
                case "战争关卡14":
                    BinaryDataMgr.Instance.Save(levelInfo, "warMinSpend14");
                    break;
                case "战争关卡15":
                    BinaryDataMgr.Instance.Save(levelInfo, "warMinSpend15");
                    break;
                case "战争关卡16":
                    BinaryDataMgr.Instance.Save(levelInfo, "warMinSpend16");
                    break;
                case "战争关卡17":
                    BinaryDataMgr.Instance.Save(levelInfo, "warMinSpend17");
                    break;
                case "战争关卡18":
                    BinaryDataMgr.Instance.Save(levelInfo, "warMinSpend18");
                    break;
                case "战争关卡19":
                    BinaryDataMgr.Instance.Save(levelInfo, "warMinSpend19");
                    break;
                case "战争关卡20":
                    BinaryDataMgr.Instance.Save(levelInfo, "warMinSpend20");
                    break;
                case "战争关卡21":
                    BinaryDataMgr.Instance.Save(levelInfo, "warMinSpend21");
                    break;
                case "战争关卡22":
                    BinaryDataMgr.Instance.Save(levelInfo, "warMinSpend22");
                    break;
                case "战争关卡23":
                    BinaryDataMgr.Instance.Save(levelInfo, "warMinSpend23");
                    break;
                case "战争关卡24":
                    BinaryDataMgr.Instance.Save(levelInfo, "warMinSpend24");
                    break;
                case "战争关卡25":
                    BinaryDataMgr.Instance.Save(levelInfo, "warMinSpend25");
                    break;
                case "战争关卡26":
                    BinaryDataMgr.Instance.Save(levelInfo, "warMinSpend26");
                    break;
                case "战争关卡27":
                    BinaryDataMgr.Instance.Save(levelInfo, "warMinSpend27");
                    break;
                case "战争关卡28":
                    BinaryDataMgr.Instance.Save(levelInfo, "warMinSpend28");
                    break;
                case "战争关卡29":
                    BinaryDataMgr.Instance.Save(levelInfo, "warMinSpend29");
                    break;
                case "战争关卡30":
                    BinaryDataMgr.Instance.Save(levelInfo, "warMinSpend30");
                    break;
                case "战争关卡31":
                    BinaryDataMgr.Instance.Save(levelInfo, "warMinSpend31");
                    break;
                case "战争关卡32":
                    BinaryDataMgr.Instance.Save(levelInfo, "warMinSpend32");
                    break;
                case "战争关卡33":
                    BinaryDataMgr.Instance.Save(levelInfo, "warMinSpend33");
                    break;
                case "战争关卡34":
                    BinaryDataMgr.Instance.Save(levelInfo, "warMinSpend34");
                    break;
                case "战争关卡35":
                    BinaryDataMgr.Instance.Save(levelInfo, "warMinSpend35");
                    break;
                case "战争关卡36":
                    BinaryDataMgr.Instance.Save(levelInfo, "warMinSpend36");
                    break;
                case "战争关卡37":
                    BinaryDataMgr.Instance.Save(levelInfo, "warMinSpend37");
                    break;
                case "战争关卡38":
                    BinaryDataMgr.Instance.Save(levelInfo, "warMinSpend38");
                    break;
                case "战争关卡39":
                    BinaryDataMgr.Instance.Save(levelInfo, "warMinSpend39");
                    break;
                case "战争关卡40":
                    BinaryDataMgr.Instance.Save(levelInfo, "warMinSpend40");
                    break;
                case "战争关卡41":
                    BinaryDataMgr.Instance.Save(levelInfo, "warMinSpend41");
                    break;
                case "战争关卡42":
                    BinaryDataMgr.Instance.Save(levelInfo, "warMinSpend42");
                    break;
                case "战争关卡43":
                    BinaryDataMgr.Instance.Save(levelInfo, "warMinSpend43");
                    break;
                case "战争关卡44":
                    BinaryDataMgr.Instance.Save(levelInfo, "warMinSpend44");
                    break;
                case "战争关卡45":
                    BinaryDataMgr.Instance.Save(levelInfo, "warMinSpend45");
                    break;
                case "战争关卡46":
                    BinaryDataMgr.Instance.Save(levelInfo, "warMinSpend46");
                    break;
                case "战争关卡47":
                    BinaryDataMgr.Instance.Save(levelInfo, "warMinSpend47");
                    break;
                case "战争关卡48":
                    BinaryDataMgr.Instance.Save(levelInfo, "warMinSpend48");
                    break;
                case "战争关卡49":
                    BinaryDataMgr.Instance.Save(levelInfo, "warMinSpend49");
                    break;
                case "战争关卡50":
                    BinaryDataMgr.Instance.Save(levelInfo, "warMinSpend50");
                    break;
            }
        }
        else
        {
            switch (levelInfo.f_gkname)
            {
                case "冒险关卡1":
                    BinaryDataMgr.Instance.Save(levelInfo, "adventureMinSpend1");
                    break;
                case "冒险关卡2":
                    BinaryDataMgr.Instance.Save(levelInfo, "adventureMinSpend2");
                    break;
                case "冒险关卡3":
                    BinaryDataMgr.Instance.Save(levelInfo, "adventureMinSpend3");
                    break;
                case "冒险关卡4":
                    BinaryDataMgr.Instance.Save(levelInfo, "adventureMinSpend4");
                    break;
                case "冒险关卡5":
                    BinaryDataMgr.Instance.Save(levelInfo, "adventureMinSpend5");
                    break;
                case "冒险关卡6":
                    BinaryDataMgr.Instance.Save(levelInfo, "adventureMinSpend6");
                    break;
                case "冒险关卡7":
                    BinaryDataMgr.Instance.Save(levelInfo, "adventureMinSpend7");
                    break;
                case "冒险关卡8":
                    BinaryDataMgr.Instance.Save(levelInfo, "adventureMinSpend8");
                    break;
                case "冒险关卡9":
                    BinaryDataMgr.Instance.Save(levelInfo, "adventureMinSpend9");
                    break;
                case "冒险关卡10":
                    BinaryDataMgr.Instance.Save(levelInfo, "adventureMinSpend10");
                    break;
                case "冒险关卡11":
                    BinaryDataMgr.Instance.Save(levelInfo, "adventureMinSpend11");
                    break;
                case "冒险关卡12":
                    BinaryDataMgr.Instance.Save(levelInfo, "adventureMinSpend12");
                    break;
                case "冒险关卡13":
                    BinaryDataMgr.Instance.Save(levelInfo, "adventureMinSpend13");
                    break;
                case "冒险关卡14":
                    BinaryDataMgr.Instance.Save(levelInfo, "adventureMinSpend14");
                    break;
                case "冒险关卡15":
                    BinaryDataMgr.Instance.Save(levelInfo, "adventureMinSpend15");
                    break;
                case "冒险关卡16":
                    BinaryDataMgr.Instance.Save(levelInfo, "adventureMinSpend16");
                    break;
                case "冒险关卡17":
                    BinaryDataMgr.Instance.Save(levelInfo, "adventureMinSpend17");
                    break;
                case "冒险关卡18":
                    BinaryDataMgr.Instance.Save(levelInfo, "adventureMinSpend18");
                    break;
                case "冒险关卡19":
                    BinaryDataMgr.Instance.Save(levelInfo, "adventureMinSpend19");
                    break;
                case "冒险关卡20":
                    BinaryDataMgr.Instance.Save(levelInfo, "adventureMinSpend20");
                    break;
                case "冒险关卡21":
                    BinaryDataMgr.Instance.Save(levelInfo, "adventureMinSpend21");
                    break;

            }
        }
    }

    public T_Level LoadMinSpendData(T_Level levelInfo)
    {
        if (levelInfo.f_gklx == 1)
        {
            switch (levelInfo.f_gkname)
            {
                case "战争关卡1":
                    return BinaryDataMgr.Instance.Load<T_Level>("warMinSpend1");                    
                case "战争关卡2":
                    return BinaryDataMgr.Instance.Load<T_Level>("warMinSpend2");                    
                case "战争关卡3":
                    return BinaryDataMgr.Instance.Load<T_Level>("warMinSpend3");
                case "战争关卡4":
                    return BinaryDataMgr.Instance.Load<T_Level>("warMinSpend4");                    
                case "战争关卡5":
                    return BinaryDataMgr.Instance.Load<T_Level>("warMinSpend5");
                case "战争关卡6":
                    return BinaryDataMgr.Instance.Load<T_Level>("warMinSpend6");
                case "战争关卡7":
                    return BinaryDataMgr.Instance.Load<T_Level>("warMinSpend7");
                case "战争关卡8":
                    return BinaryDataMgr.Instance.Load<T_Level>("warMinSpend8");
                case "战争关卡9":
                    return BinaryDataMgr.Instance.Load<T_Level>("warMinSpend9");
                case "战争关卡10":
                    return BinaryDataMgr.Instance.Load<T_Level>("warMinSpend10");
                case "战争关卡11":
                    return BinaryDataMgr.Instance.Load<T_Level>("warMinSpend11");
                case "战争关卡12":
                    return BinaryDataMgr.Instance.Load<T_Level>("warMinSpend12");
                case "战争关卡13":
                    return BinaryDataMgr.Instance.Load<T_Level>("warMinSpend13");
                case "战争关卡14":
                    return BinaryDataMgr.Instance.Load<T_Level>("warMinSpend14");
                case "战争关卡15":
                    return BinaryDataMgr.Instance.Load<T_Level>("warMinSpend15");
                case "战争关卡16":
                    return BinaryDataMgr.Instance.Load<T_Level>("warMinSpend16");
                case "战争关卡17":
                    return BinaryDataMgr.Instance.Load<T_Level>("warMinSpend17");
                case "战争关卡18":
                    return BinaryDataMgr.Instance.Load<T_Level>("warMinSpend18");
                case "战争关卡19":
                    return BinaryDataMgr.Instance.Load<T_Level>("warMinSpend19");
                case "战争关卡20":
                    return BinaryDataMgr.Instance.Load<T_Level>("warMinSpend20");
                case "战争关卡21":
                    return BinaryDataMgr.Instance.Load<T_Level>("warMinSpend21");
                case "战争关卡22":
                    return BinaryDataMgr.Instance.Load<T_Level>("warMinSpend22");                    
                case "战争关卡23":
                    return BinaryDataMgr.Instance.Load<T_Level>("warMinSpend23");   
                case "战争关卡24":
                    return BinaryDataMgr.Instance.Load<T_Level>("warMinSpend24");
                case "战争关卡25":
                    return BinaryDataMgr.Instance.Load<T_Level>("warMinSpend25");
                case "战争关卡26":
                    return BinaryDataMgr.Instance.Load<T_Level>("warMinSpend26");
                case "战争关卡27":
                    return BinaryDataMgr.Instance.Load<T_Level>("warMinSpend27");
                case "战争关卡28":
                    return BinaryDataMgr.Instance.Load<T_Level>("warMinSpend28");
                case "战争关卡29":
                    return BinaryDataMgr.Instance.Load<T_Level>("warMinSpend29");
                case "战争关卡30":
                    return BinaryDataMgr.Instance.Load<T_Level>("warMinSpend30");
                case "战争关卡31":
                    return BinaryDataMgr.Instance.Load<T_Level>("warMinSpend31");
                case "战争关卡32":
                    return BinaryDataMgr.Instance.Load<T_Level>("warMinSpend32");
                case "战争关卡33":
                    return BinaryDataMgr.Instance.Load<T_Level>("warMinSpend33");
                case "战争关卡34":
                    return BinaryDataMgr.Instance.Load<T_Level>("warMinSpend34");
                case "战争关卡35":
                    return BinaryDataMgr.Instance.Load<T_Level>("warMinSpend35");
                case "战争关卡36":
                    return BinaryDataMgr.Instance.Load<T_Level>("warMinSpend36");
                case "战争关卡37":
                    return BinaryDataMgr.Instance.Load<T_Level>("warMinSpend37");
                case "战争关卡38":
                    return BinaryDataMgr.Instance.Load<T_Level>("warMinSpend38");
                case "战争关卡39":
                    return BinaryDataMgr.Instance.Load<T_Level>("warMinSpend39");
                case "战争关卡40":
                    return BinaryDataMgr.Instance.Load<T_Level>("warMinSpend40");
                case "战争关卡41":
                    return BinaryDataMgr.Instance.Load<T_Level>("warMinSpend41");
                case "战争关卡42":
                    return BinaryDataMgr.Instance.Load<T_Level>("warMinSpend42");
                case "战争关卡43":
                    return BinaryDataMgr.Instance.Load<T_Level>("warMinSpend43");
                case "战争关卡44":
                    return BinaryDataMgr.Instance.Load<T_Level>("warMinSpend44");
                case "战争关卡45":
                    return BinaryDataMgr.Instance.Load<T_Level>("warMinSpend45");
                case "战争关卡46":
                    return BinaryDataMgr.Instance.Load<T_Level>("warMinSpend46");
                case "战争关卡47":
                    return BinaryDataMgr.Instance.Load<T_Level>("warMinSpend47");
                case "战争关卡48":
                    return BinaryDataMgr.Instance.Load<T_Level>("warMinSpend48");
                case "战争关卡49":
                    return BinaryDataMgr.Instance.Load<T_Level>("warMinSpend49");
                case "战争关卡50":
                    return BinaryDataMgr.Instance.Load<T_Level>("warMinSpend50");

            }
        }
        else
        {
            switch (levelInfo.f_gkname)
            {
                case "冒险关卡1":
                    return BinaryDataMgr.Instance.Load<T_Level>("adventureMinSpend1");                    
                case "冒险关卡2":
                    return BinaryDataMgr.Instance.Load<T_Level>("adventureMinSpend2");
                case "冒险关卡3":
                    return BinaryDataMgr.Instance.Load<T_Level>("adventureMinSpend3");
                case "冒险关卡4":
                    return BinaryDataMgr.Instance.Load<T_Level>("adventureMinSpend4");
                case "冒险关卡5":
                    return BinaryDataMgr.Instance.Load<T_Level>("adventureMinSpend5");
                case "冒险关卡6":
                    return BinaryDataMgr.Instance.Load<T_Level>("adventureMinSpend6");
                case "冒险关卡7":
                    return BinaryDataMgr.Instance.Load<T_Level>("adventureMinSpend7");
                case "冒险关卡8":
                    return BinaryDataMgr.Instance.Load<T_Level>("adventureMinSpend8");
                case "冒险关卡9":
                    return BinaryDataMgr.Instance.Load<T_Level>("adventureMinSpend9");
                case "冒险关卡10":
                    return BinaryDataMgr.Instance.Load<T_Level>("adventureMinSpend10");
                case "冒险关卡11":
                    return BinaryDataMgr.Instance.Load<T_Level>("adventureMinSpend11");
                case "冒险关卡12":
                    return BinaryDataMgr.Instance.Load<T_Level>("adventureMinSpend12");
                case "冒险关卡13":
                    return BinaryDataMgr.Instance.Load<T_Level>("adventureMinSpend13");
                case "冒险关卡14":
                    return BinaryDataMgr.Instance.Load<T_Level>("adventureMinSpend14");
                case "冒险关卡15":
                    return BinaryDataMgr.Instance.Load<T_Level>("adventureMinSpend15");
                case "冒险关卡16":
                    return BinaryDataMgr.Instance.Load<T_Level>("adventureMinSpend16");
                case "冒险关卡17":
                    return BinaryDataMgr.Instance.Load<T_Level>("adventureMinSpend17");
                case "冒险关卡18":
                    return BinaryDataMgr.Instance.Load<T_Level>("adventureMinSpend18");
                case "冒险关卡19":
                    return BinaryDataMgr.Instance.Load<T_Level>("adventureMinSpend19");
                case "冒险关卡20":
                    return BinaryDataMgr.Instance.Load<T_Level>("adventureMinSpend20");
                case "冒险关卡21":
                    return BinaryDataMgr.Instance.Load<T_Level>("adventureMinSpend21");

            }
        }
        return null;
    }
}
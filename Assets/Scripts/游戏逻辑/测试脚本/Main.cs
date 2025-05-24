using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    private const string firstLaunchKey = "IsFirstLaunch";
    
    
    void Start()
    {
        print(Application.persistentDataPath + "/Data/");

        UIMgr.Instance.ShowPanel<BeginPanel>(E_UILayer.Bottom, (panel) =>
        {
            panel.ChangeCoinNum(GameDataMgr.Instance.playCoin);
        });

        MusicMgr.Instance.PlayBKMusic("rememberMe");

        if (!GameDataMgr.Instance.isload)
        {
            BinaryDataMgr.Instance.InitData();
        }
                                        
        if (!PlayerPrefs.HasKey(firstLaunchKey))
        {
            // 这是第一次打开游戏
            Debug.Log("这是玩家第一次打开游戏");
            PlayerPrefs.SetInt(firstLaunchKey, 1);
            PlayerPrefs.Save();

            if (!GameDataMgr.Instance.isload)
            {
                Invoke(nameof(DelayLoad), 0.1f);
                GameDataMgr.Instance.isload = true;
                
            }
        }
        else
        {
            // 不是第一次打开游戏
            Debug.Log("玩家不是第一次打开游戏");
            //读档

            if (!GameDataMgr.Instance.isload)
            {
                Invoke(nameof(ReadTheFile), 0.1f);
                
                GameDataMgr.Instance.isload = true;
                
            }
        }
    }


    private void DelayLoad()
    {
        //获取所有角色的数据
        GameObjectMgr.Instance.GetAllRoleInfo();
        //加载关卡数据
        GameLevelMgr.Instance.LoadLevelData();
        //加载成就数据
        GameAchieveMgr.Instance.LoadAchieveInfo();
        //加载角色数据
        GameDataMgr.Instance.LoadRoleData();

                
    }

    private void ReadTheFile()
    {
        //获取所有角色的数据
        GameObjectMgr.Instance.GetAllRoleInfo();
        //加载成就数据
        GameAchieveMgr.Instance.LoadAchieveInfo();
        GameAchieveMgr.Instance.LoadAchieveData();
        //加载角色数据
        GameDataMgr.Instance.LoadRoleData();
        GameDataMgr.Instance.GetRoleData();
               
        GameLevelMgr.Instance.LoadLevelData();
        //加载关卡数据
        GameLevelMgr.Instance.GetLevelData();
        //加载金币数据
        GameDataMgr.Instance.LoadPlayerCoin();
    }
}

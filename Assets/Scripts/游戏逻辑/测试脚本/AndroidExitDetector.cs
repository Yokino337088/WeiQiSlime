using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidExitDetector : SingletonMono<AndroidExitDetector>
{
    
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }


    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                // 玩家按下了返回键
                Debug.Log("玩家按下了安卓返回键");
                // 在此添加处理逻辑，如显示确认退出提示框
                GameDataMgr.Instance.SavePlayerCoin();
            }
        }
    }

    void OnApplicationPause(bool pauseStatus)
    {
        if (Application.platform == RuntimePlatform.Android && pauseStatus)
        {
            // 应用进入后台，有可能是按下Home键，也可能是按返回键或其他导致进入后台的操作
            Debug.Log("应用进入后台，可能是按下Home键或其他原因");
            // 在此添加处理逻辑，比如保存游戏数据
            GameDataMgr.Instance.SavePlayerCoin();
        }
    }
}

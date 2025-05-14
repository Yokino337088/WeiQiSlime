using AnyThinkAds.Api;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class AdvertisementMgr : SingletonMono<AdvertisementMgr>
{
    private string appid = "a681a1a01c9ce0";
    private string appkey = "a32c8beb0a3491a62938a6ce63501965e";
    private string key = "b681a1a1b57e1e";

    private bool isLoading = false;
    private bool isAdLoaded = false;

    

    private void Start()
    {
        InitAdv();
        LoadAdv();
    }

    /// <summary>
    /// 初始化广告
    /// </summary>
    private void InitAdv()
    {
        try
        {
            ATSDKAPI.initSDK(appid, appkey);
            ATRewardedVideo.Instance.client.onAdLoadEvent += onAdLoad;
            ATRewardedVideo.Instance.client.onRewardEvent += onReward;
        }
        catch (Exception ex)
        {
            Debug.LogError($"广告初始化出错: {ex.Message}");
        }
    }

    /// <summary>
    /// 加载广告
    /// </summary>
    private IEnumerator LoadAdv()
    {
        isLoading = true;
        isAdLoaded = false;
        try
        {
            Dictionary<string, string> jsonmap = new Dictionary<string, string>();
            jsonmap.Add(ATConst.USERID_KEY, "test_user_id");
            jsonmap.Add(ATConst.USER_EXTRA_DATA, "test_user_extra_data");
            ATRewardedVideo.Instance.loadVideoAd(key, jsonmap);
        }
        catch (Exception ex)
        {
            Debug.LogError($"广告加载出错: {ex.Message}");
            isLoading = false;
        }

        // 等待广告加载完成
        while (isLoading)
        {
            yield return null;
        }
        isAdLoaded = true;
    }

    /// <summary>
    /// 显示广告
    /// </summary>
    public void ShowAdv()
    {
        StartCoroutine(LoadAdv());

        // 使用协程等待广告加载完成后再检查并显示广告
        StartCoroutine(CheckAndShowAd());
    }

    private IEnumerator CheckAndShowAd()
    {
        while (!isAdLoaded)
        {
            yield return null;
        }

        if (ATRewardedVideo.Instance.hasAdReady(key))
        {
            ATRewardedVideo.Instance.showAd(key);
        }
        else
        {
            Debug.LogError("广告加载成功但未准备好显示");
        }
    }

    private void onReward(object sender, ATAdEventArgs e)
    {
        try
        {
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                if (!GameDataMgr.Instance.isShowTavernPanel)
                {
                    GameDataMgr.Instance.playCoin += 20000;
                    UIMgr.Instance.GetPanel<BeginPanel>(panel =>
                    {
                        panel.ChangeCoinNum(GameDataMgr.Instance.playCoin);
                    });
                    GameDataMgr.Instance.SavePlayerCoin();
                }
                else
                {
                    UIMgr.Instance.GetPanel<TavernPanel>(panel =>
                    {
                        panel.RandomUnlock();
                    });
                }
            }
            else if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                ChessBoard.chessBoard.RandomPlaceTopPiece();
            }
            GameAchieveMgr.Instance.CompleteAchievement(7);
            GameAchieveMgr.Instance.SaveAchieveData();
            
        }
        catch (Exception ex)
        {
            Debug.LogError($"奖励处理出错: {ex.Message}");
        }
    }

    private void onAdLoad(object sender, ATAdEventArgs e)
    {
        isLoading = false;
    }
}
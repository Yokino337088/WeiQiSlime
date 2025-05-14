//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using TapTap.TapAd;
//using TapTap.TapAd.Internal;
//using System;
//using static TapAdDemo;

//public class TapAdnMgr : BaseManager<TapAdnMgr>
//{

//    TapRewardVideoAd _tapRewardAd = null;

//    private TapAdnMgr()
//    {
        
//    }

//    /// <summary>
//    /// 初始化广告的函数
//    /// </summary>
//    public void InitAdvertisement()
//    {
//        TapAdConfig config = new TapAdConfig.Builder()
//        .MediaId(1)             // 必选参数，为 TapADN 注册的媒体 ID
//        .MediaName("your_media_name")         // 必选参数，为 TapADN 注册的媒体名称
//        .MediaKey("your_media_key")           // 必选参数，媒体密钥，可以在 TapADN 后台查看（用于传输数据的解密）
//        .MediaVersion("1")                  // 必选参数，默认值 "1"
//        .Channel("your__channel")             // 必选参数，渠道（如果在 TapTap 上架填写 "taptap", 其它渠道上架填写商店拼音小写字母，eg. 小米 -> "xiaomi"）
//        .TapClientId("your_tap_client_id")    // 可选参数，TapTap 开发者中心的游戏 Client ID 
//        .EnableDebugLog(false)              // 可选参数，是否打开原生 debug 调试信息输出：true 打开、false 关闭。默认 false 关闭
//        .ShakeEnabled(false)                // 可选参数，是否开启摇一摇: true 打开、false 关闭。
//        .Build();

//        // CustomControllerWrapper 为实现了 TapTap.TapAd.ICustomController 的类
//        // onInitedCallback 为可选回调函数，类型是 System.Action，
//        TapAdSdk.Init(config, new MyCustomControllerWrapper());
//    }

//    /// <summary>
//    /// 加载广告
//    /// </summary>
//    public void LoadAdvertisement()
//    {
//        if (TapAdSdk.IsInited == false)
//        {
//            Debug.Log("TapAd 需要先初始化!");
//            return;
//        }
//        if (_tapRewardAd != null)
//        {
//            _tapRewardAd.Dispose();
//            _tapRewardAd = null;
//        }
//        int adId = 1;//填写广告Id
//        // create AdRequest
//        var request = new TapAdRequest.Builder()
//            .SpaceId(adId)
//            .RewardName("your_reward_name")
//            .RewardCount(9)
//            .Build();
//        _tapRewardAd = new TapRewardVideoAd(request);
//        // RewardVideoAdLoadListener 为实现了 IRewardVideoAdLoadListener 的类
//        _tapRewardAd.SetLoadListener(new MyRewardVideoAdLoadListener());
//        _tapRewardAd.Load();
//    }

//    /// <summary>
//    /// 播放广告
//    /// </summary>
//    public void ShowAdvertisement()
//    {
//        if (TapAdSdk.IsInited == false)
//        {
//            Debug.Log("TapAd 需要先初始化!");
//            return;
//        }
//        if (_tapRewardAd != null)
//        {
//            // RewardVideoInteractionListener 为实现了 IRewardVideoInteractionListener 的类
//            _tapRewardAd.SetInteractionListener(new MyRewardVideoInteractionListener());
//            _tapRewardAd.Show();
//        }
//        else
//        {
//            Debug.LogErrorFormat($"[Unity::AD] 未加载好视频,无法播放!");
//        }
//    }
//}

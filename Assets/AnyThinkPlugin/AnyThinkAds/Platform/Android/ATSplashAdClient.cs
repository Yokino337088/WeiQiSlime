using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using AnyThinkAds.Common;
using AnyThinkAds.Api;
using AnyThinkAds.ThirdParty.LitJson;

namespace AnyThinkAds.Android
{
    public class ATSplashAdClient : AndroidJavaProxy, IATSplashAdClient
    {
        public event EventHandler<ATAdEventArgs>    onAdLoadTimeoutEvent;
        public event EventHandler<ATAdEventArgs>    onDeeplinkEvent;
        public event EventHandler<ATAdEventArgs>    onDownloadConfirmEvent;    
        public event EventHandler<ATAdEventArgs>        onAdLoadEvent;
        public event EventHandler<ATAdErrorEventArgs>   onAdLoadFailureEvent;
        public event EventHandler<ATAdEventArgs>        onAdShowEvent;
        public event EventHandler<ATAdErrorEventArgs>   onAdShowFailureEvent;
        public event EventHandler<ATAdEventArgs>        onAdCloseEvent;
        public event EventHandler<ATAdEventArgs>        onAdClickEvent;
        public event EventHandler<ATAdEventArgs>        onAdSourceAttemptEvent;
        public event EventHandler<ATAdEventArgs>        onAdSourceFilledEvent;
        public event EventHandler<ATAdErrorEventArgs>   onAdSourceLoadFailureEvent;
        public event EventHandler<ATAdEventArgs>        onAdSourceBiddingAttemptEvent;
        public event EventHandler<ATAdEventArgs>        onAdSourceBiddingFilledEvent;
        public event EventHandler<ATAdErrorEventArgs>   onAdSourceBiddingFailureEvent;

        private Dictionary<string, AndroidJavaObject> splashHelperMap = new Dictionary<string, AndroidJavaObject>();
        private ATSplashAdListener splashAdListener;

        private int fetchAdTimeout = 0;
        private string defaultAdSourceConfig;

        public ATSplashAdClient() : base("com.anythink.unitybridge.splash.SplashListener")
        {
            
        }

        private AndroidJavaObject getSplashHelper(string placementId)
        {
            try
            {
                if (!splashHelperMap.ContainsKey(placementId))
                {
                    AndroidJavaObject splashHelper = new AndroidJavaObject(
                        "com.anythink.unitybridge.splash.SplashHelper", this);
                    splashHelper.Call("initSplash", placementId, fetchAdTimeout, defaultAdSourceConfig);
                    splashHelperMap.Add(placementId, splashHelper);
                    return splashHelper;
                } else {
                    return splashHelperMap[placementId];
                }
            }
            catch(Exception e)
            {
                ATLogger.LogError("getSplashHelper() >>> error: {0}", e.Message);
            }
            return null;
        }

        public void loadSplashAd(string placementId, int fetchAdTimeout = 0, string defaultAdSourceConfig = "", string mapJson = "")
        {
            this.fetchAdTimeout = fetchAdTimeout;
            this.defaultAdSourceConfig = defaultAdSourceConfig;
            try
            {
                ATLogger.Log("loadSplashAd() >>> placementId: {0}", placementId);
                getSplashHelper(placementId).Call("loadAd", mapJson);
            }
            catch (System.Exception e)
            {
                ATLogger.LogError("loadSplashAd() >>>  error: {0}", e.Message);
            }
        }

        public void setListener(ATSplashAdListener listener)
        {
            this.splashAdListener = listener;
        }

        public bool hasSplashAdReady(string placementId)
        {
            bool isAdReady = false;
            ATLogger.Log("hasSplashAdReady() >>> placementId: {0}", placementId);
            try
            {
                isAdReady = getSplashHelper(placementId).Call<bool>("isAdReady");
            }
            catch(Exception e)
            {
                ATLogger.LogError("hasSplashAdReady() >>>  error: {0}", e.Message);
            }
            return isAdReady;
        }

        public string checkAdStatus(string placementId)
        {
            string adStatusJsonString = "";
            ATLogger.Log("checkAdStatus() >>> placementId: {0}", placementId);
            try
            {
                 adStatusJsonString = getSplashHelper(placementId).Call<string>("checkAdStatus");
            }
            catch (System.Exception e)
            {
                ATLogger.LogError("checkAdStatus() >>> error: {0}", e.Message);
            }
            return adStatusJsonString;
        }

        public void showSplashAd(string placementId, string mapJson)
        {
            ATLogger.Log("showSplashAd() >>> placementId: {0}, mapJson: {1}", placementId, mapJson);
            try
            {
                getSplashHelper(placementId).Call("showAd", mapJson);
            }
            catch(Exception e)
            {
                ATLogger.LogError("showSplashAd() >>> error: {0}", e.Message);
            }
        }

		public string getValidAdCaches(string placementId)
        {
            ATLogger.Log("getValidAdCaches() >>> placementId: {0}", placementId);
            string adString = "";
            try
            {
               adString = getSplashHelper(placementId).Call<string>("getValidAdCaches");
            }
            catch(Exception e)
            {
                ATLogger.LogError("getValidAdCaches() >>> error: {0}", e.Message);
            }
            return adString;
        }

        public void entryScenarioWithPlacementID(string placementId, string scenarioID)
        {
            ATLogger.Log("entryScenarioWithPlacementID() >>> placementId: {0}, scenarioID: {1}", placementId, scenarioID);

            try
            {
               getSplashHelper(placementId).Call<string>("entryAdScenario", scenarioID);
            }
            catch(Exception e)
            {
                ATLogger.LogError("entryScenarioWithPlacementID() >>> error: {0}", e.Message);
            }
        }

        public void onSplashAdLoad(String unitId, bool isTimeout)
        {
            onAdLoadEvent?.Invoke(this, new ATAdEventArgs(unitId, "", isTimeout));
        }

        public void onSplashAdLoadTimeOut(String unitId)
        {
            onAdLoadTimeoutEvent?.Invoke(this, new ATAdEventArgs(unitId, "", true));
        }

        public void onSplashAdLoadFailed(String unitId, String code, String msg)
        {
            onAdLoadFailureEvent?.Invoke(this, new ATAdErrorEventArgs(unitId, code, msg));
        }

        public void onSplashAdShow(String unitId, String callbackJson)
        {
            onAdShowEvent?.Invoke(this, new ATAdEventArgs(unitId, callbackJson));
        }

        public void onSplashAdClick(String unitId, String callbackJson)
        {
            onAdClickEvent?.Invoke(this, new ATAdEventArgs(unitId, callbackJson));
        }

        public void onSplashAdDismiss(String unitId, String callbackJson)
        {
            onAdCloseEvent?.Invoke(this, new ATAdEventArgs(unitId, callbackJson));
        }

        public void onSplashAdDeeplinkCallback(String unitId, String callbackJson, bool isSuccess)
        {
            onDeeplinkEvent?.Invoke(this, new ATAdEventArgs(unitId, callbackJson, false, isSuccess));
        }

        public void onSplashAdDownloadConfirm(String unitId, String callbackJson)
        {
            onDownloadConfirmEvent?.Invoke(this, new ATAdEventArgs(unitId, callbackJson));
        }

        // Adsource Listener
        public void onAdSourceBiddingAttempt(string placementId, string callbackJson)
        {
            ATLogger.Log("onAdSourceBiddingAttempt...unity3d." + placementId + "," + callbackJson);
            onAdSourceBiddingAttemptEvent?.Invoke(this, new ATAdEventArgs(placementId, callbackJson));
        }

        public void onAdSourceBiddingFilled(string placementId, string callbackJson)
        {
            ATLogger.Log("onAdSourceBiddingFilled...unity3d." + placementId + "," + callbackJson);
           
            onAdSourceBiddingFilledEvent?.Invoke(this, new ATAdEventArgs(placementId, callbackJson));
        }

        public void onAdSourceBiddingFail(string placementId, string callbackJson, string code, string error)
        {
            ATLogger.Log("onAdSourceBiddingFail...unity3d." + placementId + "," + code + "," + error + "," + callbackJson);
           
            onAdSourceBiddingFailureEvent?.Invoke(this, new ATAdErrorEventArgs(placementId, callbackJson, code, error));
        }

        public void onAdSourceAttempt(string placementId, string callbackJson)
        {
            ATLogger.Log("onAdSourceAttempt...unity3d." + placementId + "," + callbackJson);
            
            onAdSourceAttemptEvent?.Invoke(this, new ATAdEventArgs(placementId, callbackJson));
        }

        public void onAdSourceLoadFilled(string placementId, string callbackJson)
        {
            ATLogger.Log("onAdSourceLoadFilled...unity3d." + placementId + "," + callbackJson);
           
            onAdSourceFilledEvent?.Invoke(this, new ATAdEventArgs(placementId, callbackJson));
        }

        public void onAdSourceLoadFail(string placementId, string callbackJson, string code, string error)
        {
            ATLogger.Log("onAdSourceLoadFail...unity3d." + placementId + "," + code + "," + error + "," + callbackJson);

            onAdSourceLoadFailureEvent?.Invoke(this, new ATAdErrorEventArgs(placementId, callbackJson, code, error));
        }
    }
}

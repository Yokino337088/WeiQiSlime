using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;

using AnyThinkAds.Common;
using AnyThinkAds.ThirdParty.LitJson;

namespace AnyThinkAds.Api
{
    public class ATSplashAdLocalExtra
    {
        //Only for GDT (true: open download dialog, false: download directly)
        public static readonly string kATSplashAdClickConfirmStatus = "ad_click_confirm_status";
    }
    public class ATSplashAd
    {
        private static readonly ATSplashAd instance = new ATSplashAd();
		public IATSplashAdClient client;

		private ATSplashAd()
		{
            client = AnyThinkAds.ATAdsClientFactory.BuildSplashAdClient();
		}

		public static ATSplashAd Instance 
		{
			get
			{
				return instance;
			}
		}

        public void loadSplashAd(string placementId, Dictionary<string, object> pairs, int fetchAdTimeout = 5000, string defaultAdSourceConfig = "")
        {
            #if UNITY_ANDROID
                client.loadSplashAd(placementId, fetchAdTimeout, defaultAdSourceConfig, JsonMapper.ToJson(pairs));
            #elif (UNITY_5 && UNITY_IOS) || UNITY_IPHONE
                //TODO iOS的开屏加载
                pairs.Add("tolerate_timeout", fetchAdTimeout);
                pairs.Add("default_adSource_config", defaultAdSourceConfig);
                
                client.loadSplashAd(placementId, fetchAdTimeout, defaultAdSourceConfig, JsonMapper.ToJson(pairs));
            #endif
        }

        public void showSplashAd(string placementId, Dictionary<string, object> pairs)
        {
            client.showSplashAd(placementId, JsonMapper.ToJson(pairs));
        }

        public bool hasSplashAdReady(string placementId)
        {
            return client.hasSplashAdReady(placementId);
        }

        public string checkAdStatus(string placementId)
        {
            return client.checkAdStatus(placementId);
        }

        public string getValidAdCaches(string placementId)
        {
            return client.getValidAdCaches(placementId);
        }

        public void entryScenarioWithPlacementID(string placementId, string scenarioID)
        {
            client.entryScenarioWithPlacementID(placementId, scenarioID);
        }
    }
}

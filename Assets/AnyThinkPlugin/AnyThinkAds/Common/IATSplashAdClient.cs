using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnyThinkAds.Api;

namespace AnyThinkAds.Common
{
    public interface IATSplashAdClient : IATSplashEvents
    {
        // void loadSplashAd(string placementId, string mapJson);
        void loadSplashAd(string placementId, int fetchAdTimeout, string defaultAdSourceConfig, string mapJson);
        void setListener(ATSplashAdListener listener);

        bool hasSplashAdReady(string placementId);

        string checkAdStatus(string placementId);

        void showSplashAd(string placementId, string mapJson);

		string getValidAdCaches(string placementId);

        void entryScenarioWithPlacementID(string placementId, string scenarioID);
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnyThinkAds.Common;
using AnyThinkAds.Api;
using AnyThinkAds.ThirdParty.LitJson;


namespace AnyThinkAds.iOS {
	
	public class ATSplashAdClient : IATSplashAdClient {
		private  ATSplashAdListener anyThinkListener;
		public event EventHandler<ATAdEventArgs>        onAdLoadEvent;
        public event EventHandler<ATAdErrorEventArgs>   onAdLoadFailureEvent;
        public event EventHandler<ATAdEventArgs>        onAdShowEvent;
        public event EventHandler<ATAdErrorEventArgs>   onAdShowFailureEvent;
        public event EventHandler<ATAdEventArgs>        onAdCloseEvent;
        public event EventHandler<ATAdEventArgs>        onAdClickEvent;
        public event EventHandler<ATAdEventArgs>        onAdVideoStartEvent;
        public event EventHandler<ATAdErrorEventArgs>   onAdVideoFailureEvent;
        public event EventHandler<ATAdEventArgs>        onAdVideoEndEvent;
        public event EventHandler<ATAdEventArgs>        onAdSourceAttemptEvent;
        public event EventHandler<ATAdEventArgs>        onAdSourceFilledEvent;
        public event EventHandler<ATAdErrorEventArgs>   onAdSourceLoadFailureEvent;
        public event EventHandler<ATAdEventArgs>        onAdSourceBiddingAttemptEvent;
        public event EventHandler<ATAdEventArgs>        onAdSourceBiddingFilledEvent;
        public event EventHandler<ATAdErrorEventArgs>   onAdSourceBiddingFailureEvent;
		public event EventHandler<ATAdEventArgs>        onAdLoadTimeoutEvent;
		public event EventHandler<ATAdEventArgs>        onDeeplinkEvent;
		public event EventHandler<ATAdEventArgs>        onDownloadConfirmEvent;  

		public void addsetting(string placementId,string json){
			//todo...
		}

		public void setListener(ATSplashAdListener listener) {
			Debug.Log("Unity: ATSplashAdAdClient::setListener()");
	        anyThinkListener = listener;
	    }

	    public void loadSplashAd(string placementId, int fetchAdTimeout, string defaultAdSourceConfig, string mapJson) {
			Debug.Log("Unity: ATSplashAdAdClient::loadSplashAd()");
            ATSplashAdWrapper.setClientForPlacementID(placementId, this);
			ATSplashAdWrapper.loadSplashAd(placementId, mapJson);
		}

		public bool hasSplashAdReady(string placementId) {
			Debug.Log("Unity: ATSplashAdAdClient::hasSplashAdReady()");
			return ATSplashAdWrapper.hasSplashAdReady(placementId);
		}

		public void showSplashAd(string placementId, string mapJson) {
			Debug.Log("Unity: ATSplashAdAdClient::showSplashAd()");
			ATSplashAdWrapper.showSplashAd(placementId, mapJson);
		}

		public void cleanCache(string placementId) {
			Debug.Log("Unity: ATSplashAdAdClient::cleanCache()");
			ATSplashAdWrapper.clearCache(placementId);
		}

		public string checkAdStatus(string placementId) {
			Debug.Log("Unity: ATSplashAdAdClient::checkAdStatus()");
			return ATSplashAdWrapper.checkAdStatus(placementId);
		}

		public string getValidAdCaches(string placementId)
		{
			Debug.Log("Unity: ATSplashAdAdClient::getValidAdCaches()");
			return ATSplashAdWrapper.getValidAdCaches(placementId);
		}

		public void entryScenarioWithPlacementID(string placementId, string scenarioID){
            Debug.Log("Unity: ATSplashAdAdClient::entryScenarioWithPlacementID()");
			ATSplashAdWrapper.entryScenarioWithPlacementID(placementId,scenarioID);
		}


		//Callbacks
		public void OnSplashAdDeeplink(string placementID, String callbackJson, bool isSuccess) {
            onDeeplinkEvent?.Invoke(this, new ATAdEventArgs(placementID, callbackJson, false, isSuccess));
        }

		public void OnSplashAdLoadTimeout(string placementID) {
			Debug.Log("OnSplashAdLoadTimeout...unity3d.");
			onAdLoadTimeoutEvent?.Invoke(this, new ATAdEventArgs(placementID, "", true));
	    }

		public void OnSplashAdLoaded(string placementID) {
	      Debug.Log("onSplashAdLoaded...unity3d.");
            onAdLoadEvent?.Invoke(this, new ATAdEventArgs(placementID));
	    }

	    public void OnSplashAdLoadFailure(string placementID, string code, string error) {
	     	Debug.Log("onSplashAdFailed...unity3d.");
            onAdLoadFailureEvent?.Invoke(this, new ATAdErrorEventArgs(placementID, code, error));
	    }

	     public void OnSplashAdVideoPlayFailure(string placementID, string code, string error) {
	    	Debug.Log("Unity: ATSplashAdAdClient::OnSplashAdVideoPlayFailure()");
	        onAdVideoFailureEvent?.Invoke(this, new ATAdErrorEventArgs(placementID, code, error));
	    }

	    public void OnSplashAdVideoPlayStart(string placementID, string callbackJson) {
	    	Debug.Log("Unity: ATSplashAdAdClient::OnSplashAdPlayStart()");
	        onAdVideoStartEvent?.Invoke(this, new ATAdEventArgs(placementID, callbackJson));
	    }

	    public void OnSplashAdVideoPlayEnd(string placementID, string callbackJson) {
	    	Debug.Log("Unity: ATSplashAdAdClient::OnSplashAdVideoPlayEnd()");
	         onAdVideoEndEvent?.Invoke(this, new ATAdEventArgs(placementID, callbackJson));
	    }

        public void OnSplashAdShow(string placementID, string callbackJson) {
	    	Debug.Log("Unity: ATSplashAdAdClient::OnSplashAdShow()");
            onAdShowEvent?.Invoke(this, new ATAdEventArgs(placementID, callbackJson));
	    }

        public void OnSplashAdFailedToShow(string placementID) {
	    	Debug.Log("Unity: ATSplashAdAdClient::OnSplashAdFailedToShow()");
	        onAdShowFailureEvent?.Invoke(this, new ATAdErrorEventArgs(placementID, "-1", "Failed to show video ad"));
	    }

        public void OnSplashAdClick(string placementID, string callbackJson) {
	    	Debug.Log("Unity: ATSplashAdAdClient::OnSplashAdClick()");
             onAdClickEvent?.Invoke(this, new ATAdEventArgs(placementID, callbackJson));
	    }

        public void OnSplashAdClose(string placementID, string callbackJson) {
	    	Debug.Log("Unity: ATSplashAdAdClient::OnSplashAdClose()");
            onAdCloseEvent?.Invoke(this, new ATAdEventArgs(placementID, callbackJson));
	    }
		
		//auto callbacks
	    public void startLoadingADSource(string placementId, string callbackJson) 
		{
	        Debug.Log("Unity: ATSplashAdAdClient::startLoadingADSource()");
           onAdSourceAttemptEvent?.Invoke(this, new ATAdEventArgs(placementId, callbackJson));
	    }
	    public void finishLoadingADSource(string placementId, string callbackJson) 
		{
	        Debug.Log("Unity: ATSplashAdAdClient::finishLoadingADSource()");
           onAdSourceFilledEvent?.Invoke(this, new ATAdEventArgs(placementId, callbackJson));
	    }	
	    public void failToLoadADSource(string placementId, string callbackJson,string code, string error) 
		{
	        Debug.Log("Unity: ATSplashAdAdClient::failToLoadADSource()");
	        onAdSourceLoadFailureEvent?.Invoke(this, new ATAdErrorEventArgs(placementId, callbackJson, code, error));
	    }
		public void startBiddingADSource(string placementId, string callbackJson) 
		{
	        Debug.Log("Unity: ATSplashAdAdClient::startBiddingADSource()");
           onAdSourceBiddingAttemptEvent?.Invoke(this, new ATAdEventArgs(placementId, callbackJson));
	    }
	    public void finishBiddingADSource(string placementId, string callbackJson) 
		{
	        Debug.Log("Unity: ATSplashAdAdClient::finishBiddingADSource()");
          	onAdSourceBiddingFilledEvent?.Invoke(this, new ATAdEventArgs(placementId, callbackJson));
	    }	
	    public void failBiddingADSource(string placementId,string callbackJson, string code, string error) 
		{
	        Debug.Log("Unity: ATSplashAdAdClient::failBiddingADSource()");
	        onAdSourceBiddingFailureEvent?.Invoke(this, new ATAdErrorEventArgs(placementId, callbackJson, code, error));
	    }

	    // Auto
		public void addAutoLoadAdPlacementID(string[] placementIDList) 
		{
			Debug.Log("Unity: ATSplashAdAdClient:addAutoLoadAdPlacementID()");

		

	     	if (placementIDList != null && placementIDList.Length > 0)
            {
				foreach (string placementID in placementIDList)
        		{
					ATSplashAdWrapper.setClientForPlacementID(placementID, this);
				}

                string placementIDListString = JsonMapper.ToJson(placementIDList);
				ATSplashAdWrapper.addAutoLoadAdPlacementID(placementIDListString);
                Debug.Log("addAutoLoadAdPlacementID, placementIDList === " + placementIDListString);
            }
            else
            {
                Debug.Log("addAutoLoadAdPlacementID, placementIDList = null");
            } 		

		}

		public void removeAutoLoadAdPlacementID(string placementId) 
		{
			Debug.Log("Unity: ATSplashAdAdClient:removeAutoLoadAdPlacementID()");
			ATSplashAdWrapper.removeAutoLoadAdPlacementID(placementId);
		}

		public bool autoLoadSplashAdReadyForPlacementID(string placementId) 
		{
			Debug.Log("Unity: ATSplashAdAdClient:autoLoadSplashAdReadyForPlacementID()");
			return ATSplashAdWrapper.autoLoadSplashAdReadyForPlacementID(placementId);
		}
		public string getAutoValidAdCaches(string placementId)
		{
			Debug.Log("Unity: ATSplashAdAdClient:getAutoValidAdCaches()");
			return ATSplashAdWrapper.getAutoValidAdCaches(placementId);
		}

		public string checkAutoAdStatus(string placementId) {
			Debug.Log("Unity: ATSplashAdAdClient::checkAutoAdStatus()");
			return ATSplashAdWrapper.checkAutoAdStatus(placementId);
		}	


		public void setAutoLocalExtra(string placementId, string mapJson) 
		{
			Debug.Log("Unity: ATSplashAdAdClient:setAutoLocalExtra()");
			ATSplashAdWrapper.setAutoLocalExtra(placementId, mapJson);
		}
		public void entryAutoAdScenarioWithPlacementID(string placementId, string scenarioID) 
		{
			Debug.Log("Unity: ATSplashAdAdClient:entryAutoAdScenarioWithPlacementID()");
			ATSplashAdWrapper.entryAutoAdScenarioWithPlacementID(placementId, scenarioID);
		}
		public void showAutoAd(string placementId, string mapJson) 
		{
	    	Debug.Log("Unity: ATSplashAdAdClient::showAutoAd()");
	    	ATSplashAdWrapper.showAutoSplashAd(placementId, mapJson);
	    }


	}
}

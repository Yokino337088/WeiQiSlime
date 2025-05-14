using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using AOT;
using AnyThinkAds.ThirdParty.LitJson;
using AnyThinkAds.iOS;
#pragma warning disable 0109
public class ATSplashAdWrapper:ATAdWrapper {
	static private Dictionary<string, ATSplashAdClient> clients;
	static private string CMessaageReceiverClass = "ATSplashAdWrapper";

	static public new void InvokeCallback(JsonData jsonData) {
        Debug.Log("Unity: ATSplashAdWrapper::InvokeCallback()");
        string extraJson = "";
        string callback = (string)jsonData["callback"];
        Dictionary<string, object> msgDict = JsonMapper.ToObject<Dictionary<string, object>>(jsonData["msg"].ToJson());
        JsonData msgJsonData = jsonData["msg"];
        IDictionary idic = (System.Collections.IDictionary)msgJsonData;

        if (idic.Contains("extra")) { 
            JsonData extraJsonDate = msgJsonData["extra"];
            if (extraJsonDate != null) {
                extraJson = msgJsonData["extra"].ToJson();
            }
        }
        
        if (callback.Equals("OnSplashAdLoaded")) {
    		OnSplashAdLoaded((string)msgDict["placement_id"]);
    	} else if (callback.Equals("OnSplashAdLoadFailure")) {
    		Dictionary<string, object> errorDict = new Dictionary<string, object>();
            Dictionary<string, object> errorMsg = JsonMapper.ToObject<Dictionary<string, object>>(msgJsonData["error"].ToJson());
    		if (errorMsg.ContainsKey("code")) { errorDict.Add("code", errorMsg["code"]); }
            if (errorMsg.ContainsKey("reason")) { errorDict.Add("message", errorMsg["reason"]); }
    		OnSplashAdLoadFailure((string)msgDict["placement_id"], errorDict);
    	} else if (callback.Equals("OnSplashAdVideoPlayFailure")) {
    		Dictionary<string, object> errorDict = new Dictionary<string, object>();
    		Dictionary<string, object> errorMsg = JsonMapper.ToObject<Dictionary<string, object>>(msgJsonData["error"].ToJson());
            if (errorMsg.ContainsKey("code")) { errorDict.Add("code", errorMsg["code"]); }
            if (errorMsg.ContainsKey("reason")) { errorDict.Add("message", errorMsg["reason"]); }
    		OnSplashAdVideoPlayFailure((string)msgDict["placement_id"], errorDict);
    	} else if (callback.Equals("OnSplashAdVideoPlayStart")) {
    		OnSplashAdVideoPlayStart((string)msgDict["placement_id"], extraJson);
    	} else if (callback.Equals("OnSplashAdVideoPlayEnd")) {
    		OnSplashAdVideoPlayEnd((string)msgDict["placement_id"], extraJson);
    	} else if (callback.Equals("OnSplashAdShow")) {
    		OnSplashAdShow((string)msgDict["placement_id"], extraJson);
    	} else if (callback.Equals("OnSplashAdClick")) {
    		OnSplashAdClick((string)msgDict["placement_id"], extraJson);
    	} else if (callback.Equals("OnSplashAdClose")) {
            OnSplashAdClose((string)msgDict["placement_id"], extraJson);
        } else if (callback.Equals("OnSplashAdFailedToShow")) {
            OnSplashAdFailedToShow((string)msgDict["placement_id"]);
        }else if (callback.Equals("startLoadingADSource")) {
            StartLoadingADSource((string)msgDict["placement_id"], extraJson);
        }else if (callback.Equals("finishLoadingADSource")) {
            FinishLoadingADSource((string)msgDict["placement_id"], extraJson);
        }else if (callback.Equals("failToLoadADSource")) {

    		Dictionary<string, object> errorDict = new Dictionary<string, object>();
            Dictionary<string, object> errorMsg = JsonMapper.ToObject<Dictionary<string, object>>(msgJsonData["error"].ToJson());
    		if (errorMsg["code"] != null) { errorDict.Add("code", errorMsg["code"]); }
    		if (errorMsg["reason"] != null) { errorDict.Add("message", errorMsg["reason"]); }
    		FailToLoadADSource((string)msgDict["placement_id"],extraJson, errorDict);  

        }else if (callback.Equals("startBiddingADSource")) {
            StartBiddingADSource((string)msgDict["placement_id"], extraJson);
           
        }else if (callback.Equals("finishBiddingADSource")) {
            FinishBiddingADSource((string)msgDict["placement_id"], extraJson);
  
        }else if (callback.Equals("failBiddingADSource")) {
        	Dictionary<string, object> errorDict = new Dictionary<string, object>();
            Dictionary<string, object> errorMsg = JsonMapper.ToObject<Dictionary<string, object>>(msgJsonData["error"].ToJson());
    		if (errorMsg["code"] != null) { errorDict.Add("code", errorMsg["code"]); }
    		if (errorMsg["reason"] != null) { errorDict.Add("message", errorMsg["reason"]); }
    		FailBiddingADSource((string)msgDict["placement_id"],extraJson, errorDict);
        }

        
    }

	static public void setClientForPlacementID(string placementID, ATSplashAdClient client) {
        if (clients == null) clients = new Dictionary<string, ATSplashAdClient>();
        if (clients.ContainsKey(placementID)) clients.Remove(placementID);
        clients.Add(placementID, client);
	}

	static public void loadSplashAd(string placementID, string customData) {
    	Debug.Log("Unity: ATSplashAdWrapper::loadSplashAd(" + placementID + ")");
    	ATUnityCBridge.SendMessageToC(CMessaageReceiverClass, "loadSplashAdWithPlacementID:customDataJSONString:callback:", new object[]{placementID, customData != null ? customData : ""}, true);
    }

    static public bool hasSplashAdReady(string placementID) {
        Debug.Log("Unity: ATSplashAdWrapper::isSplashAdReady(" + placementID + ")");
    	return ATUnityCBridge.SendMessageToC(CMessaageReceiverClass, "splashAdReadyForPlacementID:", new object[]{placementID});
    }

    static public void showSplashAd(string placementID, string mapJson) {
	    Debug.Log("Unity: ATSplashAdWrapper::showSplashAd(" + placementID + ")");
    	ATUnityCBridge.SendMessageToC(CMessaageReceiverClass, "showSplashAdWithPlacementID:extraJsonString:", new object[]{placementID, mapJson});
    }

    static public void clearCache(string placementID) {
        Debug.Log("Unity: ATSplashAdWrapper::clearCache()");
    	ATUnityCBridge.SendMessageToC(CMessaageReceiverClass, "clearCache", null);
    }

    static public string checkAdStatus(string placementID) {
        Debug.Log("Unity: ATSplashAdWrapper::checkAdStatus(" + placementID + ")");
        return ATUnityCBridge.GetStringMessageFromC(CMessaageReceiverClass, "checkAdStatus:", new object[]{placementID});
    }

    static public string getValidAdCaches(string placementID)
    {
        Debug.Log("Unity: ATSplashAdWrapper::checkAdStatus(" + placementID + ")");
        return ATUnityCBridge.GetStringMessageFromC(CMessaageReceiverClass, "getValidAdCaches:", new object[] { placementID });
    }
  
    static public void entryScenarioWithPlacementID(string placementID, string scenarioID) 
    {
    	Debug.Log("Unity: ATSplashAdWrapper::entryScenarioWithPlacementID(" + placementID + scenarioID + ")");
    	ATUnityCBridge.SendMessageToC(CMessaageReceiverClass, "entryScenarioWithPlacementID:scenarioID:", new object[]{placementID, scenarioID});
    }

    //Callbacks
    static private void OnSplashAdLoaded(string placementID) {
    	Debug.Log("Unity: ATSplashAdWrapper::OnSplashAdLoaded()");
        if (clients[placementID] != null) clients[placementID].OnSplashAdLoaded(placementID);
    }

    static private void OnSplashAdLoadFailure(string placementID, Dictionary<string, object> errorDict) {
    	Debug.Log("Unity: ATSplashAdWrapper::OnSplashAdLoadFailure()");
        Debug.Log("placementID = " + placementID + "errorDict = " + JsonMapper.ToJson(errorDict));
        if (clients[placementID] != null) clients[placementID].OnSplashAdLoadFailure(placementID, (string)errorDict["code"], (string)errorDict["message"]);
    }

     static private void OnSplashAdVideoPlayFailure(string placementID, Dictionary<string, object> errorDict) {
    	Debug.Log("Unity: ATSplashAdWrapper::OnSplashAdVideoPlayFailure()");
        if (clients[placementID] != null) clients[placementID].OnSplashAdVideoPlayFailure(placementID, (string)errorDict["code"], (string)errorDict["message"]);
    }

    static private void OnSplashAdVideoPlayStart(string placementID, string callbackJson) {
    	Debug.Log("Unity: ATSplashAdWrapper::OnSplashAdPlayStart()");
        if (clients[placementID] != null) clients[placementID].OnSplashAdVideoPlayStart(placementID, callbackJson);
    }

    static private void OnSplashAdVideoPlayEnd(string placementID, string callbackJson) {
    	Debug.Log("Unity: ATSplashAdWrapper::OnSplashAdVideoPlayEnd()");
        if (clients[placementID] != null) clients[placementID].OnSplashAdVideoPlayEnd(placementID, callbackJson);
    }

    static private void OnSplashAdShow(string placementID, string callbackJson) {
    	Debug.Log("Unity: ATSplashAdWrapper::OnSplashAdShow()");
        if (clients[placementID] != null) clients[placementID].OnSplashAdShow(placementID, callbackJson);
    }

    static private void OnSplashAdFailedToShow(string placementID) {
        Debug.Log("Unity: ATSplashAdWrapper::OnSplashAdFailedToShow()");
        if (clients[placementID] != null) clients[placementID].OnSplashAdFailedToShow(placementID);
    }

    static private void OnSplashAdClick(string placementID, string callbackJson) {
    	Debug.Log("Unity: ATSplashAdWrapper::OnSplashAdClick()");
        if (clients[placementID] != null) clients[placementID].OnSplashAdClick(placementID, callbackJson);
    }

    static private void OnSplashAdClose(string placementID, string callbackJson) {
    	Debug.Log("Unity: ATSplashAdWrapper::OnSplashAdClose()");
        if (clients[placementID] != null) clients[placementID].OnSplashAdClose(placementID, callbackJson);
    }
    // ad source callback
    static public void StartLoadingADSource(string placementID, string callbackJson)
    {
        Debug.Log("Unity: ATSplashAdWrapper::StartLoadingADSource()");
        if (clients[placementID] != null) clients[placementID].startLoadingADSource(placementID, callbackJson);
    }    
    static public void FinishLoadingADSource(string placementID, string callbackJson)
    {
        Debug.Log("Unity: ATSplashAdWrapper::FinishLoadingADSource()");
        if (clients[placementID] != null) clients[placementID].finishLoadingADSource(placementID, callbackJson);
    }

    static public void FailToLoadADSource(string placementID,string callbackJson, Dictionary<string, object> errorDict) 
    {
    	Debug.Log("Unity: ATSplashAdWrapper::FailToLoadADSource()");

        Debug.Log("placementID = " + placementID + "errorDict = " + JsonMapper.ToJson(errorDict));
        if (clients[placementID] != null) clients[placementID].failToLoadADSource(placementID,callbackJson,(string)errorDict["code"], (string)errorDict["message"]);
    }

    static public void StartBiddingADSource(string placementID, string callbackJson)
    {
        Debug.Log("Unity: ATSplashAdWrapper::StartBiddingADSource()");
        if (clients[placementID] != null) clients[placementID].startBiddingADSource(placementID, callbackJson);
    }    
    static public void FinishBiddingADSource(string placementID, string callbackJson)
    {
        Debug.Log("Unity: ATSplashAdWrapper::FinishBiddingADSource()");
        if (clients[placementID] != null) clients[placementID].finishBiddingADSource(placementID, callbackJson);
    }

    static public void FailBiddingADSource(string placementID, string callbackJson,Dictionary<string, object> errorDict) 
    {
    	Debug.Log("Unity: ATSplashAdWrapper::FailBiddingADSource()");

        Debug.Log("placementID = " + placementID + "errorDict = " + JsonMapper.ToJson(errorDict));
        if (clients[placementID] != null) clients[placementID].failBiddingADSource(placementID,callbackJson,(string)errorDict["code"], (string)errorDict["message"]);
    }

 // Auto
     static public void addAutoLoadAdPlacementID(string placementID) 
     {
    	Debug.Log("Unity: ATSplashAdWrapper::addAutoLoadAdPlacementID(" + placementID + ")");
    	ATUnityCBridge.SendMessageToC(CMessaageReceiverClass, "addAutoLoadAdPlacementID:callback:", new object[]{placementID}, true);
    }

    static public void removeAutoLoadAdPlacementID(string placementID) 
    {
    	Debug.Log("Unity: ATSplashAdWrapper::removeAutoLoadAdPlacementID(" + placementID + ")");
    	ATUnityCBridge.SendMessageToC(CMessaageReceiverClass, "removeAutoLoadAdPlacementID:", new object[]{placementID});
    }
    static public bool autoLoadSplashAdReadyForPlacementID(string placementID) 
    {
        Debug.Log("Unity: ATSplashAdWrapper::autoLoadSplashAdReadyForPlacementID(" + placementID + ")");
        
    	return ATUnityCBridge.SendMessageToC(CMessaageReceiverClass, "autoLoadSplashAdReadyForPlacementID:", new object[]{placementID});
    }    
    static public string getAutoValidAdCaches(string placementID)
    {
        Debug.Log("Unity: ATSplashAdWrapper::getAutoValidAdCaches");
        return ATUnityCBridge.GetStringMessageFromC(CMessaageReceiverClass, "getAutoValidAdCaches:", new object[]{placementID});
    }

    static public string checkAutoAdStatus(string placementID) {
        Debug.Log("Unity: ATSplashAdWrapper::checkAutoAdStatus(" + placementID + ")");
        return ATUnityCBridge.GetStringMessageFromC(CMessaageReceiverClass, "checkAutoAdStatus:", new object[]{placementID});
    }

    static public void setAutoLocalExtra(string placementID, string customData) 
    {

    	Debug.Log("Unity: ATSplashAdWrapper::setAutoLocalExtra(" + placementID + customData + ")");
    	ATUnityCBridge.SendMessageToC(CMessaageReceiverClass, "setAutoLocalExtra:customDataJSONString:", new object[] {placementID, customData != null ? customData : ""});
    }

    static public void entryAutoAdScenarioWithPlacementID(string placementID, string scenarioID) 
    {
    	Debug.Log("Unity: ATSplashAdWrapper::entryAutoAdScenarioWithPlacementID(" + placementID + scenarioID + ")");
    	ATUnityCBridge.SendMessageToC(CMessaageReceiverClass, "entryAutoAdScenarioWithPlacementID:scenarioID:", new object[]{placementID, scenarioID});
    }

    static public void showAutoSplashAd(string placementID, string mapJson) {
	    Debug.Log("Unity: ATSplashAdWrapper::showAutoSplashAd(" + placementID + ")");
    	ATUnityCBridge.SendMessageToC(CMessaageReceiverClass, "showAutoSplashAd:extraJsonString:", new object[]{placementID, mapJson});
    }



}




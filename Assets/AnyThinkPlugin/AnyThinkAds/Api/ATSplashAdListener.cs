using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///summary
///（注意：对于Android来说，所有回调方法均不在Unity的主线程）
///sumary
namespace AnyThinkAds.Api
{
    public interface ATSplashAdListener
    {
        void onSplashAdLoad(string unitId, bool isTimeout);

        void onSplashAdLoadTimeOut(string unitId);

        void onSplashAdLoadFailed(string unitId, string code, string msg);

        void onSplashAdShow(string unitId, ATCallbackInfo callbackInfo);

        void onSplashAdClick(string unitId, ATCallbackInfo callbackInfo);

        void onSplashAdDismiss(string unitId, ATCallbackInfo callbackInfo);

        void onSplashAdDeeplinkCallback(string unitId, ATCallbackInfo callbackInfo, bool isSuccess);

        void onSplashAdDownloadConfirm(string unitId, ATCallbackInfo callbackInfo);

        void startLoadingADSource(string placementId, ATCallbackInfo callbackInfo);


		void finishLoadingADSource(string placementId, ATCallbackInfo callbackInfo);

		void failToLoadADSource(string placementId,ATCallbackInfo callbackInfo,string code, string message);

		void startBiddingADSource(string placementId, ATCallbackInfo callbackInfo);

		void finishBiddingADSource(string placementId, ATCallbackInfo callbackInfo);

		void failBiddingADSource(string placementId,ATCallbackInfo callbackInfo,string code, string message);
    }
}

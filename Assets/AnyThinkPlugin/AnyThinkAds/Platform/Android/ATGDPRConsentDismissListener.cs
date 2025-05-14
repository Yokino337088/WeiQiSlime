using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnyThinkAds.Api;

namespace AnyThinkAds.Android
{
    public class ATGDPRConsentDismissListener : AndroidJavaProxy
    {
        ATConsentDismissListener mListener;
        public ATGDPRConsentDismissListener(ATConsentDismissListener listener): base("com.anythink.unitybridge.sdkinit.SDKConsentDismissListener")
        {
            mListener = listener;
        }

        public void onConsentDismiss()
        {
            if (mListener != null)
            {
                mListener.onConsentDismiss();
            }
        }

    }
}

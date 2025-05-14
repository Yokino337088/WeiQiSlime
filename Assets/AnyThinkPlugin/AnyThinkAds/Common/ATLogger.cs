using System;
using UnityEngine;

namespace AnyThinkAds.Common
{
    public class ATLogger
    {   
        private static bool isDebug = false;
        public static bool IsDebug 
        {
            get {
                return isDebug;
            }
            set {
                isDebug = value;
            }
        }

        // public static void Log(string msg)
        // {
        //     Log(msg, null);
        // }

        // public static void Log(string format, object obj)
        // {
        //     Log(format, obj, null);
        // }

        public static void Log(string format, object obj1 = null, object obj2 = null)
        {
            if (!isDebug) {
                return;
            }
            try {
                if (obj1 == null && obj2 == null)
                {
                    Debug.Log(format);
                }
                else if (obj1 != null && obj2 == null)
                {
                    Debug.Log(String.Format(format, obj1));
                } 
                else if (obj1 == null && obj2 != null)
                {
                    Debug.Log(String.Format(format, obj2));
                }
                else {
                    Debug.Log(String.Format(format, obj1, obj2));
                }
            } catch(Exception e) 
            {
                 Debug.LogError("Log error: " + e.Message);
            }
        }


        // public static void LogError(string msg)
        // {
        //     LogError(msg, null);
        // }

        // public static void LogError(string format, object obj)
        // {
        //     LogError(format, obj, null);
        // }

        public static void LogError(string format, object obj1 = null, object obj2 = null)
        {
            if (!isDebug) {
                return;
            }
            try {
                if (obj1 == null && obj2 == null)
                {
                    Debug.LogError(format);
                }
                else if (obj1 != null && obj2 == null)
                {
                    Debug.LogError(String.Format(format, obj1));
                } 
                else if (obj1 == null && obj2 != null)
                {
                    Debug.LogError(String.Format(format, obj2));
                }
                else {
                    Debug.LogError(String.Format(format, obj1, obj2));
                }
            } catch(Exception e) 
            {
                 Debug.LogError("Log error: " + e.Message);
            }
        }

    }
}

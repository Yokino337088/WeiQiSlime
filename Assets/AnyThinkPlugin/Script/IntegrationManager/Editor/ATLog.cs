using System;
using System.Collections;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class ATLog {
    public static bool isDebug = false;

    public static void log(string msg) 
    {
        // string msg = 
        if (isDebug) {
            Debug.Log(msg);
        }
    }

    public static void log(string tag, string msg)
    {
        if (isDebug) {
            Debug.Log(tag + ": " + msg);
        }
    }

    public static void logFormat(string msg, object[] args)
    {   
        if (isDebug) {
            Debug.LogFormat(msg, args);
        }
    }

    public static void logError(string msg)
    {
        Debug.LogError(msg);
    }
}
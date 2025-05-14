using System;
using UnityEditor;
using UnityEngine;
using AnyThink.Scripts.IntegrationManager.Editor;

[InitializeOnLoad]
public class ATAssetPostprocessor : AssetPostprocessor
{
    private static readonly string TAG = "ATAssetPostprocessor";

    static ATAssetPostprocessor()
    {
        log("ATAssetPostprocessor is now initialized!");
    }
    void OnPostprocessAsset(string path)
    {
        log("OnPostprocessAsset() >>> path: " + path + " assetPath: " + assetPath);
    }

    static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
    {
        foreach (string str in importedAssets)
        {
            log("imported Asset: " + str);
        }
        foreach (string str in deletedAssets)
        {
            log("Deleted Asset: " + str);
        }

        for (int i = 0; i < movedAssets.Length; i++)
        {
            log("Moved Asset: " + movedAssets[i] + " from: " + movedFromAssetPaths[i]);
        }
        
    }

    void OnPreprocessAsset()
    {
        log("OnPreprocessAsset() >>> called assetPath: " + assetPath);
    }

    private static void log(string msg)
    {
        ATLog.log(TAG, msg);
    }
}

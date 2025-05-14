using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;
// #if UNITY_EDITOR    //是Unity编辑器才引入
using UnityEditor;
// #endif


public class ATSdkUtil
{
// #if UNITY_EDITOR
    /// <summary>
    /// Gets the path of the asset in the project for a given Anythink plugin export path.
    /// </summary>
    /// <param name="exportPath">The actual exported path of the asset.</param>
    /// <returns>The exported path of the MAX plugin asset or the default export path if the asset is not found.</returns>
    public static string GetAssetPathForExportPath(string exportPath)
    {
        var defaultPath = Path.Combine("Assets", exportPath);
        var assetLabelToFind = "l:al_max_export_path-" + exportPath.Replace(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
        var assetGuids = AssetDatabase.FindAssets(assetLabelToFind);

        return assetGuids.Length < 1 ? defaultPath : AssetDatabase.GUIDToAssetPath(assetGuids[0]);
    }

    public static bool Exists(string filePath)
    {
        return Directory.Exists(filePath) || File.Exists(filePath);
    }
// #endif
}
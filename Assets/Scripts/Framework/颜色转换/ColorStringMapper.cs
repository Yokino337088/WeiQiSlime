using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorStringMapper
{
    private static Dictionary<string, Color> colorDictionary = new Dictionary<string, Color>()
    {
        {"red", Color.red},
        {"blue", Color.blue},
        {"green", Color.green},
        {"yellow", Color.yellow},
        {"black", Color.black},
        {"white", Color.white},
        // 可以根据需要添加更多颜色映射
    };

    /// <summary>
    /// 转换颜色的方法
    /// </summary>
    /// <param name="colorString"></param>
    /// <returns></returns>
    public static Color GetColorFromString(string colorString)
    {
        if (colorDictionary.TryGetValue(colorString.ToLower(), out Color color))
        {
            return color;
        }
        else
        {
            Debug.LogWarning($"未找到颜色映射: {colorString}，返回白色。");
            return Color.white;
        }
    }
}

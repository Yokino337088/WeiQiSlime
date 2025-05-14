using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


/// <summary>
/// 编辑器资源管理器
/// 注意：只有在开发时能使用该管理器加载资源 用于开发功能
/// 发布后 是无法使用该管理器的 因为它需要用到编辑器相关功能
/// </summary>
public class EditorResMgr : BaseManager<EditorResMgr>
{
    //用于放置需要打包进AB包中的资源路径 
    private string rootPath = "Assets/Editor/ArtRes/";

    private EditorResMgr() { }

    //1.加载单个资源的
    public T LoadEditorRes<T>(string path) where T:Object
    {
#if UNITY_EDITOR
        string suffixName = "";
        //预设体、纹理（图片）、材质球、音效等等
        if (typeof(T) == typeof(GameObject))
            suffixName = ".prefab";
        else if (typeof(T) == typeof(Material))
            suffixName = ".mat";
        else if (typeof(T) == typeof(Texture))
            suffixName = ".png";
        else if (typeof(T) == typeof(AudioClip))
            suffixName = ".mp3";
        T res = AssetDatabase.LoadAssetAtPath<T>(rootPath + path + suffixName);
        return res;
#else
        return null;
#endif
    }

    //2.加载图集相关资源的
    public Sprite LoadSprite(string path, string spriteName)
    {
#if UNITY_EDITOR
        //加载图集中的所有子资源 
        Object[] sprites = AssetDatabase.LoadAllAssetRepresentationsAtPath(rootPath + path);
        //遍历所有子资源 得到同名图片返回
        foreach (var item in sprites)
        {
            if (spriteName == item.name)
                return item as Sprite;
        }
        return null;
#else
        return null;
#endif
    }

    //加载图集文件中的所有子图片并返回给外部
    public Dictionary<string, Sprite> LoadSprites(string path)
    {
#if UNITY_EDITOR
        Dictionary<string, Sprite> spriteDic = new Dictionary<string, Sprite>();
        Object[] sprites = AssetDatabase.LoadAllAssetRepresentationsAtPath(rootPath + path);
        foreach (var item in sprites)
        {
            spriteDic.Add(item.name, item as Sprite);
        }
        return spriteDic;
#else
        return null;
#endif
    }

}


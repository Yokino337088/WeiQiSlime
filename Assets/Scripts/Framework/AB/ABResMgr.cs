using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 用于进行加载AB相关资源的整合 在开发中可以通过EditorResMgr去加载对应资源进行测试
/// </summary>
public class ABResMgr : BaseManager<ABResMgr>
{
    //如果是true会通过EditorResMgr去加载（读 Assets/Editor/ArtRes 下的资源，不需要AB包） 如果是false会通过ABMgr AB包的形式去加载
    //注意：StreamingAssets 里目前只有 Android 平台的AB包，在Windows编辑器里跑必须为true，
    //否则 ABMgr 会去找 StreamingAssets/PC 找不到，导致UI面板等资源全部加载失败。发布包不受这里影响（外面有 #if UNITY_EDITOR）
    private bool isDebug = true;

    private ABResMgr() { }

    public void LoadResAsync<T>(string abName, string resName, UnityAction<T> callBack, bool isSync = false) where T:Object
    {
#if UNITY_EDITOR
        if(isDebug)
        {
            //我们自定义了一个AB包中资源的管理方式 对应文件夹名 就是包名 
            T res = EditorResMgr.Instance.LoadEditorRes<T>($"{abName}/{resName}");
            callBack?.Invoke(res as T);
        }
        else
        {
            ABMgr.Instance.LoadResAsync<T>(abName, resName, callBack, isSync);
        }
#else
        ABMgr.Instance.LoadResAsync<T>(abName, resName, callBack, isSync);
#endif
    }

    
}

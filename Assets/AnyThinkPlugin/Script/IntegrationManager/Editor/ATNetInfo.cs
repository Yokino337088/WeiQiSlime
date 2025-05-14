using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


using UnityEngine;

namespace AnyThink.Scripts.IntegrationManager.Editor
{
    public static class ATNetInfo {
        //插件的配置文件:unity_plugin_config.json
        public static string getPluginConfigUrl(String plugin_version) 
        {
            return "https://topon-sdk-release.oss-cn-hangzhou.aliyuncs.com/Unity_Release/plugin/" + plugin_version + "/unity_plugin_config.json";
        }
        //插件版本对应的network列表文件：unity_plugin_config_network.json
        public static string getNetworkListUrl(String plugin_version)
        {
            return "https://topon-sdk-release.oss-cn-hangzhou.aliyuncs.com/Unity_Release/plugin/" + plugin_version + "/unity_plugin_config_network.json";
        }
        //插件unitypackage名字
        public static string getPluginFileName(string pluginVersion)
        {
            return "AnyThinkPlugin_" + pluginVersion + ".unitypackage";
        }
        //插件unitypackage的下载链接
        public static string getPluginDownloadUrl(string pluginVersion)
        {
            return "https://topon-sdk-release.oss-cn-hangzhou.aliyuncs.com/Unity_Release/plugin/" + pluginVersion + "/" + getPluginFileName(pluginVersion);
        }

        public static string getHotfixPluginDownloadUrl(string pluginVersion)
        {
            return "https://topon-sdk-release.oss-cn-hangzhou.aliyuncs.com/Unity_Release/plugin/" + pluginVersion + "/hotfix/hotfix_config.json";
        }
    }
    
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

namespace AnyThink.Scripts.IntegrationManager.Editor
{
    public class ATDataUtil
    {

        public static Network coreNetwork;

        public static Network[] parseNetworksJson(PluginData pluginData, string netowrksJson)
        {
            try
            {
                int country = pluginData.country;
                bool isChinaCountry = isChina(country);

                ServerNetworks serverNetworks = JsonUtility.FromJson<ServerNetworks>(netowrksJson);

                Network network = pluginData.anyThink;
                if (network == null) {
                    return null;
                }
                var android_version = pluginData.requestParams.androidVersion;
                var ios_version = pluginData.requestParams.iosVersion;

                var androidSdkVersionList = serverNetworks.android_sdk;
                var iosSdkVersionList = serverNetworks.ios_sdk;

                ServerNetworkSdk androidNeworkSdk = null;
                if (!string.IsNullOrEmpty(android_version)) {
                    foreach(ServerNetworkSdk sdk in androidSdkVersionList) {
                        if (Equals(sdk.version, android_version)) {
                            androidNeworkSdk = sdk;
                        }
                    }
                }
             
                ServerNetworkSdk iosNeworkSdk = null;
                if (!string.IsNullOrEmpty(ios_version)) {     
                    foreach(ServerNetworkSdk sdk in iosSdkVersionList) {
                        if (Equals(sdk.version, ios_version)) {
                            iosNeworkSdk = sdk;
                        }
                    }
                }
                ATLog.log("parseNetworksJson() >>> androidNeworkSdk: " + androidNeworkSdk + " iosNeworkSdk: " + iosNeworkSdk);

                ServerNetworkInfo[] serverNetworkInfoList;
                Network[] networks = mergeAndroidIosNetworks(getServerNetworkInfo(isChinaCountry, androidNeworkSdk, ATConfig.OS_ANDROID), getServerNetworkInfo(isChinaCountry, iosNeworkSdk,  ATConfig.OS_IOS));
                Array.Sort(networks);
                ATLog.log("parseNetworksJson() >>> networks.Length: " + networks.Length);
                //处理本地已安装过的Core和Network数据
                var countrySettingData = pluginData.pluginSettingData.getCountrySettingData();

                List<Network> networkList = new List<Network>();
                foreach(var item in networks) {
                    if (Equals(item.Name, ATIntegrationManager.AnyThinkNetworkName)) {
                        network.Name = item.Name;
                        network.DisplayName = item.DisplayName;
                        network.AndroidDownloadUrl = item.AndroidDownloadUrl;
                        network.iOSDownloadloadUrl = item.iOSDownloadloadUrl;
                        network.PluginFileName = item.PluginFileName;
                        //本地是否有安装core
                        var version = network.CurrentVersions;
                        if (version == null) {
                            version = new Versions();
                        }
                        version.Android = countrySettingData.android_version;
                        version.Ios = countrySettingData.ios_version;
                        network.CurrentVersions = version;
                        network.LatestVersions = item.LatestVersions;
                    } else {
                        // ATLog.log("parseNetworksJson() >>> lastAndroidVersion: " + item.LatestVersions.Android + " lastIosVerion: " + item.LatestVersions.Ios);
                        //本地是否有安装network
                        ATConfig.initNetworkLocalData(item);
                        networkList.Add(item);
                    }
                }

                return networkList.ToArray();
            }
            catch (Exception e)
            {
                // 错误处理代码
                ATLog.log("parseNetworksJson() >>> failed: " + e);
            }

            return null;
        }

        public static PluginData parsePluginDataJson(string serverPluginVersionJson)
        {
            ATLog.log("parsePluginDataJson plugin version data: " + serverPluginVersionJson);

            try
            {
                var pluginData = new PluginData();

                ServerPluginVersion serverPluginVersion = JsonUtility.FromJson<ServerPluginVersion>(serverPluginVersionJson);

                pluginData.androidVersions = serverPluginVersion.android_versions;
                pluginData.iosVersions = serverPluginVersion.ios_versions;
                pluginData.pluginVersion = serverPluginVersion.pluginVersion;
                // 初始化本地的core包数据
                var settingData = ATConfig.getPluginSettingData();
                if (settingData == null) {
                   settingData = new PluginSettingData();
                   ATConfig.savePluginSettingData(settingData);
                }
                pluginData.country = settingData.curCountry;
                pluginData.pluginSettingData = settingData;
                pluginData.anyThink = initCoreNetworkWithLocalData(settingData);
                return pluginData;
            }
            catch (Exception e)
            {
                // 错误处理代码
                ATLog.log("parse version data failed: " + e);
            }

            return null;
        }

        public static Network initCoreNetworkWithLocalData(PluginSettingData settingData) {
            var network = new Network();
            var versions = new Versions();
            var countryData = settingData.getCountrySettingData();
            if (countryData != null) {
                versions.Android = countryData.android_version;
                versions.Ios = countryData.ios_version;
            }
            network.CurrentVersions = versions;
            network.Country = settingData.curCountry;
            return network;
        }

        public static ServerNetworkInfo[] getServerNetworkInfo(bool isChina, ServerNetworkSdk serverNetworks, int os) {
            if (serverNetworks == null) {
                return null;
            }
            if (isChina) {
                return serverNetworks.network_list.china;
            } else {
                return serverNetworks.network_list.nonchina;
            }
        }

        private static IEnumerable<ServerNetworkInfo> GetUniqueNetworkInfo(ServerNetworkInfo[] androidNetworks, ServerNetworkInfo[] iosNetworks)
        {
            // Android独有的
            var uniqueToAndroid = androidNetworks.Where(a => !iosNetworks.Any(i => i.name == a.name));

            // iOS独有的
            var uniqueToIos = iosNetworks.Where(i => !androidNetworks.Any(a => a.name == i.name));
                
            // 合并结果
            return uniqueToAndroid.Concat(uniqueToIos);
        }

        //合并Android和iOS的network数据
        public static Network[] mergeAndroidIosNetworks(ServerNetworkInfo[] androidNetworks, ServerNetworkInfo[] iosNetworks)
        {
            int a_length = 0;
            int i_length = 0;
            if (androidNetworks != null) {
               a_length = androidNetworks.Length;
            }
            if (iosNetworks != null) {
               i_length = iosNetworks.Length;
            }
            ATLog.log("mergeAndroidIosNetworks() >>> a_length: " + a_length + " i_length: " + i_length);

            int max_length = Math.Max(a_length, i_length);
            int min_length = Math.Min(a_length, i_length);

            var externalNetworks = androidNetworks;
            var internalNetworks = iosNetworks;
            if (a_length < i_length) {
                externalNetworks = iosNetworks;
                internalNetworks = androidNetworks;
            }

            List<Network> networkList = new List<Network>();
            ATLog.log("mergeAndroidIosNetworks() >>> max_length: " + max_length + " min_length: " + min_length);
            for (int i = 0; i < max_length; i++) {
                var network = new Network();
                var iNetwork = externalNetworks[i];
                if (min_length == 0) {
                    //只有集成一个平台
                    network = flatServerNetwork(iNetwork, network);
                    networkList.Add(network);
                } else {
                    //合并相同的network
                    for (int j = 0; j < min_length; j++) {
                        var jNetwork = internalNetworks[j];
                        if (Equals(iNetwork.name, jNetwork.name)) {
                            network = flatServerNetwork(iNetwork, network);
                            network = flatServerNetwork(jNetwork, network);
                            networkList.Add(network);
                        }
                    }
                }
            }
            //过滤平台的唯一network
            if (i_length > 0 && a_length > 0) {
                var serverNetworkInfos = GetUniqueNetworkInfo(androidNetworks, iosNetworks);
                foreach (var serverNetworkInfo in serverNetworkInfos)
                {
                    var network = new Network();
                    networkList.Add(flatServerNetwork(serverNetworkInfo, network));
                }
            }

            return networkList.ToArray();
        }

        //后台下载数据转换成本地数据
        public static Network flatServerNetwork(ServerNetworkInfo serverInfo, Network network)
        {
            network.Name = serverInfo.name;
            network.DisplayName = serverInfo.displayName;
            network.Country = serverInfo.country;
            network.PluginFileName = serverInfo.pluginFileName;

            var versions = network.LatestVersions;
            if (versions == null) {
                versions = new Versions();
            }
            if (serverInfo.os == ATConfig.OS_ANDROID) { //Android
                network.AndroidDownloadUrl = serverInfo.downloadUrl;
                versions.Android = serverInfo.version;
            } else { //iOS
                network.iOSDownloadloadUrl = serverInfo.downloadUrl;
                versions.Ios = serverInfo.version;
            }
            ATLog.log("flatServerNetwork() >>> name: " + network.Name + " androidVersion: " + versions.Android + " iosVersion: " + versions.Ios);
            network.LatestVersions = versions;
            return network;
        }

        public static bool isChina(int country)
        {
            return country == ATConfig.CHINA_COUNTRY;
        }


        //只比较Android、iOS
        public static VersionComparisonResult CompareVersions(string versionA, string versionB)
        {
            if (string.IsNullOrEmpty(versionA) || string.IsNullOrEmpty(versionB) || versionA.Equals(versionB))
            {
                return VersionComparisonResult.Equal;
            }

            try
            {
                var aVersionArrays = versionA.Split('.');
                var bVersionArrays = versionB.Split('.');

                var arrayLength = Mathf.Min(aVersionArrays.Length, bVersionArrays.Length);
                for (var i = 0; i < arrayLength; i++)
                {
                    var aVersionStr = aVersionArrays[i];
                    var bVersionStr = bVersionArrays[i];

                    var aVersionInt = int.Parse(aVersionStr);
                    var bVersionInt = int.Parse(bVersionStr);

                    if (i == arrayLength - 1) //末尾最后一个
                    {
                        if (aVersionStr.Length > bVersionStr.Length)
                        {
                            int gapLength = aVersionStr.Length - bVersionStr.Length;
                            bVersionInt = bVersionInt * (gapLength * 10);
                        }
                        else if (aVersionStr.Length < bVersionStr.Length)
                        {
                            int gapLength = bVersionStr.Length - aVersionStr.Length;
                            aVersionInt = aVersionInt * (gapLength * 10);
                        }
                    }
                    if (aVersionInt < bVersionInt) return VersionComparisonResult.Lesser;
                    if (aVersionInt > bVersionInt) return VersionComparisonResult.Greater;
                }
            }
            catch (Exception e)
            {
                ATLog.logError("CompareVersions failed: " + e.Message);
            }

            return VersionComparisonResult.Equal;
        }
    }

    //下发的插件数据：{"pluginVersion": "2.1.0", "platformName": "AnyThink", "ios_versions": ["6.2.88"], "android_versions": ["6.2.93"]}
    [Serializable]
    public class ServerPluginVersion
    {
        public string platformName;
        // public string networkUrlVersion;
        public string pluginVersion;
        public string[] android_versions;
        public string[] ios_versions;
    }

    [Serializable]
    public class ServerNetworks
    {
        public string plugin_version;
        public ServerNetworkSdk[] ios_sdk;
        public ServerNetworkSdk[] android_sdk;
    }

    [Serializable]
    public class ServerNetworkSdk
    {
        public string version;
        public ServerNetworkListObj network_list; 
    }

    [Serializable]
    public class ServerNetworkListObj
    {
        public ServerNetworkInfo[] china;
        public ServerNetworkInfo[] nonchina;
    }

    [Serializable]
    public class ServerNetworkInfo
    {
        public string name;
        public string displayName;
        public string downloadUrl;
        public string pluginFileName;
        public string version;
        public int os;
        public int country;
        // public ServerNetworkVersion versions;
    }
    [Serializable]
    public class ServerNetworkVersion
    {
        public string android;
        public string ios;
        public string unity;
    }
}
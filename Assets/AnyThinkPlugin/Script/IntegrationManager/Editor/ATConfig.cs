using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
// using AnyThink.Scripts.Assets;
using System.Text.RegularExpressions;

namespace AnyThink.Scripts.IntegrationManager.Editor
{

    public class ATConfig
    {
public static string PLUGIN_VERSION = "2.1.5";
public static bool isDebug = false;

        public static int PLUGIN_TYPE = 1;
        public static int OS_ANDROID = 1;
        public static int OS_IOS = 2;
        public static int CHINA_COUNTRY = 1;
        public static int NONCHINA_COUNTRY = 2;
        public static string ANYTHINK_SDK_FILES_PATH = "Assets/AnyThinkPlugin/AnyThinkAds";
        //国内Android core包的相关目录
        public static string[] CHINA_ANDROID_CORE_FILES_ARRAY = {Path.Combine(ANYTHINK_SDK_FILES_PATH, "Plugins/Android/China/Editor"), 
        Path.Combine(ANYTHINK_SDK_FILES_PATH, "Plugins/Android/China/anythink_base"), 
        Path.Combine(ANYTHINK_SDK_FILES_PATH, "Plugins/Android/China/mediation_plugin")};
        //海外Android core包的相关目录
        public static string[] NON_CHINA_ANDROID_CORE_FILES_ARRAY = {Path.Combine(ANYTHINK_SDK_FILES_PATH, "Plugins/Android/NonChina/anythink_base"), 
        Path.Combine(ANYTHINK_SDK_FILES_PATH, "Plugins/Android/NonChina/Editor")};

        //国内core aar包的父目录
        public static string CHINA_ANDROID_CORE_FILES_PATH = Path.Combine(ANYTHINK_SDK_FILES_PATH, "Plugins/Android/China/anythink_base/");
        public static string NONCHINA_ANDROID_CORE_FILES_PATH = Path.Combine(ANYTHINK_SDK_FILES_PATH, "Plugins/Android/NonChina/anythink_base/");
        //国内Android network aar包的父目录
        public static string CHINA_ANDROID_NETWORK_FILES_PARENT_PATH = Path.Combine(ANYTHINK_SDK_FILES_PATH, "Plugins/Android/China/mediation/");
        //海外Android network 依赖文件的目录
        public static string NONCHINA_ANDROID_NETWORK_FILES_PARENT_PATH = Path.Combine(ANYTHINK_SDK_FILES_PATH, "Plugins/Android/NonChina/mediation/");
        //iOS network依赖文件的目录，不区分国家
        public static string IOS_NETWORK_FILES_PARENT_PATH = Path.Combine(ANYTHINK_SDK_FILES_PATH, "Plugins/iOS/China/");
        public static string NONCHINA_IOS_NETWORK_FILES_PARENT_PATH = Path.Combine(ANYTHINK_SDK_FILES_PATH, "Plugins/iOS/NonChina/");
        //network json文件名
        public static string network_data_file_name = "network_data.json";
        //插件设置的数据
        public static string plugin_setting_data_path = "Assets/AnyThinkPlugin/Resources/json/" + PLUGIN_VERSION;
        private static string plugin_setting_data_file_name = "plugin_setting_data.json";

        //保存插件设置的数据，保存时机：安装core包、选择国家、切换SDK、androidX设置发生变化时
        public static void savePluginSettingData(PluginSettingData settingData)
        {
            var directoryPath = plugin_setting_data_path;
            // 确保目标文件夹存在
            if (!Directory.Exists(directoryPath))
            {
                // 如果目录不存在，则创建它
                Directory.CreateDirectory(directoryPath);
            }
            string fullPath = Path.Combine(directoryPath, plugin_setting_data_file_name);
            string settingDataStr = JsonUtility.ToJson(settingData);
            ATLog.log("savePluginSettingData() >>> fullPath: " + fullPath + " settingDataStr: " + settingDataStr);
            File.WriteAllText(fullPath, settingDataStr);
        }
        //获取插件设置的数据
        public static PluginSettingData getPluginSettingData()
        {
            string fullPath = Path.Combine(plugin_setting_data_path, plugin_setting_data_file_name);
            if (!File.Exists(fullPath)) {
                return null;
            }
            string json = File.ReadAllText(fullPath);
            if(json == "") {
                return null;
            }
            return JsonUtility.FromJson<PluginSettingData>(json);
        }

        public static bool removeSdk(int country, int os) {
            string path = ANYTHINK_SDK_FILES_PATH + "/Plugins";
             if (os == OS_ANDROID) {
                path = path + "/Android";
            } else {
                path = path + "/iOS";
            }
            if (country == CHINA_COUNTRY) {
                path = path + "/China";
            } else {
                path = path + "/NonChina";
            }
            if (Directory.Exists(path)) {
                FileUtil.DeleteFileOrDirectory(path);
            }
            if (File.Exists(path + ".meta")) {
                FileUtil.DeleteFileOrDirectory(path + ".meta");
            }
            return true;
        }

        //移除本地的network
        public static bool removeInstalledNetwork(Network network, int os)
        {
             //修改sdk的配置
            if (isCoreNetwork(network.Name) && os == OS_ANDROID) {
                var paths = CHINA_ANDROID_CORE_FILES_ARRAY;
                if (network.Country == NONCHINA_COUNTRY) {
                    paths = NON_CHINA_ANDROID_CORE_FILES_ARRAY;
                }
                foreach(string p in paths) {
                    if (Directory.Exists(p)) {
                        FileUtil.DeleteFileOrDirectory(p);
                    }
                    if (File.Exists(p + ".meta")) {
                        FileUtil.DeleteFileOrDirectory(p + ".meta");
                    }
                }
                return true;
            }
            var path = getAndroidNetworkPath(network);
            if (os == OS_IOS) {
                path = getIosNetworkPath(network);
            }
            if (Directory.Exists(path)) {
                FileUtil.DeleteFileOrDirectory(path);
                if (File.Exists(path + ".meta")) {
                    FileUtil.DeleteFileOrDirectory(path + ".meta");
                }
            }
            return true;
        }

        // 保存已安装的network到本地
        public static void saveInstalledNetworkVersion(Network network, int os)
        {
            if (isCoreNetwork(network.Name)) {
                return;
            }
            var networkDataFileName = network_data_file_name;
            var networkName = network.Name.ToLower();
            int country = network.Country;
            var installedVersions = network.CurrentVersions;
            if (installedVersions != null) {
                if (os == OS_ANDROID) {
                    var android_version = installedVersions.Android;
                    //Android 
                    if (!string.IsNullOrEmpty(android_version)) {
                        var networkPath = getAndroidNetworkPath(network);
                        Directory.CreateDirectory(networkPath);
                        ATLog.log("saveInstalledNetworkVersion() >>> android networkPath: " + networkPath + " exist: " + Directory.Exists(networkPath));
                        if (Directory.Exists(networkPath)) {
                            string fullPath = Path.Combine(networkPath, networkDataFileName);
                            var networkData = new NetworkLocalData();
                            networkData.name = networkName;
                            networkData.country = country;
                            networkData.version = android_version;
                            networkData.path = networkPath;

                            File.WriteAllText(fullPath, JsonUtility.ToJson(networkData));
                        }
                    }
                } else {
                    //iOS
                    var ios_version = installedVersions.Ios;
                    if (!string.IsNullOrEmpty(ios_version)) {
                        var networkPath = getIosNetworkPath(network);
                        Directory.CreateDirectory(networkPath);
                        ATLog.log("saveInstalledNetworkVersion() >>> ios networkPath: " + networkPath);
                        if (Directory.Exists(networkPath)) {
                            string fullPath = Path.Combine(networkPath, networkDataFileName);
                            var networkData = new NetworkLocalData();
                            networkData.name = networkName;
                            networkData.country = country;
                            networkData.version = ios_version;
                            networkData.path = networkPath;

                            File.WriteAllText(fullPath, JsonUtility.ToJson(networkData));
                        }
                    }
                }
            }
        }

        //Core 是否已安装
        public static bool isCoreNetworkInstalled(PluginSettingData pluginSettingData, int os) {
            var countrySettingData = pluginSettingData.getCountrySettingData();
            if (os == OS_ANDROID) {
                return !string.IsNullOrEmpty(countrySettingData.android_version);
            } else {
                return !string.IsNullOrEmpty(countrySettingData.ios_version);
            }
        }

        //Network是否已安装
        public static bool isNetworkInstalled(Network network, int os)
        {
            if (isCoreNetwork(network.Name)) {
                var pluginSettingData = getPluginSettingData();
                return isCoreNetworkInstalled(pluginSettingData, os);
            }
            var path = getIosNetworkPath(network);
            if (os == OS_ANDROID) {
                path = getAndroidNetworkPath(network);
            }
            return File.Exists(Path.Combine(path, network_data_file_name));
        }

        //Network是否已安装，根据name
        public static bool isNetworkInstalledByName(string name, int os)
        {
            var pluginSettingData = getPluginSettingData();
            if (pluginSettingData != null) {
                var country = pluginSettingData.curCountry;
                var network = new Network();
                network.Name = name;
                network.Country = country;
                return isNetworkInstalled(network, os);
            }
            return false;
        }

        private static string getAndroidNetworkPath(Network network)
        {
            var networkName = network.Name.ToLower();
            var country = network.Country;
            if (isCoreNetwork(networkName))
            {
                return country == CHINA_COUNTRY ? CHINA_ANDROID_CORE_FILES_PATH : NONCHINA_ANDROID_CORE_FILES_PATH;
            }
            else
            {
                return country == CHINA_COUNTRY ? CHINA_ANDROID_NETWORK_FILES_PARENT_PATH + networkName.ToLower() : NONCHINA_ANDROID_NETWORK_FILES_PARENT_PATH + networkName.ToLower();
            }
        }

        private static string getIosNetworkPath(Network network)
        {
            var networkName = network.Name.ToLower();
            var country = network.Country;
            // if (isCoreNetwork(networkName))
            // {
            //     return IOS_NETWORK_FILES_PARENT_PATH;
            // } else {
            // }
            return country == CHINA_COUNTRY ? IOS_NETWORK_FILES_PARENT_PATH + networkName : NONCHINA_IOS_NETWORK_FILES_PARENT_PATH + networkName;
        }

        
        public static int getSelectedCountry() {
            var pluginSettingData = getPluginSettingData();
            if (pluginSettingData != null) {
                return pluginSettingData.curCountry;
            }
            return CHINA_COUNTRY;
        }


        public static bool isCoreNetwork(string networkName) {
            return Equals(networkName.ToLower(), ATIntegrationManager.AnyThinkNetworkName.ToLower());
        }

        //查找本地是否有已安装network，并进行版本赋值
        public static void initNetworkLocalData(Network network) {
            var networkDataFileName = network_data_file_name;
            var androidPath = getAndroidNetworkPath(network);
            var iosPath = getIosNetworkPath(network);

            var androidDataFile = Path.Combine(androidPath, networkDataFileName);
            var iosDataFile = Path.Combine(iosPath, networkDataFileName);

            var curVersions = network.CurrentVersions;
            if (curVersions == null) {
                curVersions = new Versions();
            }

            if (File.Exists(androidDataFile)) {
                string a_json = File.ReadAllText(androidDataFile);
                var a_data = JsonUtility.FromJson<NetworkLocalData>(a_json);
                curVersions.Android = a_data.version;
            }
           
            if (File.Exists(iosDataFile)) {
                string i_json = File.ReadAllText(iosDataFile);
                var i_data = JsonUtility.FromJson<NetworkLocalData>(i_json);
                curVersions.Ios = i_data.version;
            }
            network.CurrentVersions = curVersions;
        }

        //当前是否选择国内地区
        public static bool isSelectedChina() {
            var pluginSettingData = getPluginSettingData();
            if (pluginSettingData != null) {
                return pluginSettingData.curCountry == CHINA_COUNTRY;
            }
            return true;
        }

        //获取admob app id
        public static string getAdmobAppIdByOs(int os) {
            var pluginSettingData = getPluginSettingData();
            if (pluginSettingData == null) {
                return "";
            }
            var settingData = pluginSettingData.getCountrySettingData();
            return settingData.getAdmobAppId(os);
        }

        public static bool enableAndroidX() {
            var pluginSettingData = getPluginSettingData();
            if (pluginSettingData == null) {
                return false;
            }
            return pluginSettingData.getCountrySettingData().androidXSetting == 1;
        }

        public static bool isDefaultAndroidX() {
            var pluginSettingData = getPluginSettingData();
            if (pluginSettingData == null) {
                return false;
            }
            return pluginSettingData.getCountrySettingData().androidXSetting == 0;
        }

        //获取默认选中的地区
        public static int getDefCountry() {
            // string version = PLUGIN_VERSION;
            // int lastIndex = version.LastIndexOf('.');
        
            // if (lastIndex != -1)
            // {   
            //     //2.1.0：是区分国内海外的插件，2.1.01:后缀多了1，是只有海外的插件
            //     string lastPart = version.Substring(lastIndex + 1);
            //     if (lastPart.Length == 2) {
            //         return NONCHINA_COUNTRY;
            //     }
            // }
            if(PLUGIN_TYPE == 2) {
                return NONCHINA_COUNTRY;
            }
            return CHINA_COUNTRY;
        }

        public static string[] getCountryArray() {
            // new string[] { "ChinaMainland", "Overseas" }
            // string version = PLUGIN_VERSION;
            // int lastIndex = version.LastIndexOf('.');
        
            // if (lastIndex != -1)
            // {   
            //     //2.1.0：是区分国内海外的插件，2.1.01:后缀多了1，是只有海外的插件
            //     string lastPart = version.Substring(lastIndex + 1);
            //     if (lastPart.Length == 2) {
            //         return new string[] { "Overseas" };
            //     }
            // }
            if(PLUGIN_TYPE == 2) {
                return new string[] { "Overseas" };
            }
            return new string[] { "ChinaMainland", "Overseas" };
        }

        public static string getRegionIntegrateTip()
        {
            //Tips: If ChinaMainland and Oversea are integrated at the same time, there will be compilation conflicts, whether it is Android or iOS platform.
            //Currently, the Android platform integrates ChinaMainland and Oversea at the same time, which may cause compilation errors or other errors.
            var pluginSettingData = getPluginSettingData();
            if (pluginSettingData == null) {
                return "";
            }
            var sb = new StringBuilder();
            sb.Append("Tips: Currently, ");
            var android_tip = false;
            if (pluginSettingData.isBothInstallAndroid()) {
                sb.Append("the Android platform ");
                android_tip = true;
            }
            var ios_tip = false;
            if (pluginSettingData.isBothInstallIOS()) {
                if (android_tip) {
                    sb.Append("and ");
                }
                sb.Append("iOS platform ");
                ios_tip = true;
            }

            if (android_tip || ios_tip) {
                sb.Append("integrates ChinaMainland and Oversea at the same time, which may cause compilation error or other errors.");
                return sb.ToString();
            } else {
                return "";
            }
        }
    }

}
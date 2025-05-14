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
    [Serializable]
    public class PluginData
    {
        public string pluginVersion;    //插件版本
        public string[] androidVersions;
        public string[] iosVersions;
        public int country = ATConfig.getDefCountry(); //默认是1=china
        public Network anyThink;
        public Network[] mediatedNetworks;
        public PluginSettingData pluginSettingData;
        public NetworkRequestParams requestParams;
    }
    //请求network参数
    public class NetworkRequestParams {
        public int os;
        public string androidVersion;
        public string iosVersion;
    }

    [Serializable]
    public class Network : IComparable<Network>
    {
        //
        // Sample network data:
        //
        // {
        //   "Name": "adcolony",
        //   "DisplayName": "AdColony",
        //   "DownloadUrl": "https://bintray.com/applovin/Unity-Mediation-Packages/download_file?file_path=AppLovin-AdColony-Adapters-Android-3.3.10.1-iOS-3.3.7.2.unitypackage",
        //   "PluginFileName": "AppLovin-AdColony-Adapters-Android-3.3.10.1-iOS-3.3.7.2.unitypackage",
        //   "DependenciesFilePath": "MaxSdk/Mediation/AdColony/Editor/Dependencies.xml",
        //   "LatestVersions" : {
        //     "Unity": "android_3.3.10.1_ios_3.3.7.2",
        //     "Android": "3.3.10.1",
        //     "Ios": "3.3.7.2"
        //   }
        // }
        //

        public string Name;
        public string DisplayName;
        public string AndroidDownloadUrl;
        public string iOSDownloadloadUrl;
        // public string DependenciesFilePath;
        public string PluginFileName;
        public int Country;
        public Versions LatestVersions; //最新版本
        public Versions CurrentVersions;    //当前版本
        [NonSerialized] public VersionComparisonResult CurrentToLatestVersionComparisonResult = VersionComparisonResult.Equal;
        // [NonSerialized] public bool RequiresUpdate = CurrentToLatestVersionComparisonResult == VersionComparisonResult.Lesser;

        public bool isVersionEmpty() {
            if (LatestVersions != null) {
                ATLog.log("isVersionEmpty() >>> name: " + Name + " android: " + LatestVersions.Android + " ios: " + LatestVersions.Ios);
                return string.IsNullOrEmpty(LatestVersions.Android) && string.IsNullOrEmpty(LatestVersions.Ios);
            }
            return false;
        }

        public bool isReqiureUpdate()
        {
            return CurrentToLatestVersionComparisonResult == VersionComparisonResult.Lesser;
        }

        public int CompareTo(Network other)
        {
            return this.DisplayName.CompareTo(other.DisplayName);
        }

        public string ToString() {
            return DisplayName + "-" + AndroidDownloadUrl + "-" + iOSDownloadloadUrl + "-" + Country;
        }
    }

    /// <summary>
    /// A helper data class used to get current versions from Dependency.xml files.
    /// </summary>
    [Serializable]
    public class Versions
    {

        public string Unity;

        public string Android;

        public string Ios;

        public override bool Equals(object value)
        {
            var versions = value as Versions;

            return versions != null
                   && (Unity == null || Unity.Equals(versions.Unity))
                   && (Android == null || Android.Equals(versions.Android))
                   && (Ios == null || Ios.Equals(versions.Ios));
        }

        public bool HasEqualSdkVersions(Versions versions)
        {
            return versions != null && versions.Android == Android && versions.Ios == Ios;
        }

        public override int GetHashCode()
        {
            return new { Unity, Android, Ios }.GetHashCode();
        }

        public Versions clone()
        {
            Versions cloneObj = new Versions();
            cloneObj.Android = Android;
            cloneObj.Ios = Ios;
            cloneObj.Unity = Unity;

            return cloneObj;
        }
    }

    public enum VersionComparisonResult
    {
        Lesser = -1,
        Equal = 0,
        Greater = 1
    }

    //存在本地插件设置数据并序列化为json文件
    [Serializable]
    public class PluginSettingData
    {
        public int curCountry = ATConfig.getDefCountry();  //当前选择的国家

        public CountrySettingData china = new CountrySettingData(ATConfig.CHINA_COUNTRY);    //国内地区
        public CountrySettingData nonchina = new CountrySettingData(ATConfig.NONCHINA_COUNTRY); //海外地区

        public CountrySettingData getCountrySettingData() {
            if (curCountry == ATConfig.CHINA_COUNTRY) {
                return china;
            } else {
                return nonchina;
            }
        }

        //Android 是否同时安装了国内海外地区
        public bool isBothInstallAndroid() {
            return !string.IsNullOrEmpty(china.android_version) && !string.IsNullOrEmpty(nonchina.android_version);
        }

        //iOS 是否同时安装了国内海外地区
        public bool isBothInstallIOS() {
            return !string.IsNullOrEmpty(china.ios_version) && !string.IsNullOrEmpty(nonchina.ios_version);
        }
    }
    //已安装的sdk版本
    [Serializable]
    public class CountrySettingData
    {
    
        public string android_version;  //当前已安装Android sdk的版本号

        public string ios_version;  //当前已安装的iOS sdk的版本号

        public int androidXSetting = 0; //当前的AndroidX设置,0=default; 1=修改为AndroidX；2=修改为非AndroidX

        public int country;

        public string android_admob_app_id;
        public string ios_admob_app_id;

        public CountrySettingData(int country) {
            this.country = country;
        }

        public string getAdmobAppId(int os) {
            if (os == ATConfig.OS_ANDROID) {
                return android_admob_app_id;
            } else {
                return ios_admob_app_id;
            }
        }

        public void setAdmobAppId(string appId, int os) {
            if (os == ATConfig.OS_ANDROID) {
                android_admob_app_id = appId;
            } else {
                ios_admob_app_id = appId;  
            }
        }
    }
    //存储在本地的Network json数据
    [Serializable]
    public class NetworkLocalData
    {
        public string name;
        public string version;
        public int country;
        public string path;
    }

    [Serializable]
    public class HotfixPluginData
    {
        public string plugin_version;
        public string hot_fix_version;
        public string download_url;
        public int status;
        public string file_name;
    }
}


using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
using UnityEditor.PackageManager.Requests;
using UnityEditor.PackageManager;
using System.Threading.Tasks;
using System.Threading;

namespace AnyThink.Scripts.IntegrationManager.Editor
{
    public class ATIntegrationManager
    {
        public static ATIntegrationManager Instance = new ATIntegrationManager();

        // private UnityWebRequest downloadPluginRequest;

        private const string AnyThinkAds = "AnyThinkAds";
        //AnyThink的unity插件
        public static string AnyThinkNetworkName = "Core";

        private PluginData mPluginData;

        private ATIntegrationManager()
        {

        }

        public void CancelDownload()
        {
            // if (downloadPluginRequest == null) return;

            // downloadPluginRequest.Abort();
        }

        public IEnumerator loadPluginData(Action<PluginData> callback)
        {
            var anythinkVersionRequest = UnityWebRequest.Get(ATNetInfo.getPluginConfigUrl(ATConfig.PLUGIN_VERSION));
            var webRequest = anythinkVersionRequest.SendWebRequest();
            while (!webRequest.isDone)
            {
                yield return new WaitForSeconds(0.1f);
            }

#if UNITY_2020_1_OR_NEWER
            if (anythinkVersionRequest.result != UnityWebRequest.Result.Success)
#elif UNITY_2017_2_OR_NEWER
            if (anythinkVersionRequest.isNetworkError || anythinkVersionRequest.isHttpError)
#else
            if (anythinkVersionRequest.isError)
#endif
            {
                Debug.Log("loadPluginData failed.");
                callback(null);
            }
            else
            {
                //解析Anythink的版本数据
                string anythinkVersionJson = anythinkVersionRequest.downloadHandler.text;
                PluginData pluginData = ATDataUtil.parsePluginDataJson(anythinkVersionJson);
                Debug.Log("loadPluginData succeed. country: " + pluginData.country + " androidVersions: " 
                + pluginData.androidVersions + " iosVersions: " + pluginData.iosVersions);
                mPluginData = pluginData;
                callback(pluginData);
            }
        }

        public IEnumerator loadNetworksData(PluginData pluginData, Action<PluginData> callback)
        {

            Network network = pluginData.anyThink;
            if (pluginData == null)
            {
                callback(null);
            }
            else if (pluginData.requestParams == null) {
                ATLog.log("loadNetworksData() >>> pluginData.requestParams is null");
                callback(pluginData);
            }
            else
            {
                var networksRequest = UnityWebRequest.Get(ATNetInfo.getNetworkListUrl(ATConfig.PLUGIN_VERSION));
                var webRequest = networksRequest.SendWebRequest();
                while (!webRequest.isDone)
                {
                    yield return new WaitForSeconds(0.1f);
                }

#if UNITY_2020_1_OR_NEWER
            if (networksRequest.result != UnityWebRequest.Result.Success)
#elif UNITY_2017_2_OR_NEWER
            if (networksRequest.isNetworkError || networksRequest.isHttpError)
#else
                if (networksRequest.isError)
#endif
                {
                    Debug.Log("loadNetworksData failed.");
                    callback(pluginData);
                }
                else
                {
                    //解析network列表的版本数据
                    string netowrksJson = networksRequest.downloadHandler.text;
                    ATLog.log("loadNetworksData() >>> netowrksJson: " + netowrksJson);
                    pluginData.mediatedNetworks = ATDataUtil.parseNetworksJson(pluginData, netowrksJson);
                    ATLog.log("loadNetworksData() >>> mediatedNetworks: " + pluginData.mediatedNetworks);
                    mPluginData = pluginData;
                    callback(pluginData);
                }
            }
        }

        /// <summary>
        /// Downloads the plugin file for a given network.
        /// </summary>
        /// <param name="network">Network for which to download the current version.</param>
        /// <param name="showImport">Whether or not to show the import window when downloading. Defaults to <c>true</c>.</param>
        /// <returns></returns>
        public void downloadPlugin(Network network, int os =1, bool showImport = false)
        {
            ATEditorCoroutine.startCoroutine(downloadPluginWithEnumerator(network, os, showImport));
        }

        public IEnumerator downloadPluginWithEnumerator(Network network, int os, bool showImport)
        {
            ATLog.log("downloadPluginWithEnumerator() >>> networkName: " + network.Name + " os: " + os);
            // if (downloadPluginRequest != null)
            // {
            //     downloadPluginRequest.Dispose();
            // }
            var path = Path.Combine(Application.temporaryCachePath, network.PluginFileName);
            ATLog.log("downloadPluginWithEnumerator() >>> path: " + path);
#if UNITY_2017_2_OR_NEWER
            var downloadHandler = new DownloadHandlerFile(path);
#else
            var downloadHandler = new ATDownloadHandler(path);
#endif
            var downloadUrl = network.AndroidDownloadUrl;
            if (os == ATConfig.OS_IOS) 
            {
                downloadUrl = network.iOSDownloadloadUrl;
            }
            UnityWebRequest downloadPluginRequest = new UnityWebRequest(downloadUrl) 
            {    method = UnityWebRequest.kHttpVerbGET,
                downloadHandler = downloadHandler
            };

#if UNITY_2017_2_OR_NEWER
            var operation = downloadPluginRequest.SendWebRequest();
#else
            var operation = downloadPluginRequest.Send();
#endif
            while (!operation.isDone)
            {
                yield return new WaitForSeconds(0.1f); // Just wait till downloadPluginRequest is completed. Our coroutine is pretty rudimentary.
                if (operation.progress != 1 && operation.isDone)
                {
                    // CallDownloadPluginProgressCallback(network.DisplayName, operation.progress, operation.isDone, os);
                    UpdateCurrentVersions(network, os);
                }
            }

#if UNITY_2020_1_OR_NEWER
            if (downloadPluginRequest.result != UnityWebRequest.Result.Success)
#elif UNITY_2017_2_OR_NEWER
            if (downloadPluginRequest.isNetworkError || downloadPluginRequest.isHttpError)
#else
            if (downloadPluginRequest.isError)
#endif
            {
                ATLog.logError(downloadPluginRequest.error);
            }
            else
            {
                AssetDatabase.ImportPackage(path, showImport);
                UpdateCurrentVersions(network, os);
                AssetDatabase.Refresh();
            }
            downloadPluginRequest.Dispose();
            downloadPluginRequest = null;
        }

         //默认下载core包，在下载完network的数据时。
        public void downloadCorePlugin(PluginData pluginData)
        {   
            mPluginData = pluginData;
            var requestParams = pluginData.requestParams;
            var pluginSettingData = pluginData.pluginSettingData;

            bool isIosInstalled = ATConfig.isCoreNetworkInstalled(pluginSettingData, ATConfig.OS_IOS);
            bool isAndroidInstalled = ATConfig.isCoreNetworkInstalled(pluginSettingData, ATConfig.OS_ANDROID);
            ATLog.log("downloadCorePlugin() >>> isIosInstalled: " + isIosInstalled + " isAndroidInstalled: " + isAndroidInstalled);

            Network network = pluginData.anyThink;
            int os = requestParams.os;
            if (os == ATConfig.OS_ANDROID) {
                if (!isAndroidInstalled) {
                    downloadPlugin(network, os);
                } else {
                    //判断是否需要切换SDK
                    var latestVersions = network.LatestVersions;
                    var curVersion = network.CurrentVersions;
                    if (latestVersions.Android != curVersion.Android) {
                        //先删除掉core包
                        ATConfig.removeSdk(pluginData.country, os);
                        removeNetworkVersions(pluginData, os);
                        //赋值当前版本为空
                        curVersion.Android = "";
                        //重新下载core包
                        downloadPlugin(network, os);
                        //重新下载已安装的network
                        redownloadNetworksPlugin(pluginData, os);
                    }
                }
            } else if (os == ATConfig.OS_IOS){
                if (!isIosInstalled) {
                    downloadPlugin(network, os);
                } else {
                    //判断是否需要切换SDK
                    var latestVersions = network.LatestVersions;
                    var curVersion = network.CurrentVersions;
                    if (latestVersions.Ios != curVersion.Ios) {
                        //先删除掉core包
                        ATConfig.removeSdk(pluginData.country, os);
                        removeNetworkVersions(pluginData, os);
                        //赋值当前版本为空
                        curVersion.Ios = "";
                        //重新下载core包
                        downloadPlugin(network, os);
                        //重新下载已安装的network
                        redownloadNetworksPlugin(pluginData, os);
                    }
                }
            }
        }

        //当切换SDK版本时，需要重新下载已安装的network
        private void redownloadNetworksPlugin(PluginData pluginData, int os) {
            var mediatedNetworks = pluginData.mediatedNetworks;
            var needInstallNetworkList = new List<Network>();
            foreach(Network network in mediatedNetworks) {
                var currentVersion = network.CurrentVersions;
                if (currentVersion != null) {
                    if (os == ATConfig.OS_ANDROID) {
                        if (!string.IsNullOrEmpty(currentVersion.Android)) {
                            needInstallNetworkList.Add(network);
                        }
                    } else {
                        if (!string.IsNullOrEmpty(currentVersion.Ios)) {
                            needInstallNetworkList.Add(network);
                        }
                    }
                }
            }
            if (needInstallNetworkList.Count() == 0) {
                return;
            }
            Thread.Sleep(500);
            ATEditorCoroutine.startCoroutine(UpgradeAllNetworks(needInstallNetworkList, os));
        }

        private IEnumerator UpgradeAllNetworks(List<Network> networks, int os) {
            EditorApplication.LockReloadAssemblies();
            foreach (var network in networks)
            {

                yield return downloadPluginWithEnumerator(network, os, false);
            }
            EditorApplication.UnlockReloadAssemblies();
        }

        public void networkInstallOrUpdate(PluginData pluginData, Network network, int os)
        {
            downloadPlugin(network, os);
        }

        //更新network已安装的版本
        private void UpdateCurrentVersions(Network network, int os)
        {
            var latestVersions = network.LatestVersions;
            var versions = network.CurrentVersions;
            if (versions == null) {
                versions = new Versions();
            }
            if (os == ATConfig.OS_ANDROID) {
                versions.Android = latestVersions.Android;
            } else {
                versions.Ios = latestVersions.Ios;
            }
            network.CurrentVersions = versions;

            // await Task.Delay(1000);
            // Thread.Sleep(1000);
            //下面的逻辑会延迟一秒后执行，确保unitypackage先解压到本地
            ATConfig.saveInstalledNetworkVersion(network, os);
            ATLog.log("UpdateCurrentVersions() >>> AndroidVersion: " + versions.Android);
            //保存Core Networkde
            if (ATConfig.isCoreNetwork(network.Name)) {
                var countrySettingData = mPluginData.pluginSettingData.getCountrySettingData();
                if (os == ATConfig.OS_ANDROID) {
                    countrySettingData.android_version = latestVersions.Android;
                } else {
                    countrySettingData.ios_version = latestVersions.Ios;
                }
                
                ATConfig.savePluginSettingData(mPluginData.pluginSettingData);
            }
            // ATLog.log("UpdateCurrentVersions() >>> Name: " + network.Name + " latest Unity Version: " + network.LatestVersions.Unity);
        }

        //点击了界面的network删除按钮
        public void uninstallNetwork(Network network, int os)
        {
            var result = ATConfig.removeInstalledNetwork(network, os);
            if (result) {
                if (os == ATConfig.OS_ANDROID){
                    network.CurrentVersions.Android = "";
                } else {
                    network.CurrentVersions.Ios = "";
                }
            }
        }

        //切换国家
        public void switchCountry(PluginData pluginData, int country) {
            pluginData.country = country;

            var pluginSettingData = pluginData.pluginSettingData;
            pluginSettingData.curCountry = country;

            ATConfig.savePluginSettingData(pluginSettingData);
        }

        //获取AndroidX开关状态
        public int getAndroidXSetting(PluginData pluginData) {
            if (pluginData == null) {
                return 0;
            }
            var pluginSettingData = pluginData.pluginSettingData;
            if (pluginSettingData == null) {
                return 0;
            }
            CountrySettingData countrySettingData = pluginSettingData.getCountrySettingData();
            return countrySettingData.androidXSetting;
        }

        //设置并保存AndroidX开关状态
        public void saveAndroidXSetting(PluginData pluginData, int androidXSetting) {
            ATLog.log("saveAndroidXSetting() >>> androidXSetting: " + androidXSetting);
            var pluginSettingData = pluginData.pluginSettingData;
            CountrySettingData countrySettingData = pluginSettingData.getCountrySettingData();
            countrySettingData.androidXSetting = androidXSetting;

            ATConfig.savePluginSettingData(pluginSettingData);
        }

        //根据系统判断Admob是否有安装
        public bool isAdmobInstalled(int os) {
            return ATConfig.isNetworkInstalledByName("Admob", os);
        }

        public string getAdmobAppIdByOs(PluginData pluginData, int os) {
            if (pluginData == null) {
                return "";
            }
            //android_admob_app_id
            var countrySettingData = pluginData.pluginSettingData.getCountrySettingData();
            return countrySettingData.getAdmobAppId(os);
        }

        //设置保存Admob app id
        public void setAdmobAppidByOs(PluginData pluginData, int os, string appId) {
            if (pluginData == null || pluginData.pluginSettingData == null) {
                return;
            }
            var countrySettingData = pluginData.pluginSettingData.getCountrySettingData();
            countrySettingData.setAdmobAppId(appId, os);

            ATConfig.savePluginSettingData(pluginData.pluginSettingData);
        }

        //删除某个版本的SDK
        public void deleteSdk(PluginData pluginData, string sdkVersion, int os) {
            ATLog.log("deleteSdk() >>> sdkVersion: " + sdkVersion + " os: " + os);
            //删除本地文件
            ATConfig.removeSdk(pluginData.country, os);
            //修改UI显示
            removeNetworkVersions(pluginData, os, true);
            var curVersions = pluginData.anyThink.CurrentVersions;
            //修改sdk本地配置文件
            var pluginSettingData = pluginData.pluginSettingData;
            CountrySettingData countrySettingData = pluginSettingData.getCountrySettingData();

            if (os == ATConfig.OS_ANDROID) {
                curVersions.Android = "";
                countrySettingData.android_version = "";
            } else {
                curVersions.Ios = "";
                countrySettingData.ios_version = "";
            }

            ATConfig.savePluginSettingData(pluginSettingData);
        }

        private void removeNetworkVersions(PluginData pluginData, int os, bool isDeleteSdk = false) {
            if (isDeleteSdk) {
                var mediatedNetworks = pluginData.mediatedNetworks;
                if (mediatedNetworks != null && mediatedNetworks.Length > 0) {
                    foreach(Network network in mediatedNetworks) {
                        var currentVersion = network.CurrentVersions;
                        if (currentVersion != null) {
                            if (os == ATConfig.OS_ANDROID) {
                                currentVersion.Android = "";
                            } else {
                                currentVersion.Ios = "";
                            }
                        }
                        var latestVersions = network.LatestVersions;
                        if (latestVersions != null) {
                            if (os == ATConfig.OS_ANDROID) {
                                latestVersions.Android = "";
                            } else {
                                latestVersions.Ios = "";
                            }
                        }
                    }
                }
                NetworkRequestParams requestParams = pluginData.requestParams;
                if (requestParams == null) {
                    return;
                }
                if (os == ATConfig.OS_ANDROID) {  //Android 
                    requestParams.androidVersion = "";
                } else {
                    requestParams.iosVersion = "";
                }
            }         
        }
    }
}

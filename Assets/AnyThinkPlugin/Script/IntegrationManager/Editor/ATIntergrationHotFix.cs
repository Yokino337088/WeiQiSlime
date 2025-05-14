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
    public class ATIntegrationHotFix {
        public static ATIntegrationHotFix Instance = new ATIntegrationHotFix();

        private ATIntegrationHotFix()
        {
            
        }

        private static string plugin_hot_fix_data_file_name = "plugin_hot_fix_data.json";

        public void loadHotFixData()
        {
            var downloadUrl = ATNetInfo.getHotfixPluginDownloadUrl(ATConfig.PLUGIN_VERSION);
            ATLog.log("loadHotFixData() >>> downloadUrl: " + downloadUrl);
            ATEditorCoroutine.startCoroutine(loadHotFixDataWithIEnumerator(downloadUrl));
        }

        private IEnumerator loadHotFixDataWithIEnumerator(string url) {
            var hotFixDataRequest = UnityWebRequest.Get(url);
            var webRequest = hotFixDataRequest.SendWebRequest();
            while (!webRequest.isDone)
            {
                yield return new WaitForSeconds(0.1f);
            }

#if UNITY_2020_1_OR_NEWER
            if (hotFixDataRequest.result != UnityWebRequest.Result.Success)
#elif UNITY_2017_2_OR_NEWER
            if (hotFixDataRequest.isNetworkError || hotFixDataRequest.isHttpError)
#else
            if (hotFixDataRequest.isError)
#endif
            {
                // Debug.Log("loadPluginData failed.");
                // callback(null);
                ATLog.log("load hotfix data failed.");
            }
            else
            {
                //解析热修复的数据
                try {
                    string hotFixData = hotFixDataRequest.downloadHandler.text;
                    var hotFixDataObj = JsonUtility.FromJson<HotfixPluginData>(hotFixData);
                    ATLog.log("loadHotFixDataWithIEnumerator() >>> hotFixData: " + hotFixData);
                    //判断status是否需要进行热更新
                    if (hotFixDataObj.status != 1) {
                         ATLog.log("loadHotFixDataWithIEnumerator() >>> 热更新被禁止");
                    } else {
                         var localHotFixDataObj = getHotfixPluginData();
                        if (localHotFixDataObj == null) {
                            //本地未曾下载过热更新
                            ATLog.log("loadHotFixDataWithIEnumerator() >>> 本地未曾下载过热更新");
                            ATEditorCoroutine.startCoroutine(loadHotFixPlugin(hotFixDataObj));
                        } else {
                            var compareVersionResult = ATDataUtil.CompareVersions(localHotFixDataObj.hot_fix_version, hotFixDataObj.hot_fix_version);
                            ATLog.log("loadHotFixDataWithIEnumerator() >>> compareVersionResult: " + compareVersionResult);
                            //本地版本比远端版本低，则需要更新
                            if (compareVersionResult == VersionComparisonResult.Lesser) {
                                ATEditorCoroutine.startCoroutine(loadHotFixPlugin(hotFixDataObj));
                            } else {
                                //不需要热更新
                                saveHotfixData(hotFixData);
                            }
                        }
                    }
                } catch(Exception e) {
                    ATLog.logError("parseNetworksJson() >>> failed: " + e);
                }
            }
        }

        private IEnumerator loadHotFixPlugin(HotfixPluginData hotFixDataObj) {
            var path = Path.Combine(Application.temporaryCachePath, hotFixDataObj.file_name);
            ATLog.log("downloadPluginWithEnumerator() >>> path: " + path);
#if UNITY_2017_2_OR_NEWER
            var downloadHandler = new DownloadHandlerFile(path);
#else
            var downloadHandler = new ATDownloadHandler(path);
#endif
            var downloadUrl = hotFixDataObj.download_url;
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
                ATLog.log(downloadPluginRequest.error);
            }
            else
            {
                AssetDatabase.ImportPackage(path, false);
                AssetDatabase.Refresh();

                string hotFixData = JsonUtility.ToJson(hotFixDataObj);
                saveHotfixData(hotFixData);
            }
            downloadPluginRequest.Dispose();
            downloadPluginRequest = null;
        }


        private void saveHotfixData(string hotfixPluginData) {
            var directoryPath = ATConfig.plugin_setting_data_path;
             // 确保目标文件夹存在
            if (!Directory.Exists(directoryPath))
            {
                // 如果目录不存在，则创建它
                Directory.CreateDirectory(directoryPath);
            }
            string fullPath = Path.Combine(directoryPath, plugin_hot_fix_data_file_name);
            ATLog.log("saveHotfixData() >>> fullPath: " + fullPath + " hotfixPluginData: " + hotfixPluginData);
            File.WriteAllText(fullPath, hotfixPluginData);
        }

        private HotfixPluginData getHotfixPluginData() {
            string fullPath = Path.Combine(ATConfig.plugin_setting_data_path, plugin_hot_fix_data_file_name);
            if (!File.Exists(fullPath)) {
                return null;
            }
            string json = File.ReadAllText(fullPath);
            if(json == "") {
                return null;
            }
            return JsonUtility.FromJson<HotfixPluginData>(json);
        }
    }
}
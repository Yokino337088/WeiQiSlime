using System;
using System.Collections;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Text;

namespace AnyThink.Scripts.IntegrationManager.Editor
{
    public class ATIntegrationManagerWindow : EditorWindow
    {

        private const string windowTitle = "AnyThink Integration Manager";
        private const string uninstallIconExportPath = "AnyThinkPlugin/Resources/Images/uninstall_icon.png";
        private const string alertIconExportPath = "AnyThinkPlugin/Resources/Images/alert_icon.png";
        private const string warningIconExportPath = "AnyThinkPlugin/Resources/Images/warning_icon.png";

        private static readonly Color darkModeTextColor = new Color(0.29f, 0.6f, 0.8f);
        private GUIStyle titleLabelStyle;
        private GUIStyle headerLabelStyle;
        private GUIStyle environmentValueStyle;
        private GUIStyle wrapTextLabelStyle;
        private GUIStyle linkLabelStyle;
        private GUIStyle iconStyle;
        private GUIStyle tipTextStyle;
        private Texture2D uninstallIcon;
        private Texture2D alertIcon;
        private Texture2D warningIcon;
        private Vector2 scrollPosition;
        private static readonly Vector2 windowMinSize = new Vector2(850, 750);
        private const float actionFieldWidth = 80f;
        private const float upgradeAllButtonWidth = 80f;
        private const float networkFieldMinWidth = 200f;
        private const float versionFieldMinWidth = 200f;
        private const float privacySettingLabelWidth = 200f;
        private const float networkFieldWidthPercentage = 0.22f;
        private const float versionFieldWidthPercentage = 0.36f; // There are two version fields. Each take 40% of the width, network field takes the remaining 20%.
        private static float previousWindowWidth = windowMinSize.x;
        private static GUILayoutOption networkWidthOption = GUILayout.Width(networkFieldMinWidth);
        private static GUILayoutOption versionWidthOption = GUILayout.Width(versionFieldMinWidth);

        private static GUILayoutOption sdkKeyTextFieldWidthOption = GUILayout.Width(520);

        private static GUILayoutOption privacySettingFieldWidthOption = GUILayout.Width(400);
        private static readonly GUILayoutOption fieldWidth = GUILayout.Width(actionFieldWidth);
        private static readonly GUILayoutOption upgradeAllButtonFieldWidth = GUILayout.Width(upgradeAllButtonWidth);

        private ATEditorCoroutine loadDataCoroutine;
        private PluginData pluginData;
        private bool pluginDataLoadFailed;
        private bool networkButtonsEnabled = true;
        private bool shouldShowGoogleWarning;
        private int curSelectCountryInt;
        // private int dropdownIndex = 0;
        private int androidVersionPopupIndex;
        private int iosVersionPopupIndex;


        public static void ShowManager()
        {
            var manager = GetWindow<ATIntegrationManagerWindow>(utility: true, title: windowTitle, focus: true);
            manager.minSize = windowMinSize;
            // manager.maxSize = windowMinSize;
        }
        //定义UI的Style
        private void Awake()
        {
            titleLabelStyle = new GUIStyle(EditorStyles.label)
            {
                fontSize = 14,
                fontStyle = FontStyle.Bold,
                fixedHeight = 20
            };

            headerLabelStyle = new GUIStyle(EditorStyles.label)
            {
                fontSize = 12,
                fontStyle = FontStyle.Bold,
                fixedHeight = 18
            };

            environmentValueStyle = new GUIStyle(EditorStyles.label)
            {
                alignment = TextAnchor.MiddleRight
            };

            linkLabelStyle = new GUIStyle(EditorStyles.label)
            {
                wordWrap = true,
                normal = { textColor = EditorGUIUtility.isProSkin ? darkModeTextColor : Color.blue }
            };

            wrapTextLabelStyle = new GUIStyle(EditorStyles.label)
            {
                wordWrap = true
            };

            iconStyle = new GUIStyle(EditorStyles.miniButton)
            {
                fixedWidth = 18,
                fixedHeight = 18,
                padding = new RectOffset(1, 1, 1, 1)
            };

            tipTextStyle = new GUIStyle(EditorStyles.label)
            {
                normal = { textColor = Color.yellow }
            };

            // Load uninstall icon texture.
            var uninstallIconData = File.ReadAllBytes(ATSdkUtil.GetAssetPathForExportPath(uninstallIconExportPath));
            uninstallIcon = new Texture2D(100, 100, TextureFormat.RGBA32, false); // 1. Initial size doesn't matter here, will be automatically resized once the image asset is loaded. 2. Set mipChain to false, else the texture has a weird blurry effect.
            uninstallIcon.LoadImage(uninstallIconData);

            // Load alert icon texture.
            var alertIconData = File.ReadAllBytes(ATSdkUtil.GetAssetPathForExportPath(alertIconExportPath));
            alertIcon = new Texture2D(100, 100, TextureFormat.RGBA32, false);
            alertIcon.LoadImage(alertIconData);

            // Load warning icon texture.
            var warningIconData = File.ReadAllBytes(ATSdkUtil.GetAssetPathForExportPath(warningIconExportPath));
            warningIcon = new Texture2D(100, 100, TextureFormat.RGBA32, false);
            warningIcon.LoadImage(warningIconData);

            loadPluginData();
            //热更新
            ATIntegrationHotFix.Instance.loadHotFixData();
        }

        //这个方法在插件启动时会调用，然后脚本重新加载时也会重新调用，所以加载数据放在Awake中
        private void OnEnable()
        {

        }

        private void OnDisable()
        {
            if (loadDataCoroutine != null)
            {
                loadDataCoroutine.Stop();
                loadDataCoroutine = null;
            }

            ATIntegrationManager.Instance.CancelDownload();
            EditorUtility.ClearProgressBar();

            // Saves the AppLovinSettings object if it has been changed.
            AssetDatabase.SaveAssets();
        }

        private void OnDestroy() {
            ATLog.log("OnDestroy() >>> called");
        }


        private void OnGUI()
        {
            // OnGUI is called on each frame draw, so we don't want to do any unnecessary calculation if we can avoid it. So only calculate it when the width actually changed.
            if (Math.Abs(previousWindowWidth - position.width) > 1)
            {
                previousWindowWidth = position.width;
                CalculateFieldWidth();
            }
            using (var scrollView = new EditorGUILayout.ScrollViewScope(scrollPosition, false, false))
            {
                scrollPosition = scrollView.scrollPosition;
                GUILayout.Space(5);
                // EditorGUILayout.LabelField("Region (Only for Android, iOS is not affected by region)", titleLabelStyle);
                EditorGUILayout.LabelField("Region", titleLabelStyle);
                DrawCountryUI();
                DrawCountrySwitchTip();
                DrawAndroidXUI();
                DrawAdombAppId();
                EditorGUILayout.LabelField("AnyThink Plugin Details", titleLabelStyle);
                //显示插件版本号
                DrawPluginDetails();
                //绘制SDK版本下架提示
                DrawSdkVersionOffTip();
                //绘制Networks
                DrawMediatedNetworks();
            }
            if (GUI.changed)
            {
                AssetDatabase.SaveAssets();
            }
        }

        /// <summary>
        /// Callback method that will be called with progress updates when the plugin is being downloaded.
        /// </summary>
        public static void OnDownloadPluginProgress(string pluginName, float progress, bool done)
        {
            ATLog.logFormat("OnDownloadPluginProgress() >>> pluginName: {0}, progress: {1}, done: {2}", new object[] { pluginName, progress, done });
            // Download is complete. Clear progress bar.
            if (done || progress == 1)
            {
                EditorUtility.ClearProgressBar();
                AssetDatabase.Refresh();
            }
            // Download is in progress, update progress bar.
            else
            {
                if (EditorUtility.DisplayCancelableProgressBar(windowTitle, string.Format("Downloading {0} plugin...", pluginName), progress))
                {
                    ATLog.log("OnDownloadPluginProgress() >>> click cancel download");
                    ATIntegrationManager.Instance.CancelDownload();
                    EditorUtility.ClearProgressBar();
                    AssetDatabase.Refresh();
                }
            }
        }

        public void DeleteSdkVersion(PluginData pluginData, int index, int os) {
            var sdkVersion = pluginData.androidVersions[index];
            if (os == ATConfig.OS_IOS) {
                sdkVersion = pluginData.iosVersions[index];
            }
            ATIntegrationManager.Instance.deleteSdk(pluginData, sdkVersion, os);
        }

        public void ExChangeSDKVersion(PluginData pluginData, int index, int os) {
            NetworkRequestParams requestParams = pluginData.requestParams;
            if (requestParams == null) {
                requestParams = new NetworkRequestParams();
            }
            requestParams.os = os;
            if (os == ATConfig.OS_ANDROID) {  //Android 
                requestParams.androidVersion = pluginData.androidVersions[index];
            } else {
                requestParams.iosVersion = pluginData.iosVersions[index];
            }
            pluginData.requestParams = requestParams;
            // ATLog.log("ExChangeSDKVersion() >>> versions.Android: " + versions.Android + " versions.Ios: " + versions.Ios);
            loadNetworksData(pluginData);
        }

        //获取插件和SDK的版本数据
        private void loadPluginData()
        {
            if (loadDataCoroutine != null)
            {
                loadDataCoroutine.Stop();
            }
            loadDataCoroutine = ATEditorCoroutine.startCoroutine(ATIntegrationManager.Instance.loadPluginData(data =>
            {
                if (data == null)
                {
                    pluginDataLoadFailed = true;
                }
                else
                {
                    ATLog.log("loadNetworksData() >>> pluginData: " + data);
                    pluginData = data;
                    pluginDataLoadFailed = false;

                    var versions = pluginData.anyThink.CurrentVersions;
                    if (versions != null) {
                        var requestParams = new NetworkRequestParams();
                        requestParams.androidVersion = versions.Android;
                        requestParams.iosVersion = versions.Ios;
                        pluginData.requestParams = requestParams;
                    }
                    loadNetworksData(pluginData);
                }

                CalculateFieldWidth();
                Repaint();
            }));
        }
        //获取networks
        private void loadNetworksData(PluginData pluginData)
        {
            ATEditorCoroutine.startCoroutine(ATIntegrationManager.Instance.loadNetworksData(pluginData, data =>
            {
                pluginData = data;
                Network network = pluginData.anyThink;
                if (!string.IsNullOrEmpty(network.AndroidDownloadUrl) || !string.IsNullOrEmpty(network.iOSDownloadloadUrl)) {
                    ATIntegrationManager.Instance.downloadCorePlugin(data);
                }
                Repaint();
            }));
        }
        //切换国家，重新加载数据
        private void switchCountry(int country)
        {
            ATIntegrationManager.Instance.switchCountry(pluginData, country);
            //重新开始走network
            loadPluginData();
        }

        private void CalculateFieldWidth()
        {
            var currentWidth = position.width;
            var availableWidth = currentWidth - actionFieldWidth - 80; // NOTE: Magic number alert. This is the sum of all the spacing the fields and other UI elements.
            var networkLabelWidth = Math.Max(networkFieldMinWidth, availableWidth * networkFieldWidthPercentage);
            networkWidthOption = GUILayout.Width(networkLabelWidth);

            var versionLabelWidth = Math.Max(versionFieldMinWidth, availableWidth * versionFieldWidthPercentage);
            versionWidthOption = GUILayout.Width(versionLabelWidth);

            const int textFieldOtherUiElementsWidth = 45; // NOTE: Magic number alert. This is the sum of all the spacing the fields and other UI elements.
            var availableTextFieldWidth = currentWidth - networkLabelWidth - textFieldOtherUiElementsWidth;
            sdkKeyTextFieldWidthOption = GUILayout.Width(availableTextFieldWidth);

            var availableUserDescriptionTextFieldWidth = currentWidth - privacySettingLabelWidth - textFieldOtherUiElementsWidth;
            privacySettingFieldWidthOption = GUILayout.Width(availableUserDescriptionTextFieldWidth);
        }

        private void DrawCountryUI()
        {
            // GUILayout.BeginHorizontal();
            GUILayout.Space(4);
            using (new EditorGUILayout.HorizontalScope("box"))
            {
                GUILayout.Space(5);

                int countryInt = ATConfig.getDefCountry(); //默认是中国
                if (pluginData != null)
                {
                    countryInt = pluginData.country;
                }

                string[] options = ATConfig.getCountryArray();
                // 创建Dropdown组件
                int curDropdownIndex = ATDataUtil.isChina(countryInt) ? 0 : 1;
                if (options.Length == 1) {
                    curDropdownIndex = 0;
                }
                int dropdownIndex = EditorGUILayout.Popup("Select Region:", curDropdownIndex, options);

                if (options.Length > 1) {
                    curSelectCountryInt = dropdownIndex == 0 ? ATConfig.CHINA_COUNTRY : ATConfig.NONCHINA_COUNTRY;
                    //变化才设置
                    if (pluginData != null && curSelectCountryInt != countryInt)
                    {
                        ATLog.log("DrawCountryUI() >>> curSelectCountryInt: " + curSelectCountryInt + " countryInt: " + countryInt);
                        //Unity需要更换Network
                        switchCountry(curSelectCountryInt);
                    }
                }
                GUILayout.Space(5);
            }
            GUILayout.Space(4);
            // GUILayout.EndHorizontal();
        }

        private void DrawCountrySwitchTip()
        {
            var integratedTip = ATConfig.getRegionIntegrateTip();
            if (string.IsNullOrEmpty(integratedTip)) {
                return;
            }
            GUILayout.Space(4);
            // textStyle.fontStyle = FontStyle.Bold;
            EditorGUILayout.LabelField(integratedTip, tipTextStyle);
            GUILayout.Space(4);
        }

        private void DrawAndroidXUI()
        {   
            bool isChina = ATConfig.isSelectedChina();
            // if (!ATConfig.isSelectedChina()) {
            //     return;
            // }
            EditorGUILayout.LabelField("AndroidX (Only for Android)", titleLabelStyle);
            GUILayout.Space(4);
            using (new EditorGUILayout.HorizontalScope("box"))
            {
                GUILayout.Space(5);

                int androidXSetting = ATIntegrationManager.Instance.getAndroidXSetting(pluginData);
                string[] options = new string[] { "Default", "Enable", "Disable" };
                if (!isChina) {
                    options = new string[] { "Default", "Enable" };
                }
                // 创建Dropdown组件
                int lastDropdownIndex = androidXSetting;
                int curDropdownIndex = EditorGUILayout.Popup("Enable AndroidX:", lastDropdownIndex, options);

                //变化才设置
                if (curDropdownIndex != lastDropdownIndex)
                {
                    ATLog.log("DrawAndroidXUI() >>> curDropdownIndex: " + curDropdownIndex + " lastDropdownIndex: " + lastDropdownIndex);
                    ATIntegrationManager.Instance.saveAndroidXSetting(pluginData, curDropdownIndex);
                }
                GUILayout.Space(5);
            }
            GUILayout.Space(4);
        }

        private void DrawPluginDetails()
        {
            // GUILayout.BeginHorizontal();
            GUILayout.Space(10);
            using (new EditorGUILayout.VerticalScope("box"))
            {
                // Draw plugin version details
                DrawHeaders("Platform", true);
                DrawPluginDetailRow("Unity Plugin", ATConfig.PLUGIN_VERSION, "", "");
                if (pluginData == null)
                {
                    DrawEmptyPluginData("loading sdk data ...");
                    return;
                }

                var anythink = pluginData.anyThink;
                var android_version = "";
                var ios_version = "";
                if (anythink != null) {
                    android_version = anythink.CurrentVersions.Android;
                    ios_version = anythink.CurrentVersions.Ios;
                }
                //绘制Android
                using (new EditorGUILayout.HorizontalScope())
                {
                    GUILayout.Space(5);
                    EditorGUILayout.LabelField(new GUIContent("Android"), networkWidthOption);
                    EditorGUILayout.LabelField(new GUIContent(android_version), versionWidthOption);
                    GUILayout.Space(3);

                    string[] androidVersions = pluginData.androidVersions;
                    if (androidVersions != null && androidVersions.Length > 0) {
                        List<int> androidVersionsInt = new List<int>();
                        int androidLength = androidVersions.Length;
                        for (int i = 0; i < androidLength; i = i + 1)
                        {
                            androidVersionsInt.Add(i);
                        }

                        // 创建Dropdown组件
                        androidVersionPopupIndex = EditorGUILayout.IntPopup(androidVersionPopupIndex, androidVersions, androidVersionsInt.ToArray(), versionWidthOption);
                        GUILayout.FlexibleSpace();
                        string selectedAndroidVersion = androidVersions[androidVersionPopupIndex];
                        string action = "Exchange";
                        if (!string.IsNullOrEmpty(android_version) && Equals(android_version, selectedAndroidVersion)) {
                            action = "Delete";
                        }
                        GUI.enabled = (!Equals(android_version, selectedAndroidVersion)) || action == "Delete";
                        if (GUILayout.Button(new GUIContent(action), fieldWidth))
                        {
                            //切换AndroidSDK版本
                            if (action == "Delete") {
                                DeleteSdkVersion(pluginData, androidVersionPopupIndex, ATConfig.OS_ANDROID);
                            } else {
                                ExChangeSDKVersion(pluginData, androidVersionPopupIndex, ATConfig.OS_ANDROID);
                            }
                        }
                        GUI.enabled = true;
                        GUILayout.Space(5);    
                    } else {
                        EditorGUILayout.LabelField(new GUIContent("loading..."), versionWidthOption);
                    }
                
                    GUILayout.Space(3);
                }
                //绘制iOS
                using (new EditorGUILayout.HorizontalScope())
                {
                    GUILayout.Space(5);
                    EditorGUILayout.LabelField(new GUIContent("iOS"), networkWidthOption);
                    EditorGUILayout.LabelField(new GUIContent(ios_version), versionWidthOption);
                    GUILayout.Space(3);

                    string[] iosVersions = pluginData.iosVersions;
                    if (iosVersions != null && iosVersions.Length > 0) {
                        List<int> iosVersionsInt = new List<int>();
                        int androidLength = iosVersions.Length;
                        for (int i = 0; i < androidLength; i = i + 1)
                        {
                            iosVersionsInt.Add(i);
                        }

                        // 创建Dropdown组件
                        iosVersionPopupIndex = EditorGUILayout.IntPopup(iosVersionPopupIndex, iosVersions, iosVersionsInt.ToArray(), versionWidthOption);
                        GUILayout.FlexibleSpace();
                        string selectedIosVersion = iosVersions[iosVersionPopupIndex];

                        string action = "Exchange";
                        if (!string.IsNullOrEmpty(ios_version) && Equals(ios_version, selectedIosVersion)) {
                            action = "Delete";
                        }
                        GUI.enabled = !Equals(ios_version, selectedIosVersion) || action == "Delete";
                        if (GUILayout.Button(new GUIContent(action), fieldWidth))
                        {
                            if (action == "Delete") {
                                DeleteSdkVersion(pluginData, iosVersionPopupIndex, ATConfig.OS_IOS);
                            } else {
                                ExChangeSDKVersion(pluginData, iosVersionPopupIndex, ATConfig.OS_IOS);
                            }
                        }
                        GUI.enabled = true;
                        GUILayout.Space(5);    
                    } else {
                        EditorGUILayout.LabelField(new GUIContent("loading..."), versionWidthOption);
                    }
                
                    GUILayout.Space(3);
                }

                GUILayout.Space(4);

#if !UNITY_2018_2_OR_NEWER
                EditorGUILayout.HelpBox("AnyThink Unity plugin will soon require Unity 2018.2 or newer to function. Please upgrade to a newer Unity version.", MessageType.Warning);
#endif
            }

            GUILayout.Space(5);
            // GUILayout.EndHorizontal();
        }

        private void DrawSdkVersionOffTip()
        {
            if (pluginData == null) {
                return;
            }
            var anythink = pluginData.anyThink;
            if (anythink == null) {
                return;
            }
            var android_version = "";
            var ios_version = "";
            if (anythink != null) {
                android_version = anythink.CurrentVersions.Android;
                ios_version = anythink.CurrentVersions.Ios;
                //判断android版本是否版本列表中
                string[] androidVersions = pluginData.androidVersions;
                string[] iosVersions = pluginData.iosVersions;

                //The currently installed Android version and io version have been offline
                StringBuilder sb = new StringBuilder();
                sb.Append("Tips: The currently installed ");
               
                var android_version_off = false;
                if (!string.IsNullOrEmpty(android_version) && androidVersions != null && androidVersions.Length > 0) {
                    if (!IsCharInStringArray(android_version, androidVersions)) {
                        sb.Append("Android version(");
                        sb.Append(android_version);
                        sb.Append(") ");
                        android_version_off = true;
                    }
                }
                var ios_version_off = false;
                if (!string.IsNullOrEmpty(ios_version) && iosVersions != null && iosVersions.Length > 0) {
                    if (!IsCharInStringArray(ios_version, iosVersions)) {
                        if (android_version_off) {
                            sb.Append("and ");
                        }
                        sb.Append("iOS version(");
                        sb.Append(ios_version);
                        sb.Append(") ");
                        ios_version_off = true;
                    }
                }
                if (android_version_off || ios_version_off) {
                    sb.Append("have been offline, please install the latest version.");
                    GUILayout.Space(4);
                    EditorGUILayout.LabelField(sb.ToString(), tipTextStyle);
                    GUILayout.Space(4);
                } else {
                    sb.Clear();
                }
            }
        }

        private bool IsCharInStringArray(string character, string[] array)
        {
            // 遍历数组中的每个字符串
            foreach (string str in array)
            {
                // 如果当前字符串包含指定的字符，则返回true
                if (str == character)
                {
                    return true;
                }
            }

            // 如果没有找到字符，则返回false
            return false;
        }


        private void DrawHeaders(string firstColumnTitle, bool drawAction)
        {
            using (new EditorGUILayout.HorizontalScope())
            {
                GUILayout.Space(5);
                EditorGUILayout.LabelField(firstColumnTitle, headerLabelStyle, networkWidthOption);
                EditorGUILayout.LabelField("Current Version", headerLabelStyle, versionWidthOption);
                GUILayout.Space(3);
                EditorGUILayout.LabelField("SDK Versions", headerLabelStyle, versionWidthOption);
                GUILayout.Space(3);
                if (drawAction)
                {
                    GUILayout.FlexibleSpace();
                    GUILayout.Button("Actions", headerLabelStyle, fieldWidth);
                    GUILayout.Space(5);
                }
            }

            GUILayout.Space(4);
        }

        private void DrawPluginDetailRow(string platform, string currentVersion, string sdkversions, string actions)
        {
            using (new EditorGUILayout.HorizontalScope())
            {
                GUILayout.Space(5);
                EditorGUILayout.LabelField(new GUIContent(platform), networkWidthOption);
                EditorGUILayout.LabelField(new GUIContent(currentVersion), versionWidthOption);
                GUILayout.Space(3);
                EditorGUILayout.LabelField(new GUIContent(sdkversions), versionWidthOption);
                GUILayout.Space(3);
                // EditorGUILayout.LabelField(new GUIContent(actions), versionWidthOption);
                // GUILayout.Space(3);
            }

            GUILayout.Space(4);
        }

        private void DrawEmptyPluginData(string tip)
        {
            GUILayout.Space(5);

            // Plugin data failed to load. Show error and retry button.
            if (pluginDataLoadFailed)
            {
                GUILayout.Space(10);
                GUILayout.BeginHorizontal();
                GUILayout.Space(5);
                EditorGUILayout.LabelField("Failed to load plugin data. Please click retry or restart the integration manager.", titleLabelStyle);
                if (GUILayout.Button("Retry", fieldWidth))
                {
                    pluginDataLoadFailed = false;
                    loadPluginData();
                }

                GUILayout.Space(5);
                GUILayout.EndHorizontal();
                GUILayout.Space(10);
            }
            // Still loading, show loading label.
            else
            {
                GUILayout.Space(10);
                GUILayout.BeginHorizontal();
                // GUILayout.FlexibleSpace();
                EditorGUILayout.LabelField(tip, titleLabelStyle);
                // GUILayout.FlexibleSpace();
                GUILayout.EndHorizontal();
                GUILayout.Space(10);
            }

            GUILayout.Space(5);
        }
        //绘制Admob Id
        private void DrawAdombAppId() {
            var integrationManager = ATIntegrationManager.Instance;
            bool isAdmobInstalledForAndroid = integrationManager.isAdmobInstalled(ATConfig.OS_ANDROID);
            bool isAdmobInstalledForIos = integrationManager.isAdmobInstalled(ATConfig.OS_IOS);

            if (isAdmobInstalledForAndroid || isAdmobInstalledForIos) {
                EditorGUILayout.LabelField("Admob AppId", titleLabelStyle);
                GUILayout.Space(5);
                using (new EditorGUILayout.VerticalScope("box"))
                {
                    GUILayout.Space(10);
                    if (isAdmobInstalledForAndroid) {
                        var androidAdmobAppId = DrawTextField("App ID (Android)", integrationManager.getAdmobAppIdByOs(pluginData, ATConfig.OS_ANDROID), networkWidthOption);
                        integrationManager.setAdmobAppidByOs(pluginData, ATConfig.OS_ANDROID, androidAdmobAppId);
                    }
                    if (isAdmobInstalledForIos) {
                        if (isAdmobInstalledForAndroid) {
                            GUILayout.Space(10);
                        }
                        var iosAdmobAppId = DrawTextField("App ID (iOS)", integrationManager.getAdmobAppIdByOs(pluginData, ATConfig.OS_IOS), networkWidthOption);
                        integrationManager.setAdmobAppidByOs(pluginData, ATConfig.OS_IOS, iosAdmobAppId);
                    }
                }
            }
        }

        private string DrawTextField(string fieldTitle, string text, GUILayoutOption labelWidth,    GUILayoutOption textFieldWidthOption = null)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Space(4);
            EditorGUILayout.LabelField(new GUIContent(fieldTitle), labelWidth);
            GUILayout.Space(4);
            text = (textFieldWidthOption == null) ? GUILayout.TextField(text) : GUILayout.TextField(text, textFieldWidthOption);
            GUILayout.Space(4);
            GUILayout.EndHorizontal();
            GUILayout.Space(4);

            return text;
        }


        private void DrawMediatedNetworks()
        {
            GUILayout.Space(5);
            EditorGUILayout.LabelField("Ad Networks", titleLabelStyle);
            GUILayout.Space(5);
            GUILayout.BeginHorizontal();
            using (new EditorGUILayout.VerticalScope("box"))
            {
                DrawHeaders("Network", true);
                string clickTip = "You need to select an sdk version and click the Exchange button.";
                // Immediately after downloading and importing a plugin the entire IDE reloads and current versions can be null in that case. Will just show loading text in that case.
                if (pluginData == null)
                {
                    ATLog.log("DrawMediatedNetworks failed.");
                    DrawEmptyPluginData("loading sdk data ...");
                } else if(pluginData.mediatedNetworks == null) {
                    DrawEmptyPluginData(clickTip);
                } else {
                    var networks = pluginData.mediatedNetworks;
                    var length = networks.Length;
                    ATLog.log("DrawMediatedNetworks() >>> networks length: " + length);
                    if (length == 0) {
                        DrawEmptyPluginData(clickTip);
                        return;
                    }
                    int versionEmptyLength = 0;
                    foreach (var network in networks)
                    {
                        if (network.isVersionEmpty()) {
                            // ATLog.log("DrawMediatedNetworks() >>> isVersionEmpty name: " + network.Name);
                            versionEmptyLength = versionEmptyLength + 1;
                        } else {
                            DrawNetworkDetailRow2(network);
                        }
                    }
                    ATLog.log("DrawMediatedNetworks() >>> versionEmptyLength: " + versionEmptyLength);
                    if (versionEmptyLength == length) {
                        DrawEmptyPluginData(clickTip);
                    }

                    GUILayout.Space(10);
                }
            }

            GUILayout.Space(5);
            GUILayout.EndHorizontal();
        }
        //绘制network的每一行
        private void DrawNetworkDetailRow2(Network network) {
            using (new EditorGUILayout.VerticalScope("box"))
            {
                GUILayout.Space(4);
                string a_action = "";    
                string i_action = "";
                string cur_a_version = "";
                string cur_i_version = "";
                string last_a_version = "";
                string last_i_version = "";
                if (network.CurrentVersions != null)
                {
                    cur_a_version = network.CurrentVersions.Android;
                    cur_i_version = network.CurrentVersions.Ios;
                }
                if (network.LatestVersions != null) 
                {
                    last_a_version = network.LatestVersions.Android;
                    last_i_version = network.LatestVersions.Ios;
                }
                //Android Action按钮状态
                ATLog.log("DrawNetworkDetailRow2() >>> cur_a_version: " + cur_a_version + " last_i_version: " + last_i_version + 
                " name: " + network.DisplayName + " last_a_version: " + last_a_version);
                if (string.IsNullOrEmpty(cur_a_version)) {
                    a_action = "Install";
                } else if (ATDataUtil.CompareVersions(cur_a_version, last_a_version) == VersionComparisonResult.Lesser) {
                    a_action = "Upgrade";
                } else if(ATDataUtil.CompareVersions(cur_a_version, last_a_version) == VersionComparisonResult.Equal) {
                    a_action = "Installed";
                } 
                bool hasAndroid = false;
                if (!string.IsNullOrEmpty(last_a_version)) {
                    hasAndroid = true;
                    DrawRowNetwork(network, ATConfig.OS_ANDROID, cur_a_version, last_a_version, a_action, true);
                }
                //iOS Action按钮状态
                // var i_compare_result = ATDataUtil.CompareVersions(cur_i_version, last_i_version);
                if (string.IsNullOrEmpty(cur_i_version)) {
                    i_action = "Install";
                } else if (ATDataUtil.CompareVersions(cur_i_version, last_i_version) == VersionComparisonResult.Lesser) {
                    i_action = "Upgrade";
                } else if(ATDataUtil.CompareVersions(cur_i_version, last_i_version) == VersionComparisonResult.Equal) {
                    i_action = "Installed";
                } 
                if (!string.IsNullOrEmpty(last_i_version)) {
                    DrawRowNetwork(network, ATConfig.OS_IOS, cur_i_version, last_i_version, i_action, !hasAndroid);
                }
                GUILayout.Space(4);
            }
        }

        private void DrawRowNetwork(Network network, int os, string curVersion, string lastVersion, string action, bool isShowNetworkName)
        {
             GUILayout.Space(5);
            if (os == ATConfig.OS_ANDROID) {
                if (!string.IsNullOrEmpty(curVersion)) {
                    curVersion = "Android-" + curVersion;
                } else {
                    curVersion = "Not Installed";
                }
                lastVersion = "Android-" + lastVersion;
            } else {
                if (!string.IsNullOrEmpty(curVersion)) {
                    curVersion = "iOS-" + curVersion;
                } else {
                    curVersion = "Not Installed";
                }
                lastVersion = "iOS-" + lastVersion;
            }
            using (new EditorGUILayout.HorizontalScope(GUILayout.ExpandHeight(false)))
            {
                GUILayout.Space(5);
                if (isShowNetworkName) {
                    EditorGUILayout.LabelField(new GUIContent(network.DisplayName), networkWidthOption);
                } else {
                    EditorGUILayout.LabelField(new GUIContent(""), networkWidthOption);
                }
               
                EditorGUILayout.LabelField(new GUIContent(curVersion), versionWidthOption);
                GUILayout.Space(3);
                EditorGUILayout.LabelField(new GUIContent(lastVersion), versionWidthOption);
                GUILayout.Space(3);
                GUILayout.FlexibleSpace();

                if (network.isReqiureUpdate())
                {
                    GUILayout.Label(new GUIContent { image = alertIcon, tooltip = "Adapter not compatible, please update to the latest version." }, iconStyle);
                }

                GUI.enabled = action != "Installed";
                if (GUILayout.Button(new GUIContent(action), fieldWidth))
                {   
                    ATIntegrationManager.Instance.networkInstallOrUpdate(pluginData, network, os);
                }
                GUI.enabled = true;
                GUILayout.Space(2);

                GUI.enabled = action == "Installed";
                if (GUILayout.Button(new GUIContent { image = uninstallIcon, tooltip = "Uninstall" }, iconStyle))
                {
                    EditorUtility.DisplayProgressBar("Integration Manager", "Deleting " + network.Name + "...", 0.5f);
                    ATIntegrationManager.Instance.uninstallNetwork(network, os);
                    //Refresh UI
                    AssetDatabase.Refresh();
                    EditorUtility.ClearProgressBar();
                }

                GUI.enabled = true;
                GUILayout.Space(5);
            }
        }
    }
}
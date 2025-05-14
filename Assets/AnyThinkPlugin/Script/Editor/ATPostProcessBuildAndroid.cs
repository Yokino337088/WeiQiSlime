#if UNITY_ANDROID && UNITY_2018_2_OR_NEWER
using AnyThink.Scripts.IntegrationManager.Editor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using UnityEditor;
using UnityEditor.Android;

namespace AnyThink.Scripts.Editor
{
    public class ATPostProcessBuildAndroid: IPostGenerateGradleAndroidProject
    {
#if UNITY_2019_3_OR_NEWER
        private static string PropertyAndroidX = "android.useAndroidX";
        private static string PropertyJetifier = "android.enableJetifier";
        private static string EnableProperty = "=true";
#endif
        private static string PropertyDexingArtifactTransform = "android.enableDexingArtifactTransform";
        private static string DisableProperty = "=false";

        private static string KeyMetaDataGoogleApplicationId = "com.google.android.gms.ads.APPLICATION_ID";
        private static string KeyMetaDataGoogleAdManagerApp = "com.google.android.gms.ads.AD_MANAGER_APP";

        private static readonly XNamespace AndroidNamespace = "http://schemas.android.com/apk/res/android";
        private static readonly XNamespace ToolsNamespace = "http://schemas.android.com/tools";

        public void OnPostGenerateGradleAndroidProject(string path)
        {
             ATLog.log("OnPostGenerateGradleAndroidProject() >>> path: " + path);
           
#if UNITY_2019_3_OR_NEWER
            var gradlePropertiesPath = Path.Combine(path, "../gradle.properties");
#else
            var gradlePropertiesPath = Path.Combine(path, "gradle.properties");
#endif
            if (!ATConfig.isDefaultAndroidX()) {
                processGradleProperties(gradlePropertiesPath);
            }
            processAndroidManifest(path);
            processNetworkConfigXml(path);
            ATProcessBuildGradleAndroid.processBuildGradle(path);
        }

        public int callbackOrder
        {
            get { return int.MaxValue; }
        }

        private static void processGradleProperties(string gradlePropertiesPath)
        {
            ATLog.log("OnPostGenerateGradleAndroidProject() >>> gradlePropertiesPath: " + gradlePropertiesPath + " File.Exists(gradlePropertiesPath): " + File.Exists(gradlePropertiesPath));
            bool isChina = ATConfig.isSelectedChina();
         
            var gradlePropertiesUpdated = new List<string>();

            // If the gradle properties file already exists, make sure to add any previous properties.
            if (File.Exists(gradlePropertiesPath))
            {
                var lines = File.ReadAllLines(gradlePropertiesPath);

#if UNITY_2019_3_OR_NEWER
                // Add all properties except AndroidX, Jetifier, and DexingArtifactTransform since they may already exist. We will re-add them below.
                gradlePropertiesUpdated.AddRange(lines.Where(line => !line.Contains(PropertyAndroidX) && !line.Contains(PropertyJetifier) && !line.Contains(PropertyDexingArtifactTransform)));
#else
                // Add all properties except DexingArtifactTransform since it may already exist. We will re-add it below.
                gradlePropertiesUpdated.AddRange(lines.Where(line => !line.Contains(PropertyDexingArtifactTransform)));
#endif
            }

#if UNITY_2019_3_OR_NEWER
            //如果是国内，则根据选择来决定是否用AndroidX
            if (isChina)    
            {
                if (!ATConfig.enableAndroidX()) {
                    EnableProperty = "=false"; 
                } else {
                    EnableProperty = "=true"; 
                }
            } else {
                EnableProperty = "=true"; 
            }
            ATLog.log("[AnyThink] AndroidX EnableProperty" + EnableProperty);
            // Enable AndroidX and Jetifier properties 
            gradlePropertiesUpdated.Add(PropertyAndroidX + EnableProperty);
            gradlePropertiesUpdated.Add(PropertyJetifier + EnableProperty);
#endif
            // Disable dexing using artifact transform (it causes issues for ExoPlayer with Gradle plugin 3.5.0+)
            gradlePropertiesUpdated.Add(PropertyDexingArtifactTransform + DisableProperty);

            try
            {
                File.WriteAllText(gradlePropertiesPath, string.Join("\n", gradlePropertiesUpdated.ToArray()) + "\n");
            }
            catch (Exception exception)
            {
                ATLog.logError("Failed to enable AndroidX and Jetifier. gradle.properties file write failed.");
                Console.WriteLine(exception);
            }
        }

        private static void processAndroidManifest(string path)
        {
#if UNITY_2019_3_OR_NEWER
            var manifestPath = Path.Combine(path, "src/main/AndroidManifest.xml");
#else
            var manifestPath = Path.Combine(path, "unityLibrary/src/main/AndroidManifest.xml");
#endif
            // var manifestPath = Path.Combine(path, "src/main/AndroidManifest.xml");
            XDocument manifest;
            try
            {
                manifest = XDocument.Load(manifestPath);
            }
#pragma warning disable 0168
            catch (IOException exception)
#pragma warning restore 0168
            {
                ATLog.log("[AnyThink] AndroidManifest.xml is missing.");
                return;
            }

            // Get the `manifest` element.
            var elementManifest = manifest.Element("manifest");
            if (elementManifest == null)
            {
                ATLog.log("[AnyThink] AndroidManifest.xml is invalid.");
                return;
            }

            var elementApplication = elementManifest.Element("application");
            if (elementApplication == null)
            {
                ATLog.log("[AnyThink] AndroidManifest.xml is invalid.");
                return;
            }

            var metaDataElements = elementApplication.Descendants().Where(element => element.Name.LocalName.Equals("meta-data"));
            addGoogleApplicationIdIfNeeded(elementApplication, metaDataElements);
            // Save the updated manifest file.
            manifest.Save(manifestPath);
        }

        private static void addGoogleApplicationIdIfNeeded(XElement elementApplication, IEnumerable<XElement> metaDataElements)
        {
            var googleApplicationIdMetaData = GetElementByName(metaDataElements, KeyMetaDataGoogleApplicationId);

            if (!ATConfig.isNetworkInstalledByName("Admob", ATConfig.OS_ANDROID))
            {   
                ATLog.log("addGoogleApplicationIdIfNeeded() >>> Admob not install.");
//                if (googleApplicationIdMetaData != null) googleApplicationIdMetaData.Remove();
                return;
            }

            var appId = ATConfig.getAdmobAppIdByOs(ATConfig.OS_ANDROID);
            // Log error if the App ID is not set.
            if (string.IsNullOrEmpty(appId) || !appId.StartsWith("ca-app-pub-"))
            {
                ATLog.logError("AdMob App ID is not set. Please enter a valid app ID within the AnyThink Integration Manager window.");
                return;
            }

            // Check if the Google App ID meta data already exists. Update if it already exists.
            if (googleApplicationIdMetaData != null)
            {
                googleApplicationIdMetaData.SetAttributeValue(AndroidNamespace + "value", appId);
            }
            // Meta data doesn't exist, add it.
            else
            {
                elementApplication.Add(CreateMetaDataElement(KeyMetaDataGoogleApplicationId, appId));
            }
        }

        /// <summary>
        /// Looks through all the given meta-data elements to check if the required one exists. Returns <c>null</c> if it doesn't exist.
        /// </summary>
        private static XElement GetElementByName(IEnumerable<XElement> elements, string name)
        {
            foreach (var element in elements)
            {
                var attributes = element.Attributes();
                if (attributes.Any(attribute => attribute.Name.Namespace.Equals(AndroidNamespace)
                                                && attribute.Name.LocalName.Equals("name")
                                                && attribute.Value.Equals(name)))
                {
                    return element;
                }
            }

            return null;
        }

        /// <summary>
        /// Creates and returns a <c>meta-data</c> element with the given name and value. 
        /// </summary>
        private static XElement CreateMetaDataElement(string name, object value)
        {
            var metaData = new XElement("meta-data");
            metaData.Add(new XAttribute(AndroidNamespace + "name", name));
            metaData.Add(new XAttribute(AndroidNamespace + "value", value));

            return metaData;
        }

        private static void processNetworkConfigXml(string path)
        {   
            bool isChina = ATConfig.isSelectedChina();
            // bool isChina = true;
            
            //在application标签加上：android:networkSecurityConfig="@xml/anythink_network_security_config"
            addNetworkSecurityConfigInApplication(path, isChina);

#if UNITY_2019_3_OR_NEWER
            var resXmlPath = Path.Combine(path, "src/main/res/xml");
#else
            var resXmlPath = Path.Combine(path, "unityLibrary/src/main/res/xml");
#endif
            
            var rexXmlDir = Path.Combine(resXmlPath, "anythink_network_security_config.xml");
            if (File.Exists(rexXmlDir))
            { 
                if (!isChina)   //海外不用配置这个xml
                {
                   FileUtil.DeleteFileOrDirectory(rexXmlDir);
                } 
                return;
            }
            if (!Directory.Exists(resXmlPath))
            {
                Directory.CreateDirectory(resXmlPath);
            }
            
            saveFile("Assets/AnyThinkPlugin/Script/Editor/anythink_network_security_config.xml", resXmlPath);
        }

        public static void saveFile(string filePathName , string toFilesPath)
        {
            FileInfo file = new FileInfo(filePathName);
            string newFileName= file.Name;
            file.CopyTo(toFilesPath + "/" + newFileName, true);
        }

        private static void addNetworkSecurityConfigInApplication(string path, bool isChina)
        {
#if UNITY_2019_3_OR_NEWER
            var manifestPath = Path.Combine(path, "src/main/AndroidManifest.xml");
#else
            var manifestPath = Path.Combine(path, "unityLibrary/src/main/AndroidManifest.xml");
#endif
            // var manifestPath = Path.Combine(path, "src/main/AndroidManifest.xml");
            XDocument manifest;
            try
            {
                manifest = XDocument.Load(manifestPath);
            }
#pragma warning disable 0168
            catch (IOException exception)
#pragma warning restore 0168
            {
                ATLog.log("[AnyThink] AndroidManifest.xml is missing.");
                return;
            }

            // Get the `manifest` element.
            var elementManifest = manifest.Element("manifest");
            if (elementManifest == null)
            {
                ATLog.log("[AnyThink] AndroidManifest.xml is invalid.");
                return;
            }

            var elementApplication = elementManifest.Element("application");
            if (elementApplication == null)
            {
                ATLog.log("[AnyThink] AndroidManifest.xml is invalid.");
                return;
            }
            //handle anythink_network_security_config.xml
            XAttribute networkConfigAttribute = elementApplication.Attribute(AndroidNamespace + "networkSecurityConfig");
            if (networkConfigAttribute != null) {
                networkConfigAttribute.Remove();
            }
            if (isChina)
            {
                elementApplication.Add(new XAttribute(AndroidNamespace + "networkSecurityConfig", "@xml/anythink_network_security_config"));
            }

            //这个设置主要是为了适配9.0以上的机器
            //<uses-library android:name="org.apache.http.legacy" android:required="false" />
            var usesLibraryElements = elementApplication.Descendants().Where(element => element.Name.LocalName.Equals("uses-library"));
            if (usesLibraryElements == null)
            {
                elementApplication.Add(createHttpLegacyElement());
            }
            else 
            {
               XElement httpLegacyElement = GetElementByName(usesLibraryElements, "org.apache.http.legacy");
               if (httpLegacyElement == null)
               {
                    elementApplication.Add(createHttpLegacyElement());
               }
            }
            manifest.Save(manifestPath);
        }

        public static XElement createHttpLegacyElement()
        {
            var httpFeautre = new XElement("uses-library");
            httpFeautre.Add(new XAttribute(AndroidNamespace + "name", "org.apache.http.legacy"));
            httpFeautre.Add(new XAttribute(AndroidNamespace + "required", "false"));

            return httpFeautre;
        }

        private static XElement CreateMetaDataElement(string name, object value, object toolsNode)
        {
            var metaData = new XElement("meta-data");
            metaData.Add(new XAttribute(AndroidNamespace + "name", name));
            metaData.Add(new XAttribute(AndroidNamespace + "value", value));
            metaData.Add(new XAttribute(ToolsNamespace + "node", toolsNode));

            return metaData;
        }
    }
    
}

#endif
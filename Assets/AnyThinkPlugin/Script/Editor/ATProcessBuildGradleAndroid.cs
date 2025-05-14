#if UNITY_ANDROID && UNITY_2018_2_OR_NEWER
using AnyThink.Scripts.IntegrationManager.Editor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using UnityEditor;
using UnityEditor.Android;
using System.Text.RegularExpressions;
using System.Diagnostics;
using UnityEngine;
using System.Text;


namespace AnyThink.Scripts.Editor
{

    public class ATProcessBuildGradleAndroid
    {

        // public void OnPostGenerateGradleAndroidProject(string path)
        // {

        // }

        public static void processBuildGradle(string path)
        {
#if UNITY_2019_3_OR_NEWER
            var buildGradlePath = Path.Combine(path, "../build.gradle");
#else
            var buildGradlePath = Path.Combine(path, "build.gradle");
#endif  

#if UNITY_2022_1_OR_NEWER
            ATLog.log("processBuildGradle() >>> called");
#else 
            replaceBuildPluginVersion(buildGradlePath);
            // replaceAppBuildPluginVersion(path);
#endif
            // replaceAppBuildPluginVersion(path);
            handleNetworksConfit(path);
            // handleNetworkResMerge(path);
            // callGradleTask(path);
        }
        //修改项目的根目录下的build.gradle文件的插件版本号
        private static void replaceBuildPluginVersion(string buildGradlePath)
        {
            if (!File.Exists(buildGradlePath))
            {
                return;
            }
            string gradleFileContent = "";
            using (StreamReader reader = new StreamReader(buildGradlePath))
            {
                gradleFileContent = reader.ReadToEnd();
            }
            if (string.IsNullOrEmpty(gradleFileContent))
            {
                return;
            }
            
            string buildGradleVersion = "";
            string buildGradlePattern = "";

            string buildGradleVersion3 = "3.3.3";    // 新gradle插件版本号
            string buildGradlePattern3 = @"(?<=gradle:)3\.3\.\d+";
            string buildGradleVersion4 = "3.4.3"; 
            string buildGradlePattern4 = @"(?<=gradle:)3\.4\.\d+";
            string buildGradleVersion5 = "3.5.4";
            string buildGradlePattern5 = @"(?<=gradle:)3\.5\.\d+";
            string buildGradleVersion6 = "3.6.4";
            string buildGradlePattern6 = @"(?<=gradle:)3\.6\.\d+";

            if (isMatchGradleVersion(gradleFileContent, buildGradleVersion3))
            {
                buildGradleVersion = buildGradleVersion3;
                buildGradlePattern = buildGradlePattern3;
            } 
            else if(isMatchGradleVersion(gradleFileContent, buildGradleVersion4))
            {
                buildGradleVersion = buildGradleVersion4;
                buildGradlePattern = buildGradlePattern4;
            }
            else if(isMatchGradleVersion(gradleFileContent, buildGradleVersion5))
            {
                buildGradleVersion = buildGradleVersion5;
                buildGradlePattern = buildGradlePattern5;
            }
            else if(isMatchGradleVersion(gradleFileContent, buildGradleVersion6))
            {
                buildGradleVersion = buildGradleVersion6;
                buildGradlePattern = buildGradlePattern6;
            }

            if (!string.IsNullOrEmpty(buildGradlePattern) && !string.IsNullOrEmpty(buildGradleVersion))
            {
                replaceContent(buildGradlePath, buildGradlePattern, buildGradleVersion);
            }
        }

        private static void replaceContent(string filePath, string pattern, string content)
        {
            if (!File.Exists(filePath))
            {
                return;
            }
            string buildGradle = "";
            using (StreamReader reader = new StreamReader(filePath))
            {
                buildGradle = reader.ReadToEnd();
            }
            // Regex regex = new Regex(pattern);
            buildGradle = Regex.Replace(buildGradle, pattern, content);

            // 修改gradle-wrapper版本号
            // string oldWrapperVersion = "distributionUrl=https\\://services.gradle.org/d
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.Write(buildGradle);
            }
        }

        private static bool isMatchGradleVersion(string gradleFileContent, string version)
        {
            string matchStr = String.Format("gradle:{0}", version.Substring(0, 3));
            return gradleFileContent.Contains(matchStr);
        }
        //修改app module下的build.gradle
        private static void replaceAppBuildPluginVersion(string path)
        {
#if UNITY_2019_3_OR_NEWER
            var buildGradlePath = Path.Combine(path, "../launcher/build.gradle");
#else
            var buildGradlePath = Path.Combine(path, "launcher/build.gradle");
#endif  
            if (!File.Exists(buildGradlePath))
            {
                return;
            }
            string buildGradleVersion = "30";
            string compileSdkVersionPattern = "compileSdkVersion";
            string targetSdkVersionPattern = "targetSdkVersion";

            List<string> lines = new List<string>();
            using (StreamReader reader = new StreamReader(buildGradlePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }
            int indexToReplace = -1;
            int indexToReplace1 = -1;
            int removeIndex = -1;
            int addIndex = -1;
            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].Contains(compileSdkVersionPattern))
                {
                    indexToReplace = i;
                }
                else if (lines[i].Contains(targetSdkVersionPattern))
                {
                    indexToReplace1 = i;
                }
                else if (lines[i].Contains("buildToolsVersion"))
                {
                    removeIndex = i;
                }
                else if (lines[i].Contains("defaultConfig"))
                {
                    addIndex = i;
                }
            }
            if (indexToReplace != -1)
            {
                lines[indexToReplace] = "  " + compileSdkVersionPattern + " " + buildGradleVersion;
            }
            if (indexToReplace1 != -1)
            {
                lines[indexToReplace1] = "  " + targetSdkVersionPattern + " " + buildGradleVersion;
            }
            if (removeIndex != -1)
            {
                lines.RemoveAt(removeIndex);
            }
            if (addIndex != -1)
            {
                lines.Insert(addIndex + 1, "  multiDexEnabled true");
            }
            using (StreamWriter writer = new StreamWriter(buildGradlePath))
            {
                foreach (string line in lines)
                {
                    writer.WriteLine(line);
                }
            }
        }

        private static void handleNetworksConfit(string path)
        {
            if (ATConfig.isSelectedChina())
            {
                return;
            }
#if UNITY_2019_3_OR_NEWER
            var buildGradlePath = Path.Combine(path, "../launcher/build.gradle");
#else
            var buildGradlePath = Path.Combine(path, "launcher/build.gradle");
#endif  
            if (!File.Exists(buildGradlePath))
            {
                return;
            }
            List<string> lines = new List<string>();
            using (StreamReader reader = new StreamReader(buildGradlePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }
            var androidStartIndex = 0;
            var isConfigAll = false;
            var isExcludeModule = false;

            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].Contains("android {"))
                {
                    androidStartIndex = i;
                }
                else if (lines[i].Contains("configurations.all"))
                {
                    isConfigAll = true;
                }
                else if (lines[i].Contains("META-INF/*.kotlin_module"))
                {
                    isExcludeModule = true;
                }
            }   
            if (androidStartIndex > 0)
            {
                if (!isExcludeModule)
                {
                    lines.Insert(androidStartIndex + 1, "  packagingOptions {\n     merge 'META-INF/com.android.tools/proguard/coroutines.pro'\n     exclude 'META-INF/*.kotlin_module'\n   }");
                }
                // if (!isConfigAll)
                // {
                //     lines.Insert(androidStartIndex -1, "configurations.all {\n     resolutionStrategy {\n      force 'androidx.core:core:1.6.0'\n      force 'androidx.recyclerview:recyclerview:1.1.0' \n    }\n}");
                // }
            }
            // configurations.all {
            //     resolutionStrategy {
            //         force 'androidx.core:core:1.6.0'
            //         force 'androidx.recyclerview:recyclerview:1.1.0'
            //     }
            // }
            // packagingOptions {
            //     merge "META-INF/com.android.tools/proguard/coroutines.pro"
            //     exclude "META-INF/*.kotlin_module"
            // }
            using (StreamWriter writer = new StreamWriter(buildGradlePath))
            {
                foreach (string line in lines)
                {
                    writer.WriteLine(line);
                }
            }
        }

        private static void handleNetworkResMerge(string path) {
            ATLog.log("handleNetworkResMerge() >>> path: " + path);
#if UNITY_2019_3_OR_NEWER
            var buildGradlePath = Path.Combine(path, "../launcher/build.gradle");
#else
            var buildGradlePath = Path.Combine(path, "launcher/build.gradle");
#endif 
            List<string> lines = new List<string>();
            bool isAdded = false;

            using (StreamReader reader = new StreamReader(buildGradlePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Contains("task handleNetworkResMerge")) {
                        isAdded = true;
                    }
                    lines.Add(line);
                }
            }
            if (isAdded) {
                return;
            }
            using (StreamReader reader = new StreamReader("Assets/AnyThinkPlugin/Script/Editor/network_res_handle.gradle"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }
            using (StreamWriter writer = new StreamWriter(buildGradlePath))
            {
                foreach (string line in lines)
                {
                    writer.WriteLine(line);
                }
            }
        }

        private static void callGradleTask(string path) {
            // 设置你想要启动的Gradle任务
            string gradleTask = "handleNetworkResMerge"; // 例如: assembleDebug or assembleRelease

            // 开始一个新的进程来执行Gradle任务
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = Application.platform == RuntimePlatform.WindowsEditor ? "cmd" : "bash";
            psi.Arguments = Application.platform == RuntimePlatform.WindowsEditor ?
                $"/c gradlew {gradleTask}" : // Windows cmd命令
                $"-c './gradlew {gradleTask}'"; // UNIX bash命令
            psi.UseShellExecute = false;
            psi.StandardOutputEncoding = Encoding.UTF8;
            psi.StandardErrorEncoding = Encoding.UTF8;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            psi.CreateNoWindow = true;
            psi.WorkingDirectory = "/Users/quinx/Desktop/workspace_topon/sdk_source/a_unity_demo/TestAnyThinkUnityPlugin/Library/Bee/Android/Prj/Mono2x/Gradle"; // 这里应该是你的Android项目路径

            ATLog.log("callGradleTask() >>> path: " + path);

            using (var process = Process.Start(psi))
            {
                // 读取输出信息
                while (!process.StandardOutput.EndOfStream)
                {
                    var line = process.StandardOutput.ReadLine();
                    UnityEngine.Debug.Log(line);
                }
                // 读取错误信息
                while (!process.StandardError.EndOfStream)
                {
                    var line = process.StandardError.ReadLine();
                    UnityEngine.Debug.LogError(line);
                }
            }
        }
    }
}
#endif
//菜单栏
using UnityEditor;
using UnityEngine;
// using DownloadManager;

namespace AnyThink.Scripts.IntegrationManager.Editor
{
    public class AnyThinkMenuItems : MonoBehaviour
    {
        /**
         * The special characters at the end represent a shortcut for this action.
         * 
         * % - ctrl on Windows, cmd on macOS
         * # - shift
         * & - alt
         * 
         * So, (shift + cmd/ctrl + t) will launch the integration manager
         */
        [MenuItem("AnyThink/SDK Manager %#t")]
        private static void IntegrationManager()
        {
            
            ATIntegrationManagerWindow.ShowManager();
        }

        [MenuItem("AnyThink/Documentation")]
        public static void Documentation()
        {
            // if (ATConfig.isSelectedChina()) {
            //     Application.OpenURL("https://newdocs.toponad.com/docs/lgfbO4");
            // } else {
            //     Application.OpenURL("https://docs.toponad.com/#/en-us/unity/unity_doc/unity_access_doc_new?id=_3-integration");
            // }
            Application.OpenURL("https://newdocs.toponad.com/docs/lgfbO4");
        }
    }
}
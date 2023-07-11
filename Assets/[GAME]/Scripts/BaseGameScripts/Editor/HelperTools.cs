using System;
using System.IO;
using System.Reflection;
using BayatGames.SaveGameFree;
using Scripts.BaseGameSystemRelatedScripts.Upgrade;
using Scripts.GameScripts.Upgrade;
using UnityEditor;
using UnityEngine;

namespace Scripts.BaseGameScripts.Editor
{
    public class HelperTools
    {
        public static Action onDeletedSavedFiles;
        private static string s_path;

        [MenuItem("Developer Tools/Clear Console _c")] // Clear Console added
        private static void ClearConsole()
        {
            var assembly = Assembly.GetAssembly(typeof(SceneView));
            var type = assembly.GetType("UnityEditor.LogEntries");
            var method = type.GetMethod("Clear");
            if (method != null)
                method.Invoke(new object(), null);
        }

        [MenuItem("Developer Tools/Screen Shoot _s")]
        private static void ScreenShot()
        {
            PathCalculator();

            var iScrShotNo = PlayerPrefs.GetInt("iScrShotNo", 0);

            ScreenCapture.CaptureScreenshot(s_path + "\\s_" + iScrShotNo + ".png");

            iScrShotNo++;

            PlayerPrefs.SetInt("iScrShotNo", iScrShotNo);
        }

        private static void PathCalculator()
        {
            var size = Screen.height.ToString();

            if (size.Contains("2208"))
                size = "ip5";
            else if (size.Contains("2688"))
                size = "ip6";
            else if (size.Contains("2732")) size = "ipad";

            s_path = Application.dataPath + "\\..\\SS\\" + size;

            if (!Directory.Exists(s_path))
                Directory.CreateDirectory(s_path);
        }
        
        [MenuItem("Developer Tools/Delete Saved Files _d")]
        private static void DeleteSavedFiles()
        {
            PlayerPrefs.DeleteAll();
            SaveGame.DeleteAll();
            UpgradeDataSo.ResetData();
        }
    }
}
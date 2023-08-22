using System;
using Scripts.GameScripts;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEditor;

namespace Scripts.BaseGameScripts.DevHelperTools.Editor
{
    public class GameWindow : OdinMenuEditorWindow
    {
        [MenuItem("Designer Tools/Settings")]
        private static void OpenWindow()
        {
            GetWindow<GameWindow>().Show();
        }


        protected override OdinMenuTree BuildMenuTree()
        {
            var tree = new OdinMenuTree();
            tree.Selection.SupportsMultiSelect = false;

            tree.Add("Game Settings", GameSettingsDataSo.Instance);


            return tree;
        }

        [Serializable]
        public class HoleGameWindowFunctionality
        {
            [Button]
            public void SetDataDirty()
            {
                //UpgradeDataSo.UpgradesData.SetDataDirty();
            }
        }
    }
}
using Scripts.BaseGameScripts.Helper;
using Scripts.GameScripts.SceneLoadingManagement;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.BaseGameScripts.SceneLoadingManagement
{
    [CreateAssetMenu(fileName = "AllLevels", menuName = "BaseGame/Data/AllLevels", order = 0)]
    public class AllLevelsDataSo : ScriptableObject
    {
        [SerializeField]
        private ScenesToLoadAtLevelDataSo[] scenesToLoadAtLevel;

        public ScenesToLoadAtLevelDataSo[] ScenesToLoadAtLevels => scenesToLoadAtLevel;

        public ScenesToLoadAtLevelDataSo GetSceneToLoad(string levelName)
        {
            for (var i = 0; i < ScenesToLoadAtLevels.Length; i++)
            {
                var current = ScenesToLoadAtLevels[i];
                if (current.levelName == levelName)
                {
                    DebugHelper.LogGreen("LEVEL NAME TO LOAD : " + current.levelName);
                    return current;
                }
            }

            return null;
        }

        #region StaticSO

        [ShowInInspector]
        [DisableInEditorMode]
        [LabelText("Static Reference")]
        [InlineButton("FindHolesDataAsset")]
        private static AllLevelsDataSo s_instance;

        public static AllLevelsDataSo Instance => s_instance ??= Resources.Load<AllLevelsDataSo>("AllLevels");

        private void FindHolesDataAsset()
        {
            if (Instance)
                return;
            Debug.LogError("AllLevels asset of type HoleDataSo is missing in the resources folder.");
        }

        #endregion
    }
}
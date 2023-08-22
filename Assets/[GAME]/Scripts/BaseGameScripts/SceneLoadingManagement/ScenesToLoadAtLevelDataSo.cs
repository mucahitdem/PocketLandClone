using Scripts.GameScripts.SceneLoadingManagement;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.BaseGameScripts.SceneLoadingManagement
{
    [CreateAssetMenu(fileName = "ScenesToLoad", menuName = "BaseGame/ScenesToLoad", order = 0)]
    public class ScenesToLoadAtLevelDataSo : ScriptableObject
    {
        public SceneSerialization[] allScenesToLoad;
        public string levelName;

        public string[] GetScenesToLoad()
        {
            var scenes = new string[allScenesToLoad.Length];
            for (var i = 0; i < scenes.Length; i++)
            {
                var currentSceneName = allScenesToLoad[i].sceneName;
                scenes[i] = currentSceneName;
            }

            return scenes;
        }

        [Button]
        private void GetName()
        {
            levelName = name;
        }
    }
}
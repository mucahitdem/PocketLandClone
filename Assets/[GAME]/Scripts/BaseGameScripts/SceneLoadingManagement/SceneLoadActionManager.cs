using System;
using Scripts.BaseGameScripts.SceneLoadingManagement;

namespace Scripts.GameScripts.SceneLoadingManagement
{
    public static class LoadSceneActionManager
    {
        public static Action onLoadingSceneStarted;
        public static Action<ScenesToLoadAtLevelDataSo> loadScene;
        public static Action<float> sceneCompletePercentage;
        public static Action onLoadingSceneCompleted;
    }
}
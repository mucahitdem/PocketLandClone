using System.Collections;
using System.Collections.Generic;
using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.BaseGameScripts.Helper;
using Scripts.GameScripts.SceneLoadingManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.BaseGameScripts.SceneLoadingManagement
{
    public class BaseAsyncSceneLoader : BaseComponent
    {
        private string[] _lastLoadedSceneNames;

        public void LoadScene(ScenesToLoadAtLevelDataSo scenesToLoadAtLevelsDataSo)
        {
            StartCoroutine(LoadScenes(scenesToLoadAtLevelsDataSo));
        }

        
        
        private IEnumerator LoadScenes(ScenesToLoadAtLevelDataSo scenesToLoadAtLevelsDataSo)
        {
            LoadSceneActionManager.onLoadingSceneStarted?.Invoke();
            if (!scenesToLoadAtLevelsDataSo)
                DebugHelper.LogRed("NULL SCENE DATA");
            var allScenesToLoad = scenesToLoadAtLevelsDataSo.allScenesToLoad;
            var sceneNames = scenesToLoadAtLevelsDataSo.GetScenesToLoad();
            var sceneLoadOperations = new List<AsyncOperation>();

            for (var i = 0; i < sceneNames.Length; i++)
            {
                if (_lastLoadedSceneNames != null)
                {
                    for (int j = 0; j < _lastLoadedSceneNames.Length; j++)
                    {
                        var currentLastLoadedSceneName = _lastLoadedSceneNames[j];
                        if(sceneNames[i] == currentLastLoadedSceneName)
                            goto ContinueOuterLoop;
                    }
                }

                var operation = SceneManager.LoadSceneAsync(sceneNames[i], LoadSceneMode.Additive);
                operation.allowSceneActivation = false;
                sceneLoadOperations.Add(operation);
                ContinueOuterLoop: // Labeled statement
                    DebugHelper.LogRed("CONTINUE");
            }

            while (!AllScenesLoaded(sceneLoadOperations))
            {
                var totalProgress = CalculateOverallProgress(sceneLoadOperations, sceneNames);
                LoadSceneActionManager.sceneCompletePercentage?.Invoke(totalProgress);
                yield return null;
            }

            for (var i = 0; i < sceneLoadOperations.Count; i++)
            {
                var currentSceneName = sceneNames[i];
                var sceneToLoad = SceneManager.GetSceneByName(currentSceneName);
                sceneLoadOperations[i].allowSceneActivation = true;
                yield return new WaitUntil(()=> sceneToLoad.isLoaded);
                if (allScenesToLoad[i].IsActiveScene)
                    SceneManager.SetActiveScene(sceneToLoad);
            }

            if (_lastLoadedSceneNames != null)
            {
                for (var i = 0; i < _lastLoadedSceneNames.Length; i++)
                {
                    for (int j = 0; j < sceneNames.Length; j++)
                    {
                        var currentLoadedSceneName = sceneNames[j];
                        if(_lastLoadedSceneNames[i] == currentLoadedSceneName)
                            goto ContinueOuterLoop;
                    }
                    SceneManager.UnloadSceneAsync(_lastLoadedSceneNames[i]);
                    
                    ContinueOuterLoop: // Labeled statement
                        DebugHelper.LogRed("CONTINUE");
                }
            }
               
            _lastLoadedSceneNames = sceneNames;


            LoadSceneActionManager.onLoadingSceneCompleted?.Invoke();
        }
        private bool AllScenesLoaded(List<AsyncOperation> operations)
        {
            foreach (var operation in operations)
                if (operation.progress < .9f)
                    return false;
            return true;
        }
        private float CalculateOverallProgress(List<AsyncOperation> operations, string[] sceneNames)
        {
            var totalProgress = 0f;
            foreach (var operation in operations) totalProgress += operation.progress;
            // Calculate the average progress of all scenes.
            return totalProgress / sceneNames.Length;
        }
    }
}
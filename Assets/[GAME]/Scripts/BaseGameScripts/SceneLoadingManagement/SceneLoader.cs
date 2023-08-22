using System.Collections;
using Scripts.GameScripts.SceneLoadingManagement;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.BaseGameScripts.SceneLoadingManagement
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField]
        private bool addDelayBeforeLoad;

        [ShowIf("addDelayBeforeLoad")]
        [SerializeField]
        private float delayDuration;

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(addDelayBeforeLoad ? delayDuration : 0f);
            LoadScene();
        }

        private void LoadScene()
        {
            var allScenes = AllLevelsDataSo.Instance.ScenesToLoadAtLevels;
            LoadSceneActionManager.loadScene?.Invoke(allScenes[1]);
        }
    }
}
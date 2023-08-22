using Scripts.BaseGameScripts.UiManagement.BaseUiItemManagement;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.GameScripts.SceneLoadingManagement.Ui
{
    public class LoadingSceneUi : BaseUiItem
    {
        [SerializeField]
        private Image loadBar;

        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            LoadSceneActionManager.sceneCompletePercentage += UpdateLoadBar;
            LoadSceneActionManager.onLoadingSceneCompleted += OnLoadingSceneCompleted;
        }

        public override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            LoadSceneActionManager.sceneCompletePercentage -= UpdateLoadBar;
            LoadSceneActionManager.onLoadingSceneCompleted -= OnLoadingSceneCompleted;
        }


        private void OnLoadingSceneCompleted()
        {
            Go.SetActive(false);
        }

        private void UpdateLoadBar(float progress)
        {
            loadBar.fillAmount = progress;
        }

        protected override string GetUiId()
        {
            return Defs.UI_KEY_LOADING_SCREEN;
        }
    }
}
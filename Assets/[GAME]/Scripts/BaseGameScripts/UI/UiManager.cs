using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.BaseGameScripts.UI
{
    public class UiManager : MonoBehaviour
    {
        [SerializeField]
        private List<UiItem> screens = new List<UiItem>();

        public void ShowScreen(string uiItemId)
        {
            ShowOneHideRest(screens, uiItemId);
        }

        private void ShowOneHideRest(List<UiItem> itemGroup, string uiItemId)
        {
            for (var i = 0; i < itemGroup.Count; i++)
            {
                var currentUi = itemGroup[i];

                currentUi.Go.SetActive(uiItemId == currentUi.id);
            }
        }
        

        [Button]
        public void HideScreen(string uiId)
        {
            for (var i = 0; i < screens.Count; i++)
            {
                var currentUi = screens[i];

                if (uiId == currentUi.id)
                {
                    currentUi.Go.SetActive(false);
                    break;
                }
            }
        }
    }
}
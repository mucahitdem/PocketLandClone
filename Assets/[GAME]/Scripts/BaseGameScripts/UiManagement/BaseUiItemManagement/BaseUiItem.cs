using Scripts.BaseGameScripts.ComponentManagement;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEngine;

namespace Scripts.BaseGameScripts.UiManagement.BaseUiItemManagement
{
    public abstract class BaseUiItem : BaseComponent
    {
        protected string uiItemId;

        [ShowInInspector]
        public string UiItemId
        {
            get
            {
                if (uiItemId.IsNullOrWhitespace())
                    try
                    {
                        uiItemId = GetUiId();
                    }
                    catch
                    {
                        uiItemId = "";
                    }

                return uiItemId;
            }
        }

        public virtual void ShowUi(Object component)
        {
            Go.SetActive(true);
        }

        public virtual void HideUi(Object component)
        {
            Go.SetActive(false);
        }

        [Button]
        protected abstract string GetUiId();
    }
}
using System;
using Scripts.BaseGameScripts.UiManagement;
using UnityEngine.EventSystems;

namespace Scripts.GameScripts.UiManagement.OrderUi
{
    public class ConfirmOrderButton : BaseClickableImage
    {
        public Action onClicked;
        
        public override void OnPointerClick(PointerEventData eventData)
        {
            if(!isInteractable)
                return;
            onClicked?.Invoke();
        }

        protected override string GetUiId()
        {
            return null;
        }
    }
}
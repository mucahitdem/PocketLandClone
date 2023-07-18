using System;
using Scripts.BaseGameScripts.UI;
using UnityEngine.EventSystems;

namespace Scripts.GameScripts.UiManagement.OrderUi
{
    public class ConfirmOrderButton : BaseClickableImage
    {
        public Action onClicked;
        
        public override void OnPointerClick(PointerEventData eventData)
        {
            if(!IsInteractable)
                return;
            onClicked?.Invoke();
        }
    }
}
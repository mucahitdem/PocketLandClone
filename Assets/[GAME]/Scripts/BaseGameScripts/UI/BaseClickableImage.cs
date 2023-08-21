using Scripts.BaseGameScripts.ComponentManager;
using UnityEngine.EventSystems;

namespace Scripts.BaseGameScripts.UI
{
    public abstract class BaseClickableImage : BaseComponent, IPointerClickHandler
    {
        public bool IsInteractable { get; set; }
        public abstract void OnPointerClick(PointerEventData eventData);
    }
}
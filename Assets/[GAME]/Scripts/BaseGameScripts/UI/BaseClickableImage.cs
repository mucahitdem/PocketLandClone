using Scripts.BaseGameScripts.Component;
using UnityEngine.EventSystems;

namespace Scripts.BaseGameScripts.UI
{
    public abstract class BaseClickableImage : BaseComponent, IPointerClickHandler
    {
        public abstract void OnPointerClick(PointerEventData eventData);
    }
}
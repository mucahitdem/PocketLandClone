using Scripts.BaseGameScripts.Helper;
using UnityEngine;

namespace Scripts.BaseGameScripts.EventManagement
{
    public abstract class EventSubscriber : MonoBehaviour
    {
        protected abstract void SubscribeEvent();

        protected abstract void UnsubscribeEvent();

        public virtual void OnEnable()
        {
            SubscribeEvent();
        }

        public virtual void OnDisable()
        {
            UnsubscribeEvent();
        }
    }
}
using Scripts.BaseGameScripts.Helper;
using UnityEngine;

namespace Scripts.BaseGameScripts.EventManagement
{
    public abstract class EventSubscriber : MonoBehaviour, IEventSubscriber
    {
        public abstract void SubscribeEvent();
        public abstract void UnsubscribeEvent();

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
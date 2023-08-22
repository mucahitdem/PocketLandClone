using System;
using Scripts.BaseGameScripts.Helper;

namespace Scripts.BaseGameScripts.EventManagement
{
    public static class EventSystemHelper
    {
        public static void Send<T>(this T @this, params object[] args) where T : Type
        {
            EventMediator.Instance.SendEvent(@this, args);
        }

        public static void Subscribe(this Type @this, Delegate @delegate)
        {
            EventMediator.Instance.Subscribe(@delegate, @this);
        }

        public static void Unsubscribe(this Type @this, Delegate @delegate)
        {
            if (EventMediator.Instance == null)
            {
                DebugHelper.LogRed("EVENT MEDIATOR IS NULL");
                return;
            } 
            EventMediator.Instance.Unsubscribe(@delegate, @this);
        }
    }
}
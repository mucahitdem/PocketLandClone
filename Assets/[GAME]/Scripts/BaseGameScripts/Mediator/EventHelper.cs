using System;

namespace Scripts.Mediator
{
    public static class EventHelper
    {
        public static void Send<T>(this T @this, params object[] args) where T : Type
        {
            Mediator.Instance.SendEvent(@this, args);
        }

        public static void Subscribe(this Type @this, Delegate @delegate)
        {
            Mediator.Instance.Subscribe(@delegate, @this);
        }

        public static void Unsubscribe(this Type @this, Delegate @delegate)
        {
            if (Mediator.IsNull) return;
            Mediator.Instance.Unsubscribe(@delegate, @this);
        }
    }
}
using System;
using Scripts.BaseGameScripts.EventManagement._BaseEvent;

namespace Scripts.BaseGameScripts.EventManagement.Events
{
    public class AddSourceEvent : BaseEvent
    {
        public static void Send(float coinsToAdd, bool save)
        {
            typeof(BaseEvent).Send(coinsToAdd, save);
        }

        public static void Subscribe(Delegate @delegate)
        {
            typeof(BaseEvent).Subscribe(@delegate);
        }

        public static void Unsubscribe(Delegate @delegate)
        {
            typeof(AddSourceEvent).Unsubscribe(@delegate);
        }
    }
}
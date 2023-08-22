using System;
using System.Collections.Generic;
using System.Reflection;
using Scripts.BaseGameScripts.Helper;

namespace Scripts.BaseGameScripts.EventManagement
{
    public class EventMediator : SingletonMono<EventMediator>
    { 
        private Dictionary<object, List<Delegate>> _eventsDictionary;

        protected override void OnAwake()
        {
            _eventsDictionary = new Dictionary<object, List<Delegate>>();
        }
        
        
        public void Subscribe(Delegate @delegate, object eventType)
        {
            if (!_eventsDictionary.ContainsKey(eventType)) 
                CreateNewEventType(eventType);
            _eventsDictionary[eventType].Add(@delegate);
        }
        public void SendEvent(object eventType, params object[] args)
        {
            if (!_eventsDictionary.ContainsKey(eventType)) 
                return;
            var delegatesCopyToLoop = _eventsDictionary[eventType].ToArray();
            foreach (var fun in delegatesCopyToLoop)
                try
                {
                    fun?.DynamicInvoke(args);
                }
                catch (Exception e)
                {
                    if (e is TargetParameterCountException)
                        continue;
                    if (e is ArgumentException)
                        continue;
                    //if (e is Another exception about parameters dont match) continue;
                    print(eventType);

                    throw;
                }
        }
        public void Unsubscribe(Delegate @delegate, object eventType)
        {
            if (!_eventsDictionary.ContainsKey(eventType)) return;
            if (!_eventsDictionary[eventType].Contains(@delegate)) return;
            _eventsDictionary[eventType].Remove(@delegate);
        }

        
        private void CreateNewEventType(object eventType)
        {
            _eventsDictionary.Add(eventType, new List<Delegate>());
        }
    }
}
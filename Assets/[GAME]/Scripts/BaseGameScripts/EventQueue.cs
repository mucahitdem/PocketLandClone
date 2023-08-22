using System;
using System.Collections.Generic;
using Scripts.BaseGameScripts.ComponentManagement;

namespace Scripts.BaseGameScripts
{
    public class EventQueue : BaseComponent
    {
        private readonly Queue<Action> _actionQueue = new Queue<Action>();

        private void Update()
        {
            if (_actionQueue.Count > 0)
            {
                DequeueAndInvoke();
            }
        }

        public void AddToQueue(Action action)
        {
            _actionQueue.Enqueue(action);
        }

        private void DequeueAndInvoke()
        {
            var action = _actionQueue.Dequeue();
            action.Invoke();
        }
    }
}
using System.Collections.Generic;
using Scripts.BaseGameScripts.Helper;
using UnityEngine;

namespace Scripts.BaseGameScripts.TimerManagement
{
    public class TimerManager : SingletonMono<TimerManager>
    {
        private readonly List<Timer> _timerList = new List<Timer>();
        
        protected override void OnAwake()
        {
        }
        private void Update()
        {
            UpdateTimers();
        }

        
        public void AddNewTimer(Timer timer)
        {
            //DebugHelper.LogGreen("TIMER ADDED : " + timer.name);
            if (!_timerList.Contains(timer))
                _timerList.Add(timer);
        }
        public void RemoveTimer(Timer timer)
        {
            if (_timerList.Contains(timer))
                _timerList.Remove(timer);
        }
        public void RemoveAllTimers()
        {
            _timerList.Clear();
        }
        
        private void UpdateTimers()
        {
            var currentDeltaTime = Time.deltaTime;
            for (var i = 0; i < _timerList.Count; i++)
            {
                _timerList[i].UpdateTimer(currentDeltaTime);
            }
        }
    }
}
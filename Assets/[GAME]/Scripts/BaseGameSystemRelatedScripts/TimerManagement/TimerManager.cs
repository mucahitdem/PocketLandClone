using System.Collections.Generic;
using Scripts.BaseGameScripts.Helper;
using UnityEngine;

namespace Scripts.BaseGameSystemRelatedScripts.TimerManagement
{
    public class TimerManager : SingletonMono<TimerManager>
    {
        private List<TimerManagement.Timer> _timerList = new List<TimerManagement.Timer>();

        protected override void OnAwake()
        {
            
        }
        
        public void AddNewTimer(TimerManagement.Timer timer)
        {
            //DebugHelper.LogGreen("TIMER ADDED : " + timer.name);
            if(!_timerList.Contains(timer))
                _timerList.Add(timer);    
        }

        public void RemoveTimer(Timer timer)
        {
            if(_timerList.Contains(timer))
                _timerList.Remove(timer);
        }

        private void Update()
        {
            UpdateTimers();
        }

        private void UpdateTimers()
        {
            for (int i = 0; i < _timerList.Count; i++)
            {
                _timerList[i].TimerValue -= Time.deltaTime;
            }
        }
    }
}
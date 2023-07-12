using System;
using Scripts.BaseGameScripts.Helper;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.BaseGameSystemRelatedScripts.TimerManagement
{
    public class Timer : MonoBehaviour
    {
        public Action onTimerEnded;
        
        public float TimerValue
        {
            get => _timerValue; 
            set
            {
                if (Math.Abs(value - _timerValue) > .0001f)
                {
                    _timerValue = value;

                    if (_timerValue <= 0)
                    {
                        onTimerEnded?.Invoke();
                        
                        if (timerData.isRepeating)
                        {
                            ResetTimer();
                            return;
                        }
                        
                        StopTimer();
                    }
                }
            }
        }
        public bool IsPaused { get; private set; }
        public bool IsRunning { get; private set; }
        public float PassedDurationRate => (DataTimerValue - TimerValue) / DataTimerValue; // returns between 0 - 1
        
        
        private float CurrentTimerValue { get; set; }
        private float DataTimerValue => timerData.timerValue;
        
        [SerializeField]
        private TimerData timerData;
        
        [Title("Private Variables")]
        private float _timerValue;

        private void Start()
        {
            SetTimerVariables();
        }

        #region Public Methods
        /// <summary>
        /// Reset and start timer
        /// </summary>
        public void RestartTimer()
        {
            if(IsPaused)
                return;
            
            ResetTimer();
            StartTimer();
        }
        
        /// <summary>
        /// play and pause timer
        /// </summary>
        /// <param name="pause"></param>
        public void PausePlayTimer(bool pause)
        {
            IsPaused = pause;
            //DebugHelper.LogRed("IS PAUSED : " + IsPaused);
            
            if(IsPaused)
                StopTimer();
            else
                StartTimer();
        }
        
        /// <summary>
        /// Stop timer
        /// </summary>
        public void StopTimer()
        {
            IsRunning = false;
            TimerManager.Instance.RemoveTimer(this);
        }
        
        
        
        public void UpdateInitialValue(float newTimerValue)
        {
            timerData.timerValue = newTimerValue;
            ResetToInitialValue();
        }

        private void ResetToInitialValue()
        {
            CurrentTimerValue = DataTimerValue;
        }

        public void UpdateTimerValue(float newTimer = 0f, float percentage = 0f)
        {
            if(newTimer > 0)
                CurrentTimerValue = newTimer;
            else if (percentage > 0)
                CurrentTimerValue = DataTimerValue * percentage / 100f;
        }
        

        #endregion

        #region Private Variables
        
        private void SetTimerVariables()
        {
            CurrentTimerValue = DataTimerValue;
            
            IsRunning = false;
            IsPaused = false;
            
            if (!timerData.restartManually)
            {
                RestartTimer();
            }
        }
        
        
        private void StartTimer()
        {
            if(IsPaused)
                return;

            IsRunning = true;
            TimerManager.Instance.AddNewTimer(this);
        }
        
        private void ResetTimer()
        {
            TimerValue = CurrentTimerValue;
        }

        #endregion
    }
}
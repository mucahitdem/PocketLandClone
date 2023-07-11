using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.BaseGameSystemRelatedScripts.TimerManagement
{
    [Serializable]
    public class Timer : MonoBehaviour
    {
        public Action onTimerEnded;
        public float PassedDurationRate => (InitialTimerValue - TimerValue) / InitialTimerValue; // returns between 0 - 1
        public float CurrentTimerValue { get; private set; }
        public float InitialTimerValue { get; private set; }
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
                        
                        if (timerVariables.isRepeating)
                        {
                            ResetTimer();
                            return;
                        }
                        
                        RemoveTimerFromManager();
                    }
                }
            }
        }
        public bool IsPaused
        {
            get => _isPaused;
            private set => _isPaused = value;
        }

        public bool IsRunning
        {
            get => _isRunning;
            set => _isRunning = value;

        }
        
        [SerializeField]
        private TimerVariables timerVariables;
        
        [Title("Private Variables")]
        private float _timerValue;

        private bool _isPaused;
        private bool _isRunning;

        public void Start()
        {
            SetTimerVariables();
            OnStartTimerAuto();
        }

        #region Public Methods

        public void RestartTimer()
        {
            if(IsPaused)
                return;
            
            ResetTimer();
            StartTimer();
        }
        
        public void PausePlayTimer(bool pause)
        {
            IsPaused = pause;
            //DebugHelper.LogRed("IS PAUSED : " + IsPaused);
            
            if(IsPaused)
                StopTimer();
            else
                StartTimer();
        }
        
        public void StopTimer()
        {
            IsRunning = false;
            TimerManager.Instance.RemoveTimer(this);
        }
        
        public void ResetToInitialValue()
        {
            CurrentTimerValue = InitialTimerValue;
        }

        public void UpdateTimerValue(float newTimer = 0f, float percentage = 0f)
        {
            if(newTimer > 0)
                CurrentTimerValue = newTimer;
            else if (percentage > 0)
                CurrentTimerValue = InitialTimerValue * percentage / 100f;
            
            //RestartTimer(); //todo fix
        }

        public void UpdateInitialValue(float newTimer)
        {
            timerVariables.timerValue = newTimer;
        }

        #endregion

        #region Private Variables
        
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
        
        private void AddTimerToManager()
        {
            TimerManager.Instance.AddNewTimer(this);
        }
        private void RemoveTimerFromManager()
        {
            TimerManager.Instance.RemoveTimer(this);
        }
        private void SetTimerVariables()
        {
            InitialTimerValue = timerVariables.timerValue;
            CurrentTimerValue = InitialTimerValue;
            IsRunning = false;
            IsPaused = false;
        }
        private void OnStartTimerAuto()
        {
            if (!timerVariables.restartManually)
            {
                RestartTimer();
            }
        }

        #endregion
    }

    [Serializable]
    public class TimerVariables
    {
        [Title("Timer")]
        public float timerValue;
        
        [Title("Repeat")]
        public bool isRepeating;

        [Title("Starting Timer")]
        public bool restartManually;
    }
}
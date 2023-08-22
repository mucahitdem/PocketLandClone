using System;
using Scripts.BaseGameScripts.Helper;
using UnityEngine;

namespace Scripts.BaseGameScripts.TimerManagement
{
    public sealed class Timer : MonoBehaviour
    {
        // public Action<float> onTimerValueUpdate;
        // public Action<float> onPassedTimePercentageUpdate;
        public Action onTimerEnded;

        [SerializeField]
        private TimerData timerData;

        private float DataTimerValue => timerData.timerValue;
        private float TimerValue
        {
            get => _timerValue;
            set
            {
                if (Math.Abs(value - _timerValue) > .0001f)
                {
                    _timerValue = value;
          
                    if (IsTimerEnded())
                    {
                        OnTimerEnded();
                    }
                }
            }
        }
        public bool IsRunning { get; private set; }
        public float PassedDurationRate => (DataTimerValue - TimerValue) / DataTimerValue; // returns between 0 - 1
        
        private bool IsPaused { get; set; }
        private float CurrentTimerValue { get; set; }
        private float _timerValue;

        private void Start()
        {
            SetTimerVariables();
        }


        /// <summary>
        ///     Reset and start timer
        /// </summary>
        public void RestartTimer()
        {
            if (IsPaused)
                return;

            ResetTimer();
            StartTimer();
        }
        /// <summary>
        ///     play and pause timer
        /// </summary>
        /// <param name="pause"></param>
        public void PausePlayTimer(bool pause)
        {
            IsPaused = pause;
            //DebugHelper.LogRed("IS PAUSED : " + IsPaused);

            if (IsPaused)
                StopTimer();
            else
                StartTimer();
        }
        /// <summary>
        ///     Stop timer
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
        public void UpdateTimerValue(float newTimer = 0f, float percentage = 0f)
        {
            if (newTimer > 0)
                CurrentTimerValue = newTimer;
            else if (percentage > 0)
                CurrentTimerValue = DataTimerValue * percentage / 100f;
        }

        public void UpdateTimer(float deltaTime)
        {
            TimerValue -= deltaTime;
        }

        private bool IsTimerEnded()
        {
            return _timerValue <= 0f;
        }

        private void OnTimerEnded()
        {
            onTimerEnded?.Invoke();

            if (timerData.isRepeating)
            {
                ResetTimer();
                return;
            }

            StopTimer();
        }
        
        
        private void ResetToInitialValue()
        {
            CurrentTimerValue = DataTimerValue;
        }
        private void SetTimerVariables()
        {
            CurrentTimerValue = DataTimerValue;

            IsRunning = false;
            IsPaused = false;

            if (!timerData.restartManually) RestartTimer();
        }
        private void StartTimer()
        {
            if (IsPaused)
                return;

            IsRunning = true;
            TimerManager.Instance.AddNewTimer(this);
        }
        private void ResetTimer()
        {
            TimerValue = CurrentTimerValue;
        }
    }
}
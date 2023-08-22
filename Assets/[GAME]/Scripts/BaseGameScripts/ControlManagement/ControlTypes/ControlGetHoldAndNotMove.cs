using System;
using Scripts.BaseGameScripts.TimerManagement;
using UnityEngine;

namespace Scripts.BaseGameScripts.Control.ControlTypes
{
    public class ControlGetHoldAndNotMove : BaseControl
    {
        private CalculateDeltaMouse _calculateDeltaMouse;
        private float _screenHeight;
        private float _screenWidth;

        [SerializeField]
        private float sensitivity;

        public Action tapAndNotMove;

        [SerializeField]
        private Timer timer;

        private void Awake()
        {
            _screenHeight = Screen.height / sensitivity;
            _screenWidth = Screen.width / sensitivity;
            _calculateDeltaMouse = new CalculateDeltaMouse();
        }

        public override void GetInput()
        {
        }

        public void Reset()
        {
            _calculateDeltaMouse?.ResetValues();
        }

        protected override void OnTapDown()
        {
            base.OnTapDown();
            _calculateDeltaMouse.ResetValues();
        }

        protected override void OnTapHold()
        {
            // if(!isControlEnabled)
            //     return;
            base.OnTapHold();
            _calculateDeltaMouse.CalculateDeltaMousePos();

            if (Mathf.Abs(_calculateDeltaMouse.deltaMousePos.x) <= _screenWidth &&
                Mathf.Abs(_calculateDeltaMouse.deltaMousePos.y) <= _screenHeight)
            {
                // if (timer.TimerValue <= 0f || !timer.IsRunning)
                //     timer.RestartTimer();
            }
            else
            {
                if (timer.IsRunning)
                    timer.StopTimer();
            }

            Reset();
        }

        protected override void OnTapUp()
        {
            base.OnTapUp();
            timer.StopTimer();
        }


        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            timer.onTimerEnded += OnTimerEnded;
        }

        public override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            timer.onTimerEnded -= OnTimerEnded;
        }


        private void OnTimerEnded()
        {
            tapAndNotMove?.Invoke();
        }
    }
}
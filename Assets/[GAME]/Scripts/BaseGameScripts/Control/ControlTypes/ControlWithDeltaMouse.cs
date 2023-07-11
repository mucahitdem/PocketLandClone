using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.BaseGameScripts.Control.ControlTypes
{
    public class ControlWithDeltaMouse : BaseControl
    {
        public static Action<Vector2> onDraggedEnough;
        public static Action inputStopped;
        
        private CalculateDeltaMouse _calculateDeltaMouse;

        [SerializeField]
        private float percentageOfScreen;

        [ReadOnly]
        [ShowInInspector]
        private float _pixelCountOnHeightToCallAction;

        [ReadOnly]
        [ShowInInspector]
        private float _pixelCountOnWidthToCallAction;
        
        private float _screenHeight;
        private float _screenWidth;
        private Vector2 _deltaMousePos;
        private Vector2 _way;
         
        private void Awake()
        {
            _calculateDeltaMouse = new CalculateDeltaMouse();
            _screenHeight = Screen.height;
            _screenWidth = Screen.width;
            _pixelCountOnHeightToCallAction = _screenHeight * percentageOfScreen / 100f;
            _pixelCountOnWidthToCallAction = _screenWidth * percentageOfScreen / 100f;
        }

        protected override void OnTapDown()
        {
            base.OnTapDown();
            _calculateDeltaMouse.ResetValues();
        }

        protected override void OnTapHold()
        {
            base.OnTapHold();
            GetInput();
        }

        protected override void OnTapUp()
        {
            base.OnTapUp();
            inputStopped?.Invoke();
        }

        protected override void OnTapHoldAndNotMove()
        {
            base.OnTapHoldAndNotMove();
            inputStopped?.Invoke();
        }

        public override void GetInput()
        {
            _calculateDeltaMouse.CalculateDeltaMousePos();      
            OnDraggedAsDesired();
        }

        private void OnDraggedAsDesired()
        {
            _deltaMousePos = _calculateDeltaMouse.deltaMousePos;
            _way = new Vector2(0,0);
            
            if (Mathf.Abs(_deltaMousePos.y) >= _pixelCountOnHeightToCallAction)
            {
                _way = new Vector2(0, _deltaMousePos.y > 0 ? 1 : -1);

                onDraggedEnough?.Invoke(_way);
                _calculateDeltaMouse.ResetValues();
            }
        }
    }
}
using System;
using UnityEngine;

namespace Scripts.BaseGameScripts.Control.ControlTypes
{
    public class ControlSlide : BaseControl
    {
        private CalculateDeltaMouse _calculateDeltaMouse;
        
        [Header("Swipe Variables")]
        public float clampMaxVal;
        public float lerpMultiplier = 1;
        public float mouseDamp = 600;

        private float _screenWidth;

        private void Awake()
        {
            _screenWidth = Screen.width;
            _calculateDeltaMouse = new CalculateDeltaMouse();
        }
        
        public override void GetInput()
        {
            Slide();
        }

        protected override void OnTapDown()
        {
            base.OnTapDown();
            _calculateDeltaMouse.ResetValues();
        }

        protected override void OnTapHold()
        {
            base.OnTapHold();
            _calculateDeltaMouse.CalculateDeltaMousePos();
            GetInput();
        }

        private void Slide()
        {
            var objPos = TransformOfObj.position;

            var xPos = objPos.x;
            xPos = Mathf.Lerp(xPos, xPos + mouseDamp * (_calculateDeltaMouse.deltaMousePos.x / _screenWidth), Time.deltaTime * lerpMultiplier);
            xPos = Mathf.Clamp(xPos, -clampMaxVal, clampMaxVal);

            TransformOfObj.position = new Vector3(xPos, objPos.y, objPos.z);

            _calculateDeltaMouse.ResetValues();
        }
    }
}
using System;
using Scripts.GameScripts;
using UnityEngine;

namespace Scripts.BaseGameScripts.Control.ControlTypes
{
    public class ControlSwipe : BaseControl
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
        
        public override void GetInput()
        {
            _calculateDeltaMouse.CalculateDeltaMousePos();
            Swipe();
        }

        private void Swipe()
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
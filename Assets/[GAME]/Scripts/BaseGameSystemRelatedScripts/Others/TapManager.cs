using System;
using System.Collections.Generic;
using Scripts.BaseGameScripts.Component;
using Scripts.BaseGameScripts.Helper;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Scripts.BaseGameSystemRelatedScripts.Others
{
    public class TapManager : BaseComponent
    {
        public static Action<float> onTapFactorChanged;
        public static bool isTapActive;
        
        private float _timer = 0.5f;

        private static float s_currentFactor;

        public static float CurrentFactor
        {
            get => s_currentFactor;
            set
            {
                if (Math.Abs(value - s_currentFactor) > .0001f)
                {
                    s_currentFactor = value;
                    onTapFactorChanged?.Invoke(s_currentFactor);
                }
            }
        }

        [SerializeField]
        private float defaultVal;
        
        [SerializeField]
        private float maxFactor = 5f;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && !TouchOnUI())
            {
                OnTap();
            }
            else
            {
                Resetting();
            }
            
            //DebugHelper.LogYellow("CURRENT TAP FACTOR : " + CurrentFactor);
        }
        
        private void OnTap()
        {
            _timer = 0.5f;
            CurrentFactor = maxFactor;
            isTapActive = true;
        }

        private void Resetting()
        {
            _timer -= Time.deltaTime;
            if (_timer < 0)
            {
                CurrentFactor = defaultVal;
                isTapActive = false;
            }
        }

        private bool TouchOnUI()
        {
            if (!EventSystem.current) 
                return false;
            
            var eventDataCurrentPosition = new PointerEventData(EventSystem.current);
            eventDataCurrentPosition.position = Input.mousePosition;

            var results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
            var onUi = results.Count != 0;
            
            //DebugHelper.LogRed("ON UI : " + onUi);
            return onUi;
        }
    }
}
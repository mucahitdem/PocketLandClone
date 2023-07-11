using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.BaseGameScripts.Control.ControlTypes
{
    public class ControlWithSwipeWay : BaseControl
    {
        public static Action<Vector2> draggedWay;
        
        private CalculateDeltaMouse _calculateDeltaMouse;
        private Vector3 _deltaMousePos;
        private Vector2 _way;
        
        private void Awake()
        {
            _calculateDeltaMouse = new CalculateDeltaMouse();
        }
        
        protected override void OnTapHold()
        {
            base.OnTapHold();
            GetInput();
        }

        public override void GetInput()
        {
            _calculateDeltaMouse.CalculateDeltaMousePos();      
            CalculateDirection();
        }

        private void CalculateDirection()
        {
            _deltaMousePos = _calculateDeltaMouse.deltaMousePos;
            _way = new Vector2(0,0);

            if (_deltaMousePos.x > _deltaMousePos.y) // right -left
            {
                _way = new Vector2(_deltaMousePos.x > 0 ? 1 : -1, 0);
            }
            else
            {
                _way = new Vector2(0, _deltaMousePos.y > 0 ? 1 : -1);
            }
            
            draggedWay?.Invoke(_way);
        }
    }
}
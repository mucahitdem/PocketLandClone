using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.BaseGameScripts.Control
{
    public class CalculateDeltaMouse
    {
        private Vector2 _currentMousePos;

        [ReadOnly]
        public Vector2 deltaMousePos;

        [ReadOnly]
        public Vector2 mouseStartPos;

        public void CalculateDeltaMousePos()
        {
            _currentMousePos = Input.mousePosition;
            deltaMousePos =
                new Vector2(_currentMousePos.x - mouseStartPos.x,
                    _currentMousePos.y - mouseStartPos.y); // how much mouse dragged
        }

        public void ResetValues()
        {
            mouseStartPos = Input.mousePosition;
        }
    }
}
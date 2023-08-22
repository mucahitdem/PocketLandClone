using UnityEngine;

namespace Scripts.BaseGameScripts.Control.ControlTypes
{
    public class ControlSendRayToMousePosition : BaseControl
    {
        private Vector3 _mousePos;

        private Ray _ray;

        [SerializeField]
        private Camera cam;

        protected RaycastHit hit;

        [SerializeField]
        private LayerMask layer;

        protected override void OnTapHold()
        {
            base.OnTapHold();
            GetInput();
        }

        public override void GetInput()
        {
            CastToMousePos();
        }

        private void CastToMousePos()
        {
            _mousePos = Input.mousePosition;
            _ray = cam.ScreenPointToRay(_mousePos);

            if (Physics.Raycast(_ray, out hit, Mathf.Infinity, layer.value)) OnHitAnyObject();
        }

        protected virtual void OnHitAnyObject()
        {
        }
    }
}
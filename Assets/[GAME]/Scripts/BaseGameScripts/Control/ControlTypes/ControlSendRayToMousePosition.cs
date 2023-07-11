using UnityEngine;


namespace Scripts.BaseGameScripts.Control.ControlTypes
{
    public class ControlSendRayToMousePosition : BaseControl
    {
        [SerializeField]
        private UnityEngine.Camera cam;

        [SerializeField]
        private LayerMask layer;

        protected RaycastHit hit;
        
        private Ray _ray;
        private Vector3 _mousePos;
        
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
            _mousePos = UnityEngine.Input.mousePosition;
            _ray = cam.ScreenPointToRay(_mousePos);
            
            if (Physics.Raycast(_ray, out hit, Mathf.Infinity, layer.value))
            {
                OnHitAnyObject();
            }
        }

        protected virtual void OnHitAnyObject()
        {
            
        }
    }
}
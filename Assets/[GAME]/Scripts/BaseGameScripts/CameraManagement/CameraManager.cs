using Scripts.BaseGameScripts.Helper;
using UnityEngine;

namespace Scripts.BaseGameScripts.CameraManagement
{
    public class CameraManager : SingletonMono<CameraManager>
    {
        private UnityEngine.Camera _mainCamera;

        public UnityEngine.Camera MainCamera
        {
            get
            {
                if (_mainCamera == null)
                    _mainCamera = Camera.main;
                return _mainCamera;
            }
            set => _mainCamera = value;
        }

        protected override void OnAwake()
        {
           
        }
    }
}
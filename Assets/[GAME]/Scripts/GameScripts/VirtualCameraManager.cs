using Cinemachine;
using Scripts.BaseGameScripts.Component;
using UnityEngine;

namespace Scripts.GameScripts
{
    /// <summary>
    ///     Control distance of virtual camera with offset and multiplier
    /// </summary>
    public class VirtualCameraManager : BaseComponent
    {
        private CinemachineTransposer _transposer;

        [SerializeField]
        private float multiplier;

        [SerializeField]
        private Vector3 offset;

        [SerializeField]
        private CinemachineVirtualCamera vcam;

        private CinemachineTransposer Transposer
        {
            get
            {
                if (!_transposer)
                    _transposer = vcam.GetCinemachineComponent<CinemachineTransposer>();

                return _transposer;
            }
        }


        private void OnValidate()
        {
            Transposer.m_FollowOffset = offset * multiplier;
        }
    }
}
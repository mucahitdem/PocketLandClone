using Scripts.GameScripts;
using UnityEngine;

namespace Scripts.BaseGameScripts.ControlManagement
{
    public class ControlManager : MonoBehaviour
    {
        private IControl _control;

        private void Awake()
        {
            _control = GetComponent<IControl>();
        }
    }
}
using Scripts.GameScripts;
using UnityEngine;

namespace Scripts.BaseGameScripts.Control
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
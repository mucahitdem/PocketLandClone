using Scripts.BaseGameScripts.Helper;
using UnityEngine;

namespace Scripts.GameScripts.MovementManagement
{
    public class MoveWithJoystick : BaseMovementManager
    {
        [SerializeField]
        private FloatingJoystick joystick;


        protected override void GetInput()
        {
            DebugHelper.LogGreen(joystick.Horizontal + " --- " + joystick.Vertical);
            input = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
        }
    }
}
using UnityEngine;

namespace Scripts.GameScripts.MovementManagement
{
    public class MoveWithJoystick : BaseMovementManager
    {
        [SerializeField]
        private FloatingJoystick joystick;

        protected override void GetInput()
        {
            input = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
        }
    }
}
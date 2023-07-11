using UnityEngine;

namespace Scripts.GameScripts.Player
{
    public static class MovementHelper
    {
        private static Matrix4x4 s_isoMatrix = Matrix4x4.Rotate(Quaternion.Euler(0f,45f,0f));
        public static Vector3 ToIso(this Vector3 input) => s_isoMatrix.MultiplyPoint(input);
    }
}
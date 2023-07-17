using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public VariableJoystick variableJoystick;

    public void FixedUpdate()
    {
        var direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
    }
}
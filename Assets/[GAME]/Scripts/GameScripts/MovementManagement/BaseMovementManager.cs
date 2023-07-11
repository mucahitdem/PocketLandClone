using Scripts.BaseGameScripts.Component;
using UnityEngine;

namespace Scripts.GameScripts.MovementManagement
{
    public abstract class BaseMovementManager : BaseComponent
    {
        [SerializeField]
        private float moveSpeed;

        [SerializeField]
        private float turnSpeed;

        [SerializeField]
        private float downForce;
        
        protected Vector3 input;

        public void OnUpdate()
        {
            GetInput();
            Look();
        }
        public void OnFixedUpdate()
        {
            Move();
            AddDownForce();
        }

        
        protected abstract void GetInput();
        
        
        private void AddDownForce()
        {
            Rb.angularVelocity = Vector3.zero;
            Rb.AddForce(-Vector3.up * downForce, ForceMode.Acceleration);
        }
        private void Look()
        {
            if (input != default)
            {
                var rot = Quaternion.LookRotation(input, Vector3.up);
                
                TransformOfObj.rotation = Quaternion.RotateTowards(TransformOfObj.rotation, rot, turnSpeed * Time.deltaTime);
            }
        }
        private void Move()
        {
            Rb.MovePosition(TransformOfObj.position + input * (input.magnitude * moveSpeed * Time.deltaTime));
        }
    }
}
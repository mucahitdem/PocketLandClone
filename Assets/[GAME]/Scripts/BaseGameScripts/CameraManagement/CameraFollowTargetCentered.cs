using System;
using Scripts.BaseGameScripts.Component;
using UnityEngine;

namespace Scripts.BaseGameScripts.CameraManagement
{
    public class CameraFollowTargetCentered : BaseComponent
    {
        [SerializeField]
        private Transform targetObj;

        [SerializeField]
        private Transform playerObj;

        [SerializeField]
        private float cameraDist;
        
        [SerializeField]
        private Vector3 offset;

        [SerializeField]
        private float rotXOffset;
        
        [SerializeField]
        private float rotZOffset;
        
        [SerializeField]
        private float turnSpeed;

        [SerializeField]
        private float speed;

        
        private Vector3 vel;
        private Vector3 newPos;
        
        private void FixedUpdate()
        {
            newPos = playerObj.position + (-Dir() * cameraDist) + offset;
            
            // TransformOfObj.LookAt(targetObj, Vector3.up);
            LockOnTarget(targetObj);
            TransformOfObj.position = Vector3.SmoothDamp(TransformOfObj.position, newPos, ref vel, speed);
        }

        public void UpdateTargetObj(Transform newTarget)
        {
            targetObj = newTarget;
        }

        private Vector3 Dir()
        {
            return (targetObj.position - playerObj.position).normalized;
        }
        
        private void LockOnTarget (Transform target)
        {
            Vector3 dir = target.position - TransformOfObj.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            var objRot = TransformOfObj.rotation;
            Vector3 rotation = Quaternion.Lerp(objRot, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
            TransformOfObj.rotation = Quaternion.Euler(rotXOffset, rotation.y, rotZOffset);
        }
    }
}
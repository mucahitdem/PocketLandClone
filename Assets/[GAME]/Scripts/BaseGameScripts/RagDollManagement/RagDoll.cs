using Scripts.BaseGameScripts.Component;
using Scripts.BaseGameScripts.Helper;
using Scripts.BaseGameSystemRelatedScripts;
using Scripts.GameScripts;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.BaseGameScripts.RagDollManagement
{
    public class RagDoll : BaseComponent
    {
        [Header("Main Components")]
        [SerializeField]
        private Animator animatorOfTransform;
        
        [SerializeField]
        private Collider mainColliderOfTransform;
        
        [SerializeField]
        private Rigidbody rigidBodyOfTransform;
        
        [SerializeField]
        private MinMaxValue minMaxHeadShotForceToAllBody;

        [SerializeField]
        private MinMaxValue minMaxHeadShotForceToHead;

        [Header("Sub-Components")]
        private Collider[] _subCollider;
        private Rigidbody[] _subRigidBody;

        [SerializeField]
        private Rigidbody head;

        private void Awake()
        {
            _subCollider = TransformOfObj.GetComponentsInChildren<Collider>(true);
            _subRigidBody = TransformOfObj.GetComponentsInChildren<Rigidbody>(true);
            
            foreach (var npcRb in _subRigidBody)
                npcRb.interpolation = RigidbodyInterpolation.Interpolate;
            
            WholeBodyRagDoll(false);
        }

        
        
        
        [Button]
        public void WholeBodyRagDoll(bool ragDollState, bool isKinematic = false)
        {
            if(ragDollState)
                ChangeAllColliderLayer();

            foreach (var col in _subCollider)
            {
                col.enabled = ragDollState;
            } 

            foreach (var npcRb in _subRigidBody) 
                npcRb.isKinematic = isKinematic ? true : !ragDollState;

            rigidBodyOfTransform.isKinematic = ragDollState; // main rigidbody on player
            mainColliderOfTransform.enabled = !ragDollState; // main collider on player
            animatorOfTransform.enabled = !ragDollState; //
        }

        public void AddForceToRagDoll(Vector3 dir)
        {
            ChangeAllColliderLayer();

            WholeBodyRagDoll(true);
            
            foreach (var npcRb in _subRigidBody) 
                npcRb.AddForce(dir * 50, ForceMode.Impulse);
        }

        [Button]
        public void HeadShot(float forceMultiplier, bool isKinematic = false)
        {
            ChangeAllColliderLayer();
            WholeBodyRagDoll(true);
            var position = head.position;
            var forcePosition = position + TransformOfObj.forward * 2;
            var dir = (position - forcePosition).normalized  + Vector3.up * 2f + Vector3.forward * .2f;
            
            foreach (var npcRb in _subRigidBody) 
                npcRb.AddForce(dir * (minMaxHeadShotForceToAllBody.RandomFloat() * forceMultiplier * Time.fixedDeltaTime), ForceMode.Impulse);
            
            head.AddForce(dir * (minMaxHeadShotForceToHead.RandomFloat() * forceMultiplier * Time.fixedDeltaTime), ForceMode.Impulse);
        }

        
        
        private void ChangeAllColliderLayer()
        {
            foreach (var col in _subCollider)
            {
                col.gameObject.layer = LayerMask.NameToLayer(Defs.LAYER_DEAD);
            } 
        }
    }
}
using UnityEngine;

namespace Scripts.Ragdoll
{
    public class RagDoll : MonoBehaviour
    {
        [Header("Main Components")]
        private Animator _animatorOfTransform;

        private Collider _mainColliderOfTransform;
        private Rigidbody _rigidbodyOfTransform;

        [Header("Sub-Components")]
        private Collider[] _subCollider;

        private Rigidbody[] _subRigidbody;

        [Header("Spines-Neck-Head")]
        [SerializeField]
        private Transform[] spinesAndNeck;


        public void SetUp(Transform ragDollParent, Animator anim, Rigidbody rbTransform, Collider colliderMain)
        {
            _animatorOfTransform = anim;
            _rigidbodyOfTransform = rbTransform;
            _mainColliderOfTransform = colliderMain;

            _subCollider = ragDollParent.GetComponentsInChildren<Collider>(true);
            _subRigidbody = ragDollParent.GetComponentsInChildren<Rigidbody>(true);

            WholeBodyRagDoll(false);
        }

        private void WholeBodyRagDoll(bool ragDollState)
        {
            foreach (var col in _subCollider) col.enabled = ragDollState;

            foreach (var npcRb in _subRigidbody) npcRb.isKinematic = !ragDollState;

            _rigidbodyOfTransform.isKinematic = ragDollState; // main rigidbody on player

            _mainColliderOfTransform.enabled = !ragDollState; // main collider on player
            _animatorOfTransform.enabled = !ragDollState; //
        }

        public void AddForceToRagDoll()
        {
            foreach (var npcRb in _subRigidbody) npcRb.AddForce(new Vector3(0, .1f, 1) * 50, ForceMode.Impulse);
        }
    }
}
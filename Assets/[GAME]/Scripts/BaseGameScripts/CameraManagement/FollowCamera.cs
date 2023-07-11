using DG.Tweening;
using UnityEngine;

namespace Scripts.BaseGameScripts.CameraManagement
{
    public class FollowCamera : MonoBehaviour
    {
        public enum HorizontalFollow
        {
            None,
            Instant,
            Gradually
        }


        [Header("Camera")]
        private Camera cam;

        [Header("Follow Settings")]
        /*[HideInInspector]*/
        public bool follow;

        public float horizontalClampVal;
        public float horizontalFollowLerpMult;

        [Header("Horizonral Follow")]
        public HorizontalFollow horizontalFollowType;


        private Vector3 newPos = Vector3.zero;

        [HideInInspector]
        public Vector3 offset;

        [SerializeField]
        private float speed = 3f;

        [Header("Follow Method Variables")]
        [SerializeField]
        private Rigidbody target;

        private float temporaryXVal;
        private Vector3 vel = Vector3.zero;

        private void Awake()
        {
            follow = true;
            OffsetCalculate();
            cam = GetComponent<Camera>();
            newPos.x = transform.position.x;
        }

        private void LateUpdate()
        {
            if (follow) FollowMethod();
        }

        private void FollowMethod()
        {
            if (target) //for safety
            {
                NewPosCalculator();
                transform.position = Vector3.SmoothDamp(transform.position, newPos, ref vel, speed);
            }
        }

        private Vector3 NewPosCalculator()
        {
            NewPosX();
            newPos.y = target.position.y + offset.y;
            newPos.z = target.position.z + offset.z;
            return newPos;
        }

        private float NewPosX()
        {
            switch (horizontalFollowType)
            {
                case HorizontalFollow.None:
                    return newPos.x;

                case HorizontalFollow.Instant:
                    newPos.x = target.position.x + offset.x;
                    return newPos.x;

                case HorizontalFollow.Gradually:
                    newPos.x = target.position.x + offset.x;
                    newPos.x = Mathf.Clamp(newPos.x, -horizontalClampVal, horizontalClampVal);
                    temporaryXVal = Mathf.Lerp(transform.position.x, newPos.x, horizontalFollowLerpMult * Time.deltaTime);
                    newPos.x = temporaryXVal;
                    return newPos.x;
            }

            Debug.Log(true);
            return newPos.x;
        }

        public Vector3 OffsetCalculate()
        {
            offset = transform.position - target.position;
            newPos.y = target.position.y + offset.y;
            //Debug.Log("OFFSET :::: " + newPos);
            return offset;
        }

        public void CameraShake()
        {
            //cam.DOShakePosition(.1f, .2f).SetId(1);
            cam.DOShakeRotation(.1f, 3.5f, 100).SetEase(Ease.Linear).SetId(2);
        }

        public void ReTarget(Transform desiredObj)
        {
            target = desiredObj.GetComponent<Rigidbody>();
            OffsetCalculate();
        }
    }
}
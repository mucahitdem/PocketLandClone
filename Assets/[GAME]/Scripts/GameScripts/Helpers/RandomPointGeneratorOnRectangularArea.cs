using System;
using Scripts.BaseGameScripts.Component;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Scripts.GameScripts.Helpers
{
    public class RandomPointGeneratorOnRectangularArea : BaseComponent
    {
        public Func<Vector3> getRandomPos;

        [SerializeField]
        private float horizontalLength;
        
        [SerializeField]
        private float verticalLength;

        [SerializeField]
        private Color gizmosColor;
        

        private Vector3 centerPoint;
        private float halfVerticalLength;
        private float halfHorizontalLength;
        
        private void Awake()
        {
            centerPoint = TransformOfObj.position;
            halfVerticalLength = verticalLength / 2f;
            halfHorizontalLength = horizontalLength / 2f;
        }

        protected override void SubscribeEvent()
        {
            base.SubscribeEvent();
            getRandomPos += GetRandomPos;
        }

        protected override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            getRandomPos -= GetRandomPos;
        }
        

        private Vector3 GetRandomPos()
        {
            return new Vector3(centerPoint.x + Random.Range(-halfHorizontalLength, halfHorizontalLength), 
                                    0, 
                                        centerPoint.z + Random.Range(-halfVerticalLength, halfVerticalLength));
        }


        private void OnDrawGizmos()
        {
            Gizmos.color = gizmosColor;
            Gizmos.DrawCube(TransformOfObj.position, new Vector3(horizontalLength,0, verticalLength));
        }
    }
}
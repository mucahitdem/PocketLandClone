using System;
using Scripts.BaseGameScripts.Component;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Scripts.GameScripts.Helpers.RectangularAreaManagement
{
    [RequireComponent(typeof(RectangularAreaVisualizer))]
    public class RandomPointGeneratorOnRectangularArea : BaseComponent
    {
        public Func<Vector3> getRandomPos;

        [SerializeField]
        private RectangularAreaData rectangularAreaData;

        private RectangularAreaVisualizer rectangularAreaVisualizer;
        
        private Vector3 centerPoint;
        private float halfVerticalLength;
        private float halfHorizontalLength;

        private void OnValidate()
        {
            if(!rectangularAreaVisualizer)
                rectangularAreaVisualizer = GetComponent<RectangularAreaVisualizer>();
            rectangularAreaVisualizer.InsertData(rectangularAreaData);
        }

        private void Awake()
        {
            centerPoint = TransformOfObj.position;
            halfVerticalLength = rectangularAreaData.verticalLength / 2f;
            halfHorizontalLength = rectangularAreaData.horizontalLength / 2f;
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
    }
}
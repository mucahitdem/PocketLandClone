using System;
using Scripts.BaseGameScripts.Component;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Scripts.GameScripts.Helpers.RectangularAreaManagement
{
    [RequireComponent(typeof(RectangularAreaVisualizer))]
    public class RandomPointGeneratorOnRectangularArea : BaseComponent
    {
        private Vector3 centerPoint;
        public Func<Vector3> getRandomPos;
        private float halfHorizontalLength;
        private float halfVerticalLength;

        [SerializeField]
        private RectangularAreaData rectangularAreaData;

        private RectangularAreaVisualizer rectangularAreaVisualizer;

        private void OnValidate()
        {
            if (!rectangularAreaVisualizer)
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
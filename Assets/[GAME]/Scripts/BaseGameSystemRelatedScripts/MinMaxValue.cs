using System;
using Random = UnityEngine.Random;

namespace Scripts.BaseGameSystemRelatedScripts
{
    [Serializable]
    public class MinMaxValue
    {
        private float _rangeBetweenMaxAndMin;
        public float minVal;
        public float maxVal;

        public MinMaxValue(float minVal, float maxVal)
        {
            this.minVal = minVal;
            this.maxVal = maxVal;
        }
        
        public float RangeBetweenMaxAndMin
        {
            get
            {
                if (_rangeBetweenMaxAndMin <= 0)
                    _rangeBetweenMaxAndMin = maxVal - minVal;

                return _rangeBetweenMaxAndMin;
            }

            set => _rangeBetweenMaxAndMin = value;
        }

        public float Difference()
        {
            return maxVal - minVal;
        }

        public int RandomInt()
        {
            return (int)Random.Range(minVal, maxVal);
        }
        
        public float RandomFloat()
        {
            return Random.Range(minVal, maxVal);
        }
    }
}
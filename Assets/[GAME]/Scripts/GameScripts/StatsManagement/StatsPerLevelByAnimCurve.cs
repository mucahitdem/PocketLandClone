using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.GameScripts.StatsManagement
{
    [Serializable]
    public class StatsPerLevelByAnimCurve
    {
        public AnimationCurve statPerLevel;

        [ShowInInspector]
        [ReadOnly]
        private int Level { get; set; }

        [ShowInInspector]
        [ReadOnly]
        private float Stat { get; set; }


        [Button]
        private void ShowLevelValues(int desiredLevel)
        {
            Level = desiredLevel;
            Stat = statPerLevel.Evaluate(Level);
        }

        public void UpdateValues()
        {
            Stat = statPerLevel.Evaluate(Level);
        }

        public float GetStatWithLevel(int level)
        {
            Level = level;
            Stat = statPerLevel.Evaluate(Level);

            return Stat;
        }
    }
}
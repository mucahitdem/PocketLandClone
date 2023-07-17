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
        private int Level { get; set; }

        [ShowInInspector]
        private float Stat { get; set; }


        // [Button]
        // private void ShowLevelValues(int desiredLevel)
        // {
        //     _level = desiredLevel;
        //     _stat = statPerLevel.Evaluate(_level);
        // }

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
using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.GameScripts.StatsManagement
{
    [Serializable]
    public class StatsPerLevel
    {
        public AnimationCurve statPerLevel;

        [ShowInInspector]
        private int Level => _level;
        [ShowInInspector]
        private float Stat => _stat;


        private int _level;
        private float _stat;
        
        
        
        // [Button]
        // private void ShowLevelValues(int desiredLevel)
        // {
        //     _level = desiredLevel;
        //     _stat = statPerLevel.Evaluate(_level);
        // }
        
        public void UpdateValues()
        {
            _stat = statPerLevel.Evaluate(_level);
        }
        
        public float GetStatWithLevel(int level)
        {
            _level = level;
            _stat = statPerLevel.Evaluate(_level);

            return _stat;
        }
    }
}
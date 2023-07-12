using System;
using System.Collections;
using System.Collections.Generic;
using Scripts.BaseGameScripts.Helper;
using Scripts.BaseGameScripts.SaveAndLoad;
using UnityEngine;

namespace Scripts.GameScripts.StatsManagement.PlayerStatsManagement
{
    public class PlayerStatsManager : BaseStatsManager
    {
        public Action<float, float> onXpValueChange;
        public Action<int> onLevelChanged;

        private PlayerStatsDataSo _playerStatsDataSo;
        
        public int Level { get; private set; }
        private float Xp { get; set; }

        private float _totalRequiredXp;
        private float _xpPercentage;

        protected void Awake()
        {
            _playerStatsDataSo = (PlayerStatsDataSo) baseStatsDataSo;
            CalculateRequiredXp();
        }

        private IEnumerator Start()
        {
            yield return null;
            CollectXp(0);
            onLevelChanged?.Invoke(Level);
        }
        public void CollectXp(float xpAmountToCollect)
        {
            Xp += xpAmountToCollect;
            DebugHelper.LogRed("TOTAL XP : " + Xp);

            if (Xp >= _totalRequiredXp)
            {
                Xp -= _totalRequiredXp;
                CalculateRequiredXp();
                LevelUp();
            }
            
            CalculateXpPercentage();
            onXpValueChange?.Invoke(Xp, _xpPercentage);
        }
        private void CalculateXpPercentage()
        {
            _xpPercentage = Xp / _totalRequiredXp;
        }
        private void CalculateRequiredXp()
        {
            _totalRequiredXp = _playerStatsDataSo.playerStatsData.requiredXpForLevelByAnimCurve.GetStatWithLevel(Level);
        }
        private void LevelUp()
        {
            Level++;
            onLevelChanged?.Invoke(Level);
        }
    }
}
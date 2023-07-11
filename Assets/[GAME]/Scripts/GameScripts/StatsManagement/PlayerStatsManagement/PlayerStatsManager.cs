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
        public Action<float, float> onManaValueChanged;

        private PlayerStatsDataSo _playerStatsDataSo;
        
        private float CurrentMana { get; set; }
        private int Level { get; set; }
        private float Xp { get; set; }

        private float _mana;
        private float _manaPercentage;

        private float _initialManaIncreaseSpeed;
        private float _currentManaIncreaseSpeed;
        private float _nextLevelXpValue;
        
        private float _healthIncreaseSpeed;
        private float _currentHealthIncreaseSpeed;

        private float _totalRequiredXp;
        private float _xpPercentage;

        protected override void Awake()
        {
            base.Awake();
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
            _totalRequiredXp = _playerStatsDataSo.playerStatsData.requiredXpForLevel.GetStatWithLevel(Level);
        }
        private void LevelUp()
        {
            Level++;
            onLevelChanged?.Invoke(Level);
        }
    }
}
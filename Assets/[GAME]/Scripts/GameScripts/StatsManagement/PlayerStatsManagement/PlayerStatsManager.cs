using System;
using System.Collections;
using Scripts.BaseGameScripts.Helper;
using UnityEngine;

namespace Scripts.GameScripts.StatsManagement.PlayerStatsManagement
{
    public class PlayerStatsManager : BaseStatsManager
    {
        private PlayerStatsDataSo _playerStatsDataSo;

        private float _totalRequiredXp;
        private float _xpPercentage;
        public Action<int> onLevelChanged;
        public Action<float, float> onXpValueChange;

        public int Level { get; private set; }
        private float Xp { get; set; }

        protected void Awake()
        {
            _playerStatsDataSo = (PlayerStatsDataSo) baseStatsDataSo;
            CalculateRequiredXp();
        }

        private IEnumerator Start()
        {
            yield return new WaitForEndOfFrame();
            Level = 1;
            GainXp(0);
            onLevelChanged?.Invoke(Level);
        }

        protected override void SubscribeEvent()
        {
            base.SubscribeEvent();
            StatsActionManager.onGainedXp += GainXp;
        }

        protected override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            StatsActionManager.onGainedXp -= GainXp;
        }

        private void GainXp(float xpAmountToCollect)
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
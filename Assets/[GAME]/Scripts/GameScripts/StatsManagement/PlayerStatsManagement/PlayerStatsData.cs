using System;
using Sirenix.OdinInspector;

namespace Scripts.GameScripts.StatsManagement.PlayerStatsManagement
{
    [Serializable]
    public class PlayerStatsData : BaseStatsData
    {
        public StatsPerLevelByAnimCurve requiredXpForLevelByAnimCurve;

        [Button]
        public void UpdateAllData()
        {
            requiredXpForLevelByAnimCurve.UpdateValues();
        }
    }
}
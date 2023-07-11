using System;
using Sirenix.OdinInspector;

namespace Scripts.GameScripts.StatsManagement.PlayerStatsManagement
{
    [Serializable]
    public class PlayerStatsData : BaseStatsData
    {
        public StatsPerLevel requiredXpForLevel;

        [Button]
        public void UpdateAllData()
        {
            requiredXpForLevel.UpdateValues();
        }
    }
}
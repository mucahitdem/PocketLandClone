using Scripts.GameScripts.SourceManagement;
using UnityEngine;

namespace Scripts.BaseGameScripts.SourceManagement.SourceTypes
{
    [CreateAssetMenu(fileName = "ClampedSourceIncreaseViaRealTimeData", menuName = "BaseGame/Sources/ClampedSourceIncreaseViaRealTimeData", order = 0)]
    public class RenewableClampedSourceDataSo : BaseSourceDataSo
    {
        public RenewableClampedSourceData data;
    }
}
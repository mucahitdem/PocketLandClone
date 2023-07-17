using Scripts.BaseGameScripts.Component;
using UnityEngine;

namespace Scripts.GameScripts.FindTargetsInAreaManagement
{
    public class FindTargetInAreaVisualizer : BaseComponent
    {
        private FindTargetsInAreaData _findTargetsInAreaData;

        [SerializeField]
        private Color gizmosColor = Color.red;

        public void LoadNewData(FindTargetsInAreaData findTargetsInAreaData)
        {
            _findTargetsInAreaData = findTargetsInAreaData;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = gizmosColor;
            Gizmos.DrawWireSphere(_findTargetsInAreaData.castPos.position, _findTargetsInAreaData.radius);
        }
    }
}
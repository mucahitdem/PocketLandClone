using System;
using Scripts.BaseGameScripts.Component;
using Scripts.BaseGameScripts.Helper;
using UnityEngine;

namespace Scripts.GameScripts.FindTargetsInAreaManagement
{
    public class FindTargetInAreaVisualizer : BaseComponent
    {
        [SerializeField]
        private Color gizmosColor = Color.red;
        
        private FindTargetsInAreaData _findTargetsInAreaData;

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
using System;
using Scripts.BaseGameScripts.Helper;
using UnityEngine;

namespace Scripts.GameScripts.FindTargetsInAreaManagement
{
    public class FindTargetsInArea
    {
        public FindTargetsInAreaData FindTargetsInAreaData => _findTargetsInAreaData;
        
        private readonly FindTargetsInAreaData _findTargetsInAreaData;

        private Collider[] _cols;

        public FindTargetsInArea(FindTargetsInAreaData findTargetsInAreaData)
        {
            _findTargetsInAreaData = findTargetsInAreaData;
            _cols = new Collider[findTargetsInAreaData.maxTargetCount];
        }

        public void Scan(Action<Collider> actionToDo)
        {
            var size = Physics.OverlapSphereNonAlloc(_findTargetsInAreaData.castPos.position, 
                _findTargetsInAreaData.radius,
                _cols, 
                _findTargetsInAreaData.layerMask);
            
            if(size <= 0)
                return;
            
            for (int i = 0; i < size; i++)
            {
                var currentCol = _cols[i];
                actionToDo?.Invoke(currentCol);
            }
        }
    }
}
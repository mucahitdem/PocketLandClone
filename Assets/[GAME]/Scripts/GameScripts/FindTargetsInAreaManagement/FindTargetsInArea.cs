using System;
using UnityEngine;

namespace Scripts.GameScripts.FindTargetsInAreaManagement
{
    public class FindTargetsInArea
    {
        private readonly Collider[] _cols;

        public FindTargetsInArea(FindTargetsInAreaData findTargetsInAreaData)
        {
            FindTargetsInAreaData = findTargetsInAreaData;
            _cols = new Collider[findTargetsInAreaData.maxTargetCount];
        }

        public FindTargetsInAreaData FindTargetsInAreaData { get; }

        public void Scan(Action<Collider> actionToDo)
        {
            var size = Physics.OverlapSphereNonAlloc(FindTargetsInAreaData.castPos.position,
                FindTargetsInAreaData.radius,
                _cols,
                FindTargetsInAreaData.layerMask);

            if (size <= 0)
                return;

            for (var i = 0; i < size; i++)
            {
                var currentCol = _cols[i];
                actionToDo?.Invoke(currentCol);
            }
        }
    }
}
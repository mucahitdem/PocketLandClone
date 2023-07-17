using System;
using UnityEngine;

namespace Scripts.GameScripts.FindTargetsInAreaManagement
{
    [Serializable]
    public class FindTargetsInAreaData
    {
        public Transform castPos;
        public LayerMask layerMask;
        public int maxTargetCount;
        public float radius;
    }
}
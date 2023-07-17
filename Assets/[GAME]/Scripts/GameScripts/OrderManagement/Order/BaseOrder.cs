using System;
using UnityEngine;

namespace Scripts.GameScripts.OrderManagement.Order
{
    [Serializable]
    public class BaseOrder
    {
        [SerializeField]
        private BaseOrderData baseOrderData;

        [HideInInspector]
        public string name;

        public BaseOrder(BaseOrderData baseOrderData)
        {
            this.baseOrderData = baseOrderData;
        }

        public virtual BaseOrderData BaseOrderData => baseOrderData;
    }
}
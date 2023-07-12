using System;
using UnityEngine;

namespace Scripts.GameScripts.OrderManagement.Order
{
    [Serializable]
    public class BaseOrder 
    {
        [HideInInspector]
        public string name;
        
        public virtual BaseOrderData BaseOrderData => baseOrderData;
        
        [SerializeField]
        private BaseOrderData baseOrderData;

        public BaseOrder(BaseOrderData baseOrderData)
        {
            this.baseOrderData = baseOrderData;
        }
    }
}
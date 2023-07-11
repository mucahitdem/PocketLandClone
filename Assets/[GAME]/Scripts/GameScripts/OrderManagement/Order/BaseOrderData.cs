using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;

namespace Scripts.GameScripts.OrderManagement.Order
{
    [Serializable]
    public class BaseOrderData
    {
        public List<OrderTypeAndCount> itemsAndCount = new List<OrderTypeAndCount>();
        
        [ReadOnly]
        public int price;
    }
}
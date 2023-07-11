using System;
using Scripts.GameScripts.OrderManagement.Order;

namespace Scripts.GameScripts.OrderManagement
{
    [Serializable]
    public class AllOrders
    {
        public BaseOrder[] orders;
    }
}
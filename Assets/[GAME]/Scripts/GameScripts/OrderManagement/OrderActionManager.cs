using System;
using Scripts.GameScripts.OrderManagement.Order;

namespace Scripts.GameScripts.OrderManagement
{
    public static class OrderActionManager
    {
        public static Action<BaseOrder> onOrderDelivered;
        public static Action<BaseOrder> onNewOrderCreated;
    }
}
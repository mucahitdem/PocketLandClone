using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.BaseGameScripts.SourceManagement;
using Scripts.GameScripts.OrderManagement.Order;
using Scripts.GameScripts.OrderManagement.OrderCreatorManagement;
using Scripts.GameScripts.SourceManagement;
using Scripts.GameScripts.StatsManagement;
using UnityEngine;

namespace Scripts.GameScripts.OrderManagement
{
    public class OrderManager : BaseComponent
    {
        [SerializeField]
        private BaseOrderCreator orderCreator;

        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            OrderActionManager.onOrderDelivered += OnOrderDelivered;
        }

        public override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            OrderActionManager.onOrderDelivered -= OnOrderDelivered;
        }

        private void OnOrderDelivered(BaseOrder baseOrder)
        {
            StatsActionManager.onGainedXp?.Invoke(baseOrder.BaseOrderData.xp);
            SourceActionManager.addSource(baseOrder.BaseOrderData.price, baseOrder.BaseOrderData.sourceToEarn);

            orderCreator.CreateNewOrder();
        }
    }
}
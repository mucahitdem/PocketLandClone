using Scripts.BaseGameScripts.CoinControl;
using Scripts.BaseGameScripts.ComponentManager;
using Scripts.GameScripts.OrderManagement.Order;
using Scripts.GameScripts.OrderManagement.OrderCreatorManagement;
using Scripts.GameScripts.StatsManagement;
using UnityEngine;

namespace Scripts.GameScripts.OrderManagement
{
    public class OrderManager : BaseComponent
    {
        [SerializeField]
        private BaseOrderCreator orderCreator;

        protected override void SubscribeEvent()
        {
            base.SubscribeEvent();
            OrderActionManager.onOrderDelivered += OnOrderDelivered;
        }

        protected override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            OrderActionManager.onOrderDelivered -= OnOrderDelivered;
        }

        private void OnOrderDelivered(BaseOrder baseOrder)
        {
            StatsActionManager.onGainedXp?.Invoke(baseOrder.BaseOrderData.xp);
            CoinManager.Instance.AddCoin(baseOrder.BaseOrderData.price);

            orderCreator.CreateNewOrder();
        }
    }
}
using Scripts.BaseGameScripts.CoinControl;
using Scripts.BaseGameScripts.Component;
using Scripts.GameScripts.OrderManagement.Order;
using Scripts.GameScripts.OrderManagement.OrderCreatorManagement;
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
            CoinManager.Instance.AddCoin(baseOrder.BaseOrderData.price);
            orderCreator.CreateNewOrder();
        }
    }
}
using Scripts.BaseGameScripts.Component;
using Scripts.GameScripts.ItemManagement;
using Scripts.GameScripts.OrderManagement.Order;
using UnityEngine;

namespace Scripts.GameScripts.OrderManagement
{
    public class OrderCreationManager : BaseComponent
    {
        [SerializeField]
        private BaseItemDataSo[] items;

        [SerializeField]
        private AllOrdersDataSo allOrdersDataSo;

        protected override void SubscribeEvent()
        {
            base.SubscribeEvent();
        }

        protected override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            OrderActionManager.onOrderDelivered -= OnOrderDelivered;
        }

        private void OnOrderDelivered(BaseOrderData baseOrder)
        {
            //CoinManager.Instance.AddCoin(order);
        }
    }
}
using Scripts.GameScripts.ItemManagement.ItemTypes.HarvestableItems;
using Scripts.GameScripts.OrderManagement.Order;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.GameScripts.OrderManagement
{
    [CreateAssetMenu(fileName = "Orders", menuName = "Game/Order/AllOrders", order = 0)]
    public class AllOrdersDataSo : ScriptableObject
    {
        #region StaticSO

        [ShowInInspector]
        [DisableInEditorMode]
        [LabelText("Static Reference")]
        [InlineButton("FindHolesDataAsset")]
        private static AllOrdersDataSo s_mUpgradeData;

        public static AllOrdersDataSo UpgradesData => s_mUpgradeData ??= Resources.Load<AllOrdersDataSo>("AllOrdersData");

        private void FindHolesDataAsset()
        {
            if (UpgradesData) 
                return;
            Debug.LogError("Order data asset is missing in the resources folder.");
        }

        #endregion

        public AllOrders allOrders;

        private void OnValidate()
        {
            UpdateElementNames();
            UpdatePrices();
        }

        private void UpdatePrices()
        {
            for (int i = 0; i < allOrders.orders.Length; i++)
            {
                int price = 0;
                BaseOrderData currentOrder = allOrders.orders[i].BaseOrderData;
                
                
                for (int j = 0; j < currentOrder.itemsAndCount.Count; j++)
                {
                    OrderTypeAndCount currentOrderItemAndCount = currentOrder.itemsAndCount[j];
                    price = ((ItemToHarvestDataSo)currentOrderItemAndCount.itemDataSo).itemToHarvestData.itemPrice;
                    price *= currentOrderItemAndCount.itemAmount;
                }

                currentOrder.price = price;
            }
        }

        private void UpdateElementNames()
        {
            for (int i = 0; i < allOrders.orders.Length; i++)
            {
                allOrders.orders[i].name = "Order" + i;
            }
        }
    }
}
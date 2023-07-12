using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;

namespace Scripts.GameScripts.OrderManagement.Order
{
    [Serializable]
    public class BaseOrderData
    {
        public List<ItemTypeAndCount> itemsAndCount;
        
        [ReadOnly]
        public int price;

        public BaseOrderData(List<ItemTypeAndCount> itemsAndCount)
        {
            this.itemsAndCount = itemsAndCount;
            CalculatePrice();
        }

        private void CalculatePrice()
        {
            int calculatedPrice = 0;
            for (int i = 0; i < itemsAndCount.Count; i++)
            {
                var currentItemAndCount = itemsAndCount[i];
                
                var currentItemCount = currentItemAndCount.itemAmount;
                var currentItemData = currentItemAndCount.item.baseItemData;
                
                var currentItemPrice = currentItemData.itemPrice;
                var currentItemLaborPrice = currentItemData.itemLaborPrice;

                calculatedPrice += (currentItemPrice + currentItemLaborPrice) * currentItemCount;

            }
        }
    }
}
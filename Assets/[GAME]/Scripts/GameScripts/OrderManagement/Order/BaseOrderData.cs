using System;
using System.Collections.Generic;
using Scripts.BaseGameScripts.SourceManagement;
using Sirenix.OdinInspector;

namespace Scripts.GameScripts.OrderManagement.Order
{
    [Serializable]
    public class BaseOrderData
    {
        public List<ItemTypeAndCount> itemsAndCount = new List<ItemTypeAndCount>();
        
        public BaseSourceDataSo sourceToEarn;

        [ReadOnly]
        public int price;

        [ReadOnly]
        public float xp;
        
        
        private int calculatedPrice;
        private float calculatedXp;

        public BaseOrderData(List<ItemTypeAndCount> newItemsAndCount, BaseSourceDataSo sourceToEarn)
        {
            this.sourceToEarn = sourceToEarn;
            itemsAndCount = newItemsAndCount;
            CalculatePriceAndXp();
        }

        private void CalculatePriceAndXp()
        {
            calculatedPrice = 0;
            calculatedXp = 0f;
            for (var i = 0; i < itemsAndCount.Count; i++)
            {
                var currentItemAndCount = itemsAndCount[i];

                var currentItemCount = currentItemAndCount.itemAmount;
                var currentItemData = currentItemAndCount.itemDataSo.baseItemData;

                var currentItemPrice = currentItemData.itemPrice;
                var currentItemLaborPrice = currentItemData.itemLaborPrice;

                var currentItemXp = currentItemData.xpValue;

                calculatedPrice += (currentItemPrice + currentItemLaborPrice) * currentItemCount;
                calculatedXp += currentItemXp * currentItemCount;
            }

            price = calculatedPrice;
            xp = calculatedXp;
        }
    }
}
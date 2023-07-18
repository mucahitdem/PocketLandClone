using System;
using System.Collections.Generic;
using System.Linq;
using Scripts.BaseGameScripts.Helper;
using Sirenix.OdinInspector;

namespace Scripts.GameScripts.OrderManagement.Order
{
    [Serializable]
    public class BaseOrderData
    {
        public List<ItemTypeAndCount> itemsAndCount = new List<ItemTypeAndCount>();

        [ReadOnly]
        public int price;

        [ReadOnly]
        public float xp;
        
        
        private int calculatedPrice;
        private float calculatedXp;

        public BaseOrderData(List<ItemTypeAndCount> newItemsAndCount)
        {
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
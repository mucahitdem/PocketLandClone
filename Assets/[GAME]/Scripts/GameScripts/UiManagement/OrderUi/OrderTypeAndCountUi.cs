﻿using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.BaseGameScripts.Pool;
using Scripts.GameScripts.OrderManagement.Order;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.GameScripts.UiManagement.OrderUi
{
    public class OrderTypeAndCountUi : BaseComponent
    {
        public ItemTypeAndCount ItemTypeAndCount { get; private set; }

        public BasePoolItem Pool => pool;
        
        [SerializeField]
        private BasePoolItem pool;
            
        [SerializeField]
        private Image orderImage;

        [SerializeField]
        private TextMeshProUGUI orderCountText;

        private int orderedCount;
        private int currentItemCount;
        
        public void InsertData(ItemTypeAndCount typeAndCount)
        {
            ItemTypeAndCount = typeAndCount;
            var data = typeAndCount.itemDataSo.baseItemData;
            orderImage.sprite = data.itemIcon;

            orderedCount = typeAndCount.itemAmount;
            //var itemCount =  InventoryActionManager.currentItemCount.Invoke(typeAndCount.itemDataSo);
            currentItemCount = 0;
            UpdateItemCountText();
        }
        public void UpdateItemCount(int newItemCount)
        {
            currentItemCount = newItemCount;
            UpdateItemCountText();
        }
        public bool IsOrderCompleted()
        {
            return currentItemCount >= orderedCount;
        }
        
        private void UpdateItemCountText()
        {
            orderCountText.text = currentItemCount + "/" + orderedCount;
        }
    }
}
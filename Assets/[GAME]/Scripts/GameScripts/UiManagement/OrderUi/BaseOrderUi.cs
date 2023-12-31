﻿using System.Collections.Generic;
using System.Linq;
using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.BaseGameScripts.Pool;
using Scripts.GameScripts.InventoryManagement;
using Scripts.GameScripts.ItemManagement;
using Scripts.GameScripts.OrderManagement;
using Scripts.GameScripts.OrderManagement.Order;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.GameScripts.UiManagement.OrderUi
{
    public class BaseOrderUi : BaseComponent
    {
        public BasePoolItem Pool => pool;
        
        [SerializeField]
        private BasePoolItem pool;
        
        [SerializeField]
        private Image customerIcon;

        [SerializeField]
        private TextMeshProUGUI priceText;

        [SerializeField]
        private RectTransform itemsParent;

        [SerializeField]
        private Image bg;

        [SerializeField]
        private ConfirmOrderButton confirmOrderButton;
        

        private Dictionary<BaseItemDataSo,OrderTypeAndCountUi> itemsInOrderAndDatas = new Dictionary<BaseItemDataSo, OrderTypeAndCountUi>();
        private OrderTypeAndCountUi orderUi;
        private BaseOrder baseOrder;

        protected override void OnDisable()
        {
            base.OnDisable();
            itemsInOrderAndDatas.Clear();
            confirmOrderButton.isInteractable = false;
        }

        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            InventoryActionManager.onItemCountUpdated += OnItemCountUpdated;
            confirmOrderButton.onClicked += OnClickedConfirmOrderButton;
        }
        public override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            InventoryActionManager.onItemCountUpdated -= OnItemCountUpdated;
            confirmOrderButton.onClicked -= OnClickedConfirmOrderButton;
            bg.color = Color.blue; // todo fix hard coded
        }
        
        
        public void InsertData(BaseOrder order, Sprite customerSprite, OrderTypeAndCountUi[] itemsAndCounts)
        {
            baseOrder = order;
            customerIcon.sprite = customerSprite;
            priceText.text = order.BaseOrderData.price.ToString();

            for (int i = 0; i < itemsAndCounts.Length; i++)
            {
                var currentItem = itemsAndCounts[i];
                currentItem.RectTransformObj.SetParent(itemsParent);
                itemsInOrderAndDatas.Add(currentItem.ItemTypeAndCount.itemDataSo, currentItem);
            }
            
            UpdateData();
        }


        private void UpdateData()
        {
            var data = InventoryActionManager.getItemsAndCount?.Invoke();
            if(data == null)
                return;
            for (int i = 0; i < data.Count; i++)
            {
                var currentData = data.ElementAt(i);
                var currentElement = currentData.Key;
                var currentCount = currentData.Value;
                OnItemCountUpdated(currentElement, currentCount);
            }
        }
        private void OnClickedConfirmOrderButton()
        {
            for (int i = 0; i < itemsInOrderAndDatas.Count; i++)
            {
                var elementAtIndex = itemsInOrderAndDatas.ElementAt(i);
                var itemData = elementAtIndex.Key;
                var ui = elementAtIndex.Value;
                var amount = ui.ItemTypeAndCount.itemAmount;
                ui.Pool.AddObjToPool(ui);
                InventoryActionManager.useItem.Invoke(itemData,amount);
            }
            
            TransformOfObj.SetParent(null);
            OrderActionManager.onOrderDelivered?.Invoke(baseOrder);
            //gameObject.SetActive(false);
            itemsInOrderAndDatas.Clear();
            Pool.AddObjToPool(this);
        }
        private void OnItemCountUpdated(BaseItemDataSo updatedItemDataSo, int newCurrentItemCount)
        {
            if (itemsInOrderAndDatas.TryGetValue(updatedItemDataSo, out orderUi))
            {
                orderUi.UpdateItemCount(newCurrentItemCount);
            }

            var ordersCompleted = AreAllOrdersCompleted();
            bg.color = ordersCompleted ? Color.green : Color.blue; // todo fix hard coded
            confirmOrderButton.isInteractable = ordersCompleted;
        }
        private bool AreAllOrdersCompleted()
        {
            for (int i = 0; i < itemsInOrderAndDatas.Count; i++)
            {
                var elementAtIndex = itemsInOrderAndDatas.ElementAt(i);
                if (!elementAtIndex.Value.IsOrderCompleted())
                    return false;
            }

            return true;
        }
    }
}
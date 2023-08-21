using System.Collections;
using System.Collections.Generic;
using Scripts.BaseGameScripts.ComponentManager;
using Scripts.BaseGameScripts.Helper;
using Scripts.GameScripts.OrderManagement;
using Scripts.GameScripts.OrderManagement.Order;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.GameScripts.UiManagement.UiGridManagement
{
    public class UiGridManager : BaseComponent
    {
        [SerializeField]
        private UiGridElement[] gridElements;
        
        private Queue<RectTransform> orderQueue = new Queue<RectTransform>();
        private bool isInProcess;
        private bool isReOrdering;

        [Title("Temp Variables")]
        private int fullGridCount;
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

        private void Update()
        {
            if (!isInProcess && !isReOrdering && orderQueue.Count > 0)
            {
                OrderImages();
            }
        }

        public void AddItemToQueue(RectTransform orderUi)
        {
            orderQueue.Enqueue(orderUi);
        }

        private void OnOrderDelivered(BaseOrder obj)
        {
            StartCoroutine(ReOrderAllItems());
        }
        private IEnumerator ReOrderAllItems()
        {
            isReOrdering = true;
            fullGridCount = GetFullGridCount();
            for (int i = 0; i < gridElements.Length; i++)
            {
                var currentGrid = gridElements[i];
                if (!currentGrid.IsFull())
                {
                    var nearestElement = GetNearestElement(i++);
                    if (!nearestElement)
                    {
                        DebugHelper.LogRed("NULL");
                        isReOrdering = false;
                        break;
                    }
                    
                    currentGrid.SetItem(nearestElement, null);
                    yield return new WaitForSeconds(.5f);
                }
            }
            
            if(IsReOrderEnded())
                isReOrdering = false;
            else
                StartCoroutine(ReOrderAllItems());

            yield return null;
        }


        private int GetFullGridCount()
        { 
            fullGridCount = 0;
            for (int i = 0; i < gridElements.Length; i++)
            {
                var currentGrid = gridElements[i];
                if (currentGrid.IsFull())
                {
                    fullGridCount++;
                }
            }
            
            return fullGridCount;
        }

        private bool IsReOrderEnded()
        {
            for (int i = 0; i < gridElements.Length; i++)
            {
                var currentGrid = gridElements[i];
                if (!currentGrid.IsFull() && currentGrid.gridIndex < fullGridCount)
                {
                    return false;
                }
            }

            return true;
        }

        private RectTransform GetNearestElement(int startSearchAtIndex)
        {
            for (int i = startSearchAtIndex; i < gridElements.Length; i++)
            {
                var currentElement = gridElements[i];
                if (currentElement.IsFull())
                {
                    return currentElement.ObjInIt;
                }
            }

            return null;
        }
        
        private void OrderImages()
        {
            isInProcess = true;
            var item = orderQueue.Dequeue();
            var uiElement = GetEmptyElement();
            uiElement.SetItem(item,()=>
            {
                isInProcess = false;
            });
        }

        private UiGridElement GetEmptyElement()
        {
            for (int i = 0; i < gridElements.Length; i++)
            {
                var currentElement = gridElements[i];
                if (!currentElement.IsFull())
                    return currentElement;
            }

            return null;
        }
    }
}
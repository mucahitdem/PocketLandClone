using System;
using Scripts.BaseGameScripts.ComponentManager;
using Scripts.BaseGameScripts.Helper;
using Scripts.GameScripts.OrderManagement;
using Scripts.GameScripts.OrderManagement.Order;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.GameScripts.UiManagement.OrderUi
{
    public class OrderUiCreator : BaseComponent
    {
        public Action<BaseOrderUi> onOrderUiCreated;
        
        [PreviewField(ObjectFieldAlignment.Left)]
        public Sprite[] customerFaces;

        [SerializeField]
        private OrderTypeAndCountUi orderTypeAndCountUi;

        [SerializeField]
        private BaseOrderUi orderUi;

        [SerializeField]
        private RectTransform createPos;

        [SerializeField]
        private Transform orderParentUiObj;

        private int customerFaceIndex;

        private void Awake()
        {
            customerFaceIndex = 0;
        }

        protected override void SubscribeEvent()
        {
            base.SubscribeEvent();
            OrderActionManager.onNewOrderCreated += OnNewOrderCreated;
        }

        protected override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            OrderActionManager.onNewOrderCreated -= OnNewOrderCreated;
        }

        private void OnNewOrderCreated(BaseOrder order)
        {
            CreateBaseOrderUi(order);
        }

        private void CreateBaseOrderUi(BaseOrder order)
        {
            var createdObj = Instantiate(orderUi, orderParentUiObj, true); // pool eklenecek
            createdObj.RectTransformObj.anchoredPosition = createPos.position;
            createdObj.InsertData(order, GetCustomerFaceSprite(), CreateItemAndCount(order));
            onOrderUiCreated?.Invoke(createdObj);
            IncreaseCutomerFaceIndex();
        }

        private Sprite GetCustomerFaceSprite()
        {
            return customerFaces[customerFaceIndex];
        }

        private void IncreaseCutomerFaceIndex()
        {
            customerFaceIndex++;
            if (customerFaceIndex >= customerFaces.Length)
            {
                customerFaceIndex = 0;
            }
        }

        private OrderTypeAndCountUi[] CreateItemAndCount(BaseOrder order)
        {
            var itemsAndCounts = order.BaseOrderData.itemsAndCount;
            int orderCount = itemsAndCounts.Count;

            var rectArray = new OrderTypeAndCountUi[orderCount];
            for (int i = 0; i < orderCount; i++)
            {
                var currentItemAndCount = itemsAndCounts[i];
                var createdUi = Instantiate(orderTypeAndCountUi);
                createdUi.InsertData(currentItemAndCount);
                rectArray[i] = createdUi;
            }
            
            return rectArray;
        }
    }
}
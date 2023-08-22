using System;
using Scripts.BaseGameScripts.ComponentManagement;
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

        
        
        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            OrderActionManager.onNewOrderCreated += OnNewOrderCreated;
        }
        public override void UnsubscribeEvent()
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
            //var createdObj = Instantiate(orderUi, orderParentUiObj, true); // pool eklenecek
            var createdObj = orderUi.Pool.PullObjFromPool<BaseOrderUi>(orderParentUiObj, Vector3.zero, Vector3.zero);
            createdObj.RectTransformObj.anchoredPosition = createPos.position;
            createdObj.InsertData(order, GetCustomerFaceSprite(), CreateItemAndCount(order));
            onOrderUiCreated?.Invoke(createdObj);
            IncreaseCustomerFaceIndex();
        }
        private Sprite GetCustomerFaceSprite()
        {
            return customerFaces[customerFaceIndex];
        }
        private void IncreaseCustomerFaceIndex()
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
                //var createdUi = Instantiate(orderTypeAndCountUi);
                var createdUi = orderTypeAndCountUi.Pool.PullObjFromPool<OrderTypeAndCountUi>(Vector3.zero, Vector3.zero);
                createdUi.InsertData(currentItemAndCount);
                rectArray[i] = createdUi;
            }
            
            return rectArray;
        }
    }
}
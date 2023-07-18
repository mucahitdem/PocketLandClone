using System;
using System.Collections.Generic;
using Scripts.BaseGameScripts.Component;
using Scripts.BaseGameScripts.Helper;
using Scripts.GameScripts.UiManagement.UiGridManagement;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.GameScripts.UiManagement.OrderUi
{
    public class OrderUiManager : BaseComponent
    {
        [SerializeField]
        private OrderUiCreator orderUiCreator;

        [SerializeField]
        private UiGridManager uiGridManager;
        
        [SerializeField]
        [ReadOnly]
        private List<BaseOrderUi> currentOrderUis;
        
        private void Awake()
        {
            orderUiCreator.onOrderUiCreated += OnOrderUiCreated;
        }
        private void OnOrderUiCreated(BaseOrderUi baseOrderUi)
        {
            DebugHelper.LogYellow("ON ORDER CREATED");
            uiGridManager.AddItemToQueue(baseOrderUi.RectTransformObj);
        }
    }
}
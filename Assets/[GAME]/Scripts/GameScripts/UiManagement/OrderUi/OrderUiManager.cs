﻿using System.Collections.Generic;
using Scripts.BaseGameScripts.ComponentManagement;
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
            uiGridManager.AddItemToQueue(baseOrderUi.RectTransformObj);
        }
    }
}
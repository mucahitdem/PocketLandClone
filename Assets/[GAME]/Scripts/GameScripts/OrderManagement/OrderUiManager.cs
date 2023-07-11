using Scripts.BaseGameScripts.Component;
using Scripts.GameScripts.OrderManagement.Order;
using UnityEngine;

namespace Scripts.GameScripts.OrderManagement
{
    public class OrderUiManager : BaseComponent
    {
        [SerializeField]
        private BaseOrderUi[] orders;
    }
}
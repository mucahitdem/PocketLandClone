using Scripts.BaseGameScripts.Component;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.GameScripts.OrderManagement.Order
{
    public class BaseOrderUi : BaseComponent
    {
        [SerializeField]
        private Image customerIcon;

        [SerializeField]
        private TextMeshProUGUI priceText;

        [SerializeField]
        private TextMeshProUGUI targetAmount;
    }
}
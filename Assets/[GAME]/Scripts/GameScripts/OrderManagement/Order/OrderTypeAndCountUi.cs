using Scripts.BaseGameScripts.Component;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.GameScripts.OrderManagement.Order
{
    public class OrderTypeAndCountUi : BaseComponent
    {
        [SerializeField]
        private TextMeshProUGUI orderCountText;

        [SerializeField]
        private Image orderImage;

        public void UpdateVariables(ItemTypeAndCount typeAndCount)
        {
            var data = typeAndCount.item.baseItemData;
            orderImage.sprite = data.itemIcon;
            orderCountText.text = data.itemName;
        }
    }
}
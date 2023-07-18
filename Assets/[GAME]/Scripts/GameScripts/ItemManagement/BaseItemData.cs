using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.GameScripts.ItemManagement
{
    [Serializable]
    public class BaseItemData
    {
        public string itemName;

        [PreviewField(ObjectFieldAlignment.Left)]
        public Sprite itemIcon;

        [PreviewField(150, ObjectFieldAlignment.Left)]
        public BaseItem itemPrefab;

        public float xpValue;
        public int itemPrice;
        public int itemLaborPrice; // labor cost of harvesting the item

    }
}
using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.GameScripts.ItemManagement
{
    [Serializable]
    public class BaseItemData
    {
        [PreviewField(ObjectFieldAlignment.Left)]
        public Sprite itemIcon;

        public int itemLaborPrice; // labor cost of harvesting the item

        public string itemName;

        [PreviewField(150, ObjectFieldAlignment.Left)]
        public BaseItem itemPrefab;

        public int itemPrice;
    }
}
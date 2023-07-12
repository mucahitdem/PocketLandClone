using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.GameScripts.ItemManagement
{
    [Serializable]
    public class BaseItemData
    {
        [PreviewField(150, ObjectFieldAlignment.Left)]
        public BaseItem itemPrefab;
        [PreviewField(ObjectFieldAlignment.Left)]
        public Sprite itemIcon;

        public string itemName;
        public int itemPrice;       
        public int itemLaborPrice; // labor cost of harvesting the item
    }
}
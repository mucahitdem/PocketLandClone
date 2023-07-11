using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.GameScripts.ItemManagement.ItemTypes.HarvestableItems
{
    [Serializable]
    public class ItemToHarvestData : BaseItemData
    {
        [PreviewField(150, ObjectFieldAlignment.Left)]
        public BaseItem itemPrefab;
        [PreviewField(ObjectFieldAlignment.Left)]
        public Sprite itemIcon;

        public string itemName;
        public int itemPrice;
    }
}
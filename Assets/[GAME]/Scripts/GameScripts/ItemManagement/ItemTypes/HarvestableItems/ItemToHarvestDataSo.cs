using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.GameScripts.ItemManagement.ItemTypes.HarvestableItems
{
    [CreateAssetMenu(fileName = "Item To Harvest", menuName = "Game/Items/ItemToHarvest", order = 0)]
    [InlineEditor]
    public class ItemToHarvestDataSo : BaseItemDataSo
    {
        public ItemToHarvestData itemToHarvestData;
    }
}
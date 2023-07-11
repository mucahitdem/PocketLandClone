using System.Collections.Generic;
using Scripts.GameScripts.Helpers;
using Scripts.GameScripts.ItemManagement;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.GameScripts.ItemCreatingManagement
{
    public class BaseItemCreatorByTimeOnRandomPointInAnArea : BaseItemCreatorByTimer
    {
        [SerializeField]
        [ReadOnly]
        protected List<BaseItem> bricksOnScene = new List<BaseItem>();
        private RandomPointGeneratorOnRectangularArea randomPointGenerator;

        protected virtual void Awake()
        {
            randomPointGenerator = GetComponent<RandomPointGeneratorOnRectangularArea>();
        }

        protected override void CreateItem()
        {
            base.CreateItem();
            
        }


        private Vector3 GetRandomPosOnArea()
        {
            return (Vector3)randomPointGenerator.getRandomPos?.Invoke(); 
        }
    }
}
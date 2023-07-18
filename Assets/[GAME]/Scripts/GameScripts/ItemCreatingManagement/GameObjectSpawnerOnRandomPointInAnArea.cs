using System;
using Scripts.BaseGameScripts.Helper;
using Scripts.GameScripts.Helpers.RectangularAreaManagement;
using UnityEngine;

namespace Scripts.GameScripts.ItemCreatingManagement
{
    [RequireComponent(typeof(RandomPointGeneratorOnRectangularArea))]
    public class GameObjectSpawnerOnRandomPointInAnArea : BaseGameObjectSpawner
    {
        private RandomPointGeneratorOnRectangularArea randomPointGenerator;

        protected virtual void Awake()
        {
            randomPointGenerator = GetComponent<RandomPointGeneratorOnRectangularArea>();
        }

        protected override void CreateObject()
        {
            itemToCreate = GetItemToCreate();
            if(itemToCreate)
                createdObj = Instantiate(itemToCreate, GetRandomPosOnArea(), Quaternion.identity);
        }

        protected override GameObject GetItemToCreate()
        {
            return itemToCreate;
        }

        private Vector3 GetRandomPosOnArea()
        {
            return randomPointGenerator.GetRandomPos();
        }
    }
}
using System;
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
            createdObj = Instantiate(ItemToCreate, GetRandomPosOnArea(), Quaternion.identity);
        }

        protected Vector3 GetRandomPosOnArea()
        {
            return randomPointGenerator.GetRandomPos();
        }
    }
}
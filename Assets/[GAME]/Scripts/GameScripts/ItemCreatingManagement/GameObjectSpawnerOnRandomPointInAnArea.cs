using System;
using Scripts.GameScripts.Helpers;
using Scripts.GameScripts.Helpers.RectangularAreaManagement;
using UnityEngine;

namespace Scripts.GameScripts.ItemCreatingManagement
{
    [RequireComponent(typeof(RandomPointGeneratorOnRectangularArea))]
    public class GameObjectSpawnerOnRandomPointInAnArea : BaseGameObjectSpawner
    {
        private RandomPointGeneratorOnRectangularArea randomPointGenerator;

        private void OnValidate()
        {
            if(!randomPointGenerator)
                randomPointGenerator = GetComponent<RandomPointGeneratorOnRectangularArea>();
        }

        protected override void CreateObject()
        {
            
        }
        
        private Vector3 GetRandomPosOnArea()
        {
            return (Vector3)randomPointGenerator.getRandomPos?.Invoke(); 
        }
    }
}
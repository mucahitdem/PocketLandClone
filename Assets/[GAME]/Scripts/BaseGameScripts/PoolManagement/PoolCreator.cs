using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.BaseGameScripts.PoolManagement
{
    public class PoolCreator : MonoBehaviour
    {
        [SerializeField]
        private List<PoolObjectData> poolObjectDatas = new List<PoolObjectData>();

        private void Awake()
        {
            CreatePool();
        }


        private void CreatePool()
        {
            // foreach (var poolData in poolObjectDatas)
            // {
            //     var typeToCreate = poolData.selectType.GetSelectedType;
            //     var component = poolData.prefab.GetComponent(typeToCreate);
            //     if (component != null)
            //     {
            //         // Add the pool to your pool manager or a pool dictionary
            //         //PoolManager.Instance.CreatePool(typeToCreate, poolData.initialSize);
            //     }
            // }
        }
    }

    [Serializable]
    public class PoolObjectData
    {
        public int initialSize;
        public GameObject prefab;
    }
}
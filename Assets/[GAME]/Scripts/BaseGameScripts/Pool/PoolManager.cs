using System.Collections.Generic;
using Scripts.BaseGameScripts.Helper;
using UnityEngine;

namespace Scripts.BaseGameScripts.Pool
{
    public class PoolManager : SingletonMono<PoolManager>
    {
        private PoolingPattern _tempPool;

        private readonly Dictionary<string, PoolingPattern> idAndPool = new Dictionary<string, PoolingPattern>();

        [HideInInspector]
        public PoolingPattern[] itemsPool;

        [SerializeField]
        private BasePoolItem[] poolItems;

        protected override void OnAwake()
        {
            Create();
        }
        
        
        public PoolingPattern GetPoolWithId(string poolId)
        {
            if (idAndPool.TryGetValue(poolId, out _tempPool)) return _tempPool;

            //DebugHelper.LogRed("THERE IS NO POOL WITH ID : " + poolId);
            return null;
        }
        

        private void Create()
        {
            itemsPool = new PoolingPattern[poolItems.Length];
            for (var i = 0; i < poolItems.Length; i++)
            {
                var currentItem = poolItems[i];
                var currentPool = itemsPool[i];
                try
                {
                    currentPool = new PoolingPattern(currentItem, currentItem.Count);
                }
                catch
                {
                    //DebugHelper.LogYellow(ex.ToString());
                }
                idAndPool.Add(currentItem.PoolId, currentPool);
            }
        }
    }
}
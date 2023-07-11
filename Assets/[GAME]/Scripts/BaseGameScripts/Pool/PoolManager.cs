using System.Collections.Generic;
using Scripts.BaseGameScripts.Component;
using Scripts.BaseGameScripts.Helper;
using Scripts.GameScripts;
using UnityEngine;

namespace Scripts.BaseGameScripts.Pool
{
    public class PoolManager : SingletonMono<PoolManager>
    {
        private Dictionary<string, Pool> _idAndPool;
        
        [SerializeField]
        public Pool coinPool;

        [SerializeField]
        public Pool basicBulletPool;
        
        
        protected override void OnAwake()
        {
            _idAndPool = new Dictionary<string, Pool>();
            _idAndPool.Add(Defs.COIN_POOL_ID, coinPool);
            
        }

        // public BaseComponent SpawnItem(string poolId)
        // {
        //     Pool pool = GetPool(poolId);
        //     return pool.pool.Pull();
        // }
        
        // public void DeSpawnItem(string poolId, BaseComponent comp)
        // {
        //     Pool pool = GetPool(poolId); 
        //     pool.pool.Push(comp);
        // }

        // public Pool GetPool(string poolId)
        // {
        //     if (_idAndPool.TryGetValue(poolId, out Pool pool))
        //         return pool;
        //         
        //     return null;
        // }
    }
}
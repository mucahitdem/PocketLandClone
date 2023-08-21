using System;
using Scripts.BaseGameScripts.ComponentManager;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.BaseGameScripts.Pool
{
    public sealed class BasePoolItem : BaseComponent
    {
        public Action onGetFromPool;
        public Action onSendToPool;
        
        
        public BaseComponent PoolItem => poolItem;
        public string PoolId => poolId;
        public int Count => count;

        
        
        [SerializeField]
        [FoldoutGroup("Pool Variables")]
        private int count;
        
        [SerializeField]
        [FoldoutGroup("Pool Variables")]
        private string poolId;

        [SerializeField]
        [FoldoutGroup("Pool Variables")]
        private BaseComponent poolItem;
        
        
        private PoolingPattern PoolingPattern
        {
            get
            {
                if (!_poolingPattern)
                    _poolingPattern = PoolManager.Instance.GetPoolWithId(PoolId);

                return _poolingPattern;
            }
        }
        private PoolingPattern _poolingPattern;
        
        
        public T PullObjFromPool<T>(Vector3 pos, Vector3 rot = default) where T : BaseComponent
        {
            OnGetItemFromPool();
            return PoolingPattern.PullObjFromPool<T>(pos, rot);
        }
        public T PullObjFromPool<T>(Transform parent, Vector3 localPos, Vector3 localAngles) where T : BaseComponent
        {
            OnGetItemFromPool();
            return PoolingPattern.PullObjFromPool<T>(parent, localPos, localAngles);
        }

        public void AddObjToPool(BaseComponent objToPool)
        {
            OnSendObjToPool();
            try
            {
                PoolingPattern.AddObjToPool(objToPool);
            }
            catch
            {
                Debug.Log("NAME : " + TransformOfObj.name);
            }
        }

        
        private void OnGetItemFromPool()
        {
            onGetFromPool?.Invoke();
        }
        private void OnSendObjToPool()
        {
            onSendToPool?.Invoke();
        }
    }
}
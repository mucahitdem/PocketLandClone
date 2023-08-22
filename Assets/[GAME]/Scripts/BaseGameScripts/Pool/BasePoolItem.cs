using System;
using Scripts.BaseGameScripts.ComponentManagement;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.BaseGameScripts.Pool
{
    public sealed class BasePoolItem : BaseComponent
    {
        private PoolingPattern _poolingPattern;

        [SerializeField]
        [FoldoutGroup("Pool Variables")]
        private int count;

        public Action onGetFromPool;
        public Action onSendToPool;

        [SerializeField]
        [FoldoutGroup("Pool Variables")]
        private string poolId;

        [SerializeField]
        [FoldoutGroup("Pool Variables")]
        private BaseComponent poolItem;

        public BaseComponent PoolItem => poolItem;
        public string PoolId => poolId;
        public int Count => count;

        private PoolingPattern PoolingPattern
        {
            get
            {
                if (!_poolingPattern)
                    _poolingPattern = PoolManager.Instance.GetPoolWithId(PoolId);

                return _poolingPattern;
            }
        }

        private void Awake()
        {
            if (dontDestroyOnLoad)
                DontDestroyOnLoad(Go);
        }

     

        public BaseComponent PullObjFromPool(Transform parent, Vector3 localPos, Vector3 localAngles)
        {
            OnGetItemFromPool();
            return PoolingPattern.PullObjFromPool(parent, localPos, localAngles);
        }

        public BaseComponent PullObjFromPool(Vector3 pos, Vector3 rot = default)
        {
            OnGetItemFromPool();
            return PoolingPattern.PullObjFromPool(pos, rot);
        }

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
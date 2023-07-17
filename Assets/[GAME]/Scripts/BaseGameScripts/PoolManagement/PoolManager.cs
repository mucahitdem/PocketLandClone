using System;
using System.Collections.Generic;
using Scripts.BaseGameScripts.Component;
using Scripts.BaseGameScripts.Helper;
using UnityEngine;

namespace Scripts.BaseGameScripts.PoolManagement
{
    public class PoolManager : SingletonMono<PoolManager>
    {
        private readonly Dictionary<string, object> poolDictionary = new Dictionary<string, object>();

        protected override void OnAwake()
        {
        }

        public void CreatePool(Type componentType, int initialSize)
        {
            var poolType = typeof(Pool<>).MakeGenericType(componentType);
            var poolObj = Activator.CreateInstance(poolType);

            // Get the CreateNewObject method of the Pool<> class
            var createNewObjectMethod = poolType.GetMethod("CreateNewObject");

            // Invoke the CreateNewObject method on the poolObj instance
            createNewObjectMethod.Invoke(poolObj, new object[] {initialSize});

            // Add the poolObj to your pool manager or a pool dictionary
            poolDictionary.Add(componentType.Name, poolObj);
        }

        // public void CreatePool<T>(T prefab, int initialSize) where T : BaseComponent
        // {
        //     var pool = new Pool<T>(prefab, initialSize);
        //     poolDictionary[typeof(T).Name] = pool;
        // }
        public T GetObjectFromPool<T>() where T : BaseComponent
        {
            var poolName = typeof(T).Name;

            if (poolDictionary.TryGetValue(poolName, out var poolObj))
            {
                var pool = (Pool<T>) poolObj;
                return pool.GetObject();
            }

            Debug.LogWarning("Pool with name " + poolName + " does not exist.");
            return null;
        }

        public void ReturnObjectToPool<T>(T prefab, T obj) where T : BaseComponent
        {
            var poolName = typeof(T).Name;

            if (poolDictionary.TryGetValue(poolName, out var poolObj))
            {
                var pool = (Pool<T>) poolObj;
                pool.ReturnObject(obj);
            }
            else
            {
                Debug.LogWarning("Pool with name " + poolName + " does not exist.");
            }
        }
    }
}
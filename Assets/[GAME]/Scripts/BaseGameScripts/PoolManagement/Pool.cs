using System.Collections.Generic;
using UnityEngine;

namespace Scripts.BaseGameScripts.PoolManagement
{
    public class Pool<T> where T : UnityEngine.Component
    {
        private readonly Stack<T> objectPool = new Stack<T>();
        private readonly int initialSize;
        private readonly T prefab;

        public Pool(T prefab, int initialSize)
        {
            this.prefab = prefab;
            this.initialSize = initialSize;

            CreateNewObject();
        }

        public T GetObject()
        {
            if (objectPool.Count == 0) CreateNewObject();

            var obj = objectPool.Pop();
            obj.gameObject.SetActive(true);
            return obj;
        }

        public void ReturnObject(T obj)
        {
            obj.gameObject.SetActive(false);
            objectPool.Push(obj);
        }


        private void CreateNewObject()
        {
            for (var i = 0; i < initialSize; i++)
            {
                var newObj = Object.Instantiate(prefab);
                newObj.gameObject.SetActive(false);
                objectPool.Push(newObj);
            }
        }
    }
}
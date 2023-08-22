using System.Collections.Generic;
using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.BaseGameScripts.Helper;
using UnityEngine;

namespace Scripts.BaseGameScripts.Pool
{
    public class PoolingPattern : MonoBehaviour
    {
        private readonly Stack<BaseComponent> _objPool = new Stack<BaseComponent>();
        private readonly BaseComponent _prefab;
        private BaseComponent _type;

        public PoolingPattern(BaseComponent prefab, int count)
        {
            _prefab = prefab;
            FillPool(count);
        }
        public BaseComponent PullObjFromPool(Transform parent, Vector3 localPos, Vector3 localAngles = default)
        {
            BaseComponent obj = GetItem();
            
            obj.TransformOfObj.SetParent(parent);
            obj.TransformOfObj.localPosition = localPos;
            obj.TransformOfObj.localEulerAngles = localAngles;
            obj.Go.SetActive(true);

            return obj;
        }
        public BaseComponent PullObjFromPool(Vector3 pos, Vector3 rot = default)
        {
            BaseComponent obj = GetItem();
            
            obj.TransformOfObj.position = pos;
            obj.TransformOfObj.eulerAngles = rot;
            obj.Go.SetActive(true);

            return obj;
        }
        public T PullObjFromPool<T>(Vector3 pos, Vector3 rot = default) where T : BaseComponent
        {
            BaseComponent obj = GetItem();
            
            if (obj.TryGetComponent(out _type))
            {
                _type.TransformOfObj.position = pos;
                _type.TransformOfObj.eulerAngles = rot;
                obj.Go.SetActive(true);

                return _type as T;
            }

            return null;
        }
        public T PullObjFromPool<T>(Transform parent, Vector3 localPos, Vector3 localAngles = default) where T : BaseComponent
        {
            BaseComponent obj = GetItem();
            
            if (obj.TryGetComponent(out _type))
            {
                _type.TransformOfObj.SetParent(parent);
                _type.TransformOfObj.localPosition = localPos;
                _type.TransformOfObj.localEulerAngles = localAngles;
                obj.Go.SetActive(true);

                return _type as T;
            }

            return null;
        }
        public void AddObjToPool(BaseComponent objToPool)
        {
            objToPool.TransformOfObj.SetParent(null);
            objToPool.Go.SetActive(false);
            _objPool.Push(objToPool);
        }


        private BaseComponent GetItem()
        {
            if (_objPool.Count > 0)
                return _objPool.Pop();
            
            DebugHelper.LogRed("INSTANTIATE : " + _prefab.name);
            return Instantiate(_prefab);
        }
        private void FillPool(int amount)
        {
            for (var i = 0; i < amount; i++)
            {
                var obje = Instantiate(_prefab);
                AddObjToPool(obje);
            }
        }
    }
}
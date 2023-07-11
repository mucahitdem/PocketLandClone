using System.Collections.Generic;
using UnityEngine;

namespace Scripts.BaseGameScripts.Pool
{
    public class PoolingPattern<TObj> : MonoBehaviour where TObj : MonoBehaviour
    {
        private readonly int _amount;
        private readonly HideFlags _hide;
        private readonly Stack<TObj> _objPool = new Stack<TObj>(); // dependency inversion yapıalcak

        private readonly IPoolObject<TObj> _prefab;

        public PoolingPattern(IPoolObject<TObj> prefab)
        {
            _prefab = prefab;
            _hide = prefab.HideFlag;
            _amount = prefab.ItemCount;
            FillPool();
        }

        private void FillPool()
        {
            for (var i = 0; i < _amount; i++)
            {
                AddNewItemToPool();
            }
        }
        
        public TObj PullObj()
        {
            if (_objPool.Count > 0)
            {
                var obje = _objPool.Pop();
                obje.gameObject.SetActive(true);

                return obje;
            }

            return AddNewItemToPool();
        }

        public void AddBackToPool(TObj objToPool)
        {
            objToPool.gameObject.SetActive(false);
            _objPool.Push(objToPool);
        }

        private TObj AddNewItemToPool()
        {
            var obje = Instantiate(_prefab.ObjToPool);
            ((IPoolObject<TObj>) obje).SetPool(this);
            obje.gameObject.hideFlags = _hide;
            AddBackToPool(obje);

            return obje;
        }
    }
}
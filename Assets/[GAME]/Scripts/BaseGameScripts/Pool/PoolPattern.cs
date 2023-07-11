using System.Collections.Generic;
using Scripts.BaseGameScripts.Component;
using Scripts.BaseGameScripts.Helper;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.BaseGameScripts.Pool
{
    public class PoolPattern : MonoBehaviour
    {
        private readonly Stack<BaseComponent> _pool = new Stack<BaseComponent>(); 
        private readonly BaseComponent _prefab;
        private readonly HideFlags _hideFlag;
        
        private int _counter;
        
        public PoolPattern(BaseComponent prefab, int itemCount, HideFlags hideFlag)
        {
            _prefab = prefab;
            _hideFlag = hideFlag;
            
            FillPool(itemCount);
        }
        
        private void FillPool(int count)
        {
            for (int i = 0; i < count; i++)
            {
                //DebugHelper.LogGreen("CREATED " + prefab.name);
                BaseComponent obj = Instantiate(_prefab);
                obj.TransformOfObj.name += i;
                //obj.hideFlags = _hideFlag;
                Push(obj);
            }
        }
        // public BaseComponent Pull()
        // {
        //     return PullOjb();
        // }
        
        public T Pull<T>() where T : BaseComponent
        {
            return (T)PullOjb();
        }

        private BaseComponent PullOjb()
        {
            BaseComponent obj = null;

            if (!PoolIsEmpty())
            {
                obj = _pool.Pop();
            }
            else
            {
                obj = Instantiate(_prefab);
                obj.name += _counter.ToString();
                _counter++;
            }
            
            obj.OnGetFromPool();
            
            return obj;
        }

        public void Push(BaseComponent obj)
        {
            obj.OnPushToPool();
            _pool.Push(obj);
        }
        private bool PoolIsEmpty()
        {
            return _pool.Count == 0;
        }
    }
}
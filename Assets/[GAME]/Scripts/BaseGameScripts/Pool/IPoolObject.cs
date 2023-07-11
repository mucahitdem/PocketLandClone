using UnityEngine;

namespace Scripts.BaseGameScripts.Pool
{
    public interface IPoolObject<TObj> where TObj : MonoBehaviour
    { 
        PoolingPattern<TObj> Pool { get; set; }
        TObj ObjToPool { get; set; }
        int ItemCount { get; set; }
        HideFlags HideFlag { get; set; }

        void AddToPool();
        void SetPool(PoolingPattern<TObj> pool);
    }
}
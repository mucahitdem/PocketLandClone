using Scripts.BaseGameScripts.ComponentManager;
using Scripts.BaseGameScripts.Pool;
using UnityEngine;

namespace Scripts.GameScripts.ItemManagement
{
    public abstract class BaseItem : BaseComponent , IPoolItem<BaseItem>
    {
        [SerializeField]
        protected BaseItemDataSo baseItemDataSo;

        public virtual BaseItemDataSo BaseItemDataSo => baseItemDataSo;
        
        [field: SerializeField]
        public BasePoolItem PoolItem { get; set; }
        public BaseItem GetItem()
        {
            return PoolItem.PullObjFromPool<BaseItem>(Vector3.zero, Vector3.zero);
        }
    }
}
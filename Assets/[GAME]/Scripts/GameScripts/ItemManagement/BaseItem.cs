using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.BaseGameScripts.Pool;
using UnityEngine;

namespace Scripts.GameScripts.ItemManagement
{
    public abstract class BaseItem : BaseComponent
    {
        public BasePoolItem Pool => basePoolItem;
        public virtual BaseItemDataSo BaseItemDataSo => baseItemDataSo;

        
        
        [SerializeField]
        protected BaseItemDataSo baseItemDataSo;

        [SerializeField]
        private BasePoolItem basePoolItem;
    }
}
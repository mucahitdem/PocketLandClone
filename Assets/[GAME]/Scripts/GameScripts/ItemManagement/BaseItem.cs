using Scripts.BaseGameScripts.Component;
using UnityEngine;

namespace Scripts.GameScripts.ItemManagement
{
    public abstract class BaseItem : BaseComponent
    {
        public virtual BaseItemDataSo BaseItemDataSo => baseItemDataSo;
        
        [SerializeField]
        protected BaseItemDataSo baseItemDataSo;
    }
}
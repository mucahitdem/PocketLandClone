using Scripts.BaseGameScripts.Component;
using UnityEngine;

namespace Scripts.GameScripts.ItemManagement
{
    public abstract class BaseItem : BaseComponent
    {
        [SerializeField]
        protected BaseItemDataSo baseItemDataSo;

        public virtual BaseItemDataSo BaseItemDataSo => baseItemDataSo;
    }
}
using System.Collections.Generic;
using Scripts.BaseGameScripts.Component;
using Scripts.BaseGameScripts.Pool;
using Scripts.GameScripts.ItemManagement;
using UnityEngine;

namespace Scripts.GameScripts.ItemCreatingManagement
{
    public abstract class BaseItemCreator : BaseComponent
    {
        [SerializeField]
        protected BaseItem itemToCreate;
        
        protected abstract void CreateItem();
        
    }
}
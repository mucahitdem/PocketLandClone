using Scripts.BaseGameScripts.Component;
using UnityEngine;

namespace Scripts.GameScripts.ItemCreatingManagement
{
    public abstract class BaseGameObjectSpawner : BaseComponent
    {
        protected virtual GameObject ItemToCreate => null;
        protected GameObject createdObj;
        protected virtual void CreateObject()
        {
            createdObj = Instantiate(ItemToCreate);
        }
    }
}
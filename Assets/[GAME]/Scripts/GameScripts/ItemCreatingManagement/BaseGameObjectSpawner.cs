using Scripts.BaseGameScripts.ComponentManager;
using Scripts.BaseGameScripts.Helper;
using UnityEngine;

namespace Scripts.GameScripts.ItemCreatingManagement
{
    public abstract class BaseGameObjectSpawner : BaseComponent
    {
        protected GameObject itemToCreate;
        protected GameObject createdObj;
        protected virtual void CreateObject()
        {
            if(!GetItemToCreate())
            {
                DebugHelper.LogYellow("ITEM TO CREATE IS NULL");
                return;
            }
            createdObj = Instantiate(GetItemToCreate());
        }

        protected abstract GameObject GetItemToCreate();

    }
}
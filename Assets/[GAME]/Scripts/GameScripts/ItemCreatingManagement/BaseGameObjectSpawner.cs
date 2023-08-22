using Scripts.BaseGameScripts.ComponentManagement;
using UnityEngine;

namespace Scripts.GameScripts.ItemCreatingManagement
{
    public abstract class BaseGameObjectSpawner : BaseComponent
    {
        protected GameObject itemToCreate;
        protected GameObject createdObj;
        protected abstract void CreateObject();
        protected abstract GameObject GetItemToCreate();

    }
}
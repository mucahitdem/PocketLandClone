using Scripts.BaseGameScripts.Component;
using UnityEngine;

namespace Scripts.GameScripts.ItemCreatingManagement
{
    public abstract class BaseGameObjectSpawner : BaseComponent
    {
        protected GameObject itemToCreate;

        protected abstract void CreateObject();
    }
}
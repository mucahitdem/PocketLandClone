﻿using Scripts.BaseGameScripts.ComponentManager;

 namespace Scripts.BaseGameScripts.Pool
{
    public interface IPoolItem<out T> where T : BaseComponent
    { 
        BasePoolItem PoolItem { get; set; }
        T GetItem();
    }
}
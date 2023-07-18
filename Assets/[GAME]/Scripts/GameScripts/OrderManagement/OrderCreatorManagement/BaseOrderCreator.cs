using System.Collections;
using Scripts.BaseGameScripts.Component;
using Scripts.GameScripts.PlayerManagement;
using UnityEngine;

namespace Scripts.GameScripts.OrderManagement.OrderCreatorManagement
{
    public abstract class BaseOrderCreator : BaseComponent
    {
        [SerializeField]
        private BaseOrderCreatorDataSo baseOrderCreatorDataSo;

        private PlayerManager playerManager;
        protected BaseOrderCreatorDataSo BaseOrderCreatorDataSo => baseOrderCreatorDataSo;
        protected int PlayerLevel => playerManager.Level;

        protected virtual void Start()
        {
            playerManager = GameManager.Instance.PlayerManager;
        }


        public abstract void CreateNewOrder();
    }
}
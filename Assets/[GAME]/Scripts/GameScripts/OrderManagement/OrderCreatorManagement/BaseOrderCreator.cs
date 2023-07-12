using Scripts.BaseGameScripts.Component;
using Scripts.GameScripts.PlayerManagement;
using UnityEngine;

namespace Scripts.GameScripts.OrderManagement.OrderCreatorManagement
{
    public abstract class BaseOrderCreator : BaseComponent
    {
        protected OrderCreatorDataSo OrderCreatorDataSo => orderCreatorDataSo;
        protected int PlayerLevel => playerManager.Level;

        [SerializeField]
        private OrderCreatorDataSo orderCreatorDataSo;

        private PlayerManager playerManager;

        protected virtual void Start()
        {
            playerManager = GameManager.Instance.PlayerManager;
        }

        

        public abstract void CreateNewOrder();
    }
}
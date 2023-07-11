using System;
using Scripts.BaseGameScripts.Component;
using Scripts.BaseGameScripts.Helper;
using UnityEngine;

namespace Scripts.GameScripts.StatsManagement
{
    public class BaseStatsManager : BaseComponent
    {
        public Action<float, float> onHealthValueChanged;
        public Action onDied;

        
        [SerializeField]
        protected BaseStatsDataSo baseStatsDataSo;
        
        public float CurrentHealth { get; protected set; }

        protected float health;
        private float _healthPercentage;

        protected virtual void Awake()
        {
        }
        
        
        public void TakeDamage(float damage)
        {
            ControlHealth(-damage);
         
            DebugHelper.LogYellow("NEW HEALTH OF CHAR : " + TransformOfObj.name + " === " + CurrentHealth);
            
            if (CurrentHealth <= 0)
            {
                CurrentHealth = 0;
                OnDied();
            }
        }


        protected virtual void ControlHealth(float amount)
        {
            CurrentHealth += amount;
            CurrentHealth = Mathf.Clamp(CurrentHealth, 0, health);
            CalculateHealthPercentage();
            onHealthValueChanged?.Invoke(CurrentHealth, _healthPercentage);
        }

        protected virtual void OnDied()
        {
            onDied?.Invoke();
        }

        private void CalculateHealthPercentage()
        {
            _healthPercentage = CurrentHealth / health;
        }
    }
}
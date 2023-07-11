using System;
using Scripts.BaseGameScripts.Helper;
using Scripts.BaseGameScripts.SaveAndLoad;
using Scripts.GameScripts;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.BaseGameScripts.CoinControl
{
    public class CoinManager : SingletonMono<CoinManager>, ISaveAndLoad
    {
        public static Action<float> onCoinCountChanged;

        private float TotalCoins { get; set; }
        
        
        protected override void OnAwake()
        {
            Load();
        }

        private void Start()
        {
            onCoinCountChanged?.Invoke(TotalCoins);
        }

        public void Save()
        {
            PlayerPrefs.SetFloat(Defs.SAVE_KEY_COIN_COUNT, TotalCoins);
        }

        public void Load()
        {
            TotalCoins = PlayerPrefs.GetFloat(Defs.SAVE_KEY_COIN_COUNT, 0);
            Debug.Log("TOTAL COIN COUNT LOADED: " + TotalCoins);
        }
        
        
        [Button]
        public void AddCoin(float coinToAdd)
        {
            TotalCoins += coinToAdd;
            onCoinCountChanged?.Invoke(TotalCoins);
        }
        
        [Button]
        public void SpendCoin(float coinToSpend)
        {
            TotalCoins -= coinToSpend;
            onCoinCountChanged?.Invoke(TotalCoins);
        }

        public bool CheckIfYouHaveEnoughCoin(float coinCountToCheck)
        {
            return coinCountToCheck <= TotalCoins;
        }
    }
}
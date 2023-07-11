using System;
using System.Collections.Generic;
using BayatGames.SaveGameFree;
using Scripts.BaseGameScripts.SaveAndLoad;
using Scripts.GameScripts;
using Scripts.GameScripts.Upgrade;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.BaseGameSystemRelatedScripts.Upgrade
{
    [Serializable]
    public class UpgradeData
    {
        [HideLabel]
        [GUIColor(0.81f, 1, 0.57f)]
        [TabGroup("Add")]
        public AddData addData;

        [HideLabel]
        [GUIColor(0.81f, 1, 0.57f)]
        [TabGroup("Income")]
        public IncomeData incomeData;
        
        // [HideLabel]
        // [GUIColor(0.81f, 1, 0.57f)]
        // [TabGroup("Merge")]
        // public MergeData mergeData;
        //
        // [HideLabel]
        // [GUIColor(0.81f, 1, 0.57f)]
        // [TabGroup("Speed")]
        // public SpeedData speedData;
    }

    [Serializable]
    public class SpeedData : UpgradableData
    {
        [SerializeField]
        [Title("Power Info")]
        public float baseSpeed;

        [SerializeField]
        private float speedIncreaseAmount;

        [HideInInspector]
        public float SpeedDelta => maxUpgradeCount * speedIncreaseAmount;

        [ShowInInspector]
        public float ActiveSpeed => baseSpeed + _UpgradedSpeed();

        private float _UpgradedSpeed()
        {
            return upgradeCount * speedIncreaseAmount;
        }

        public override void Save()
        {
            
        }

        public override void Load()
        {
            
        }
    }

    [Serializable]
    public class IncomeData : UpgradableData
    {
        [SerializeField]
        private int incomeIncreasePercentage;

        [ShowInInspector]
        public int ActiveIncomeIncreasePercentage => upgradeCount > 0 ? _UpgradedIncome() * upgradeCount : 0;

        private int _UpgradedIncome()
        {
            return incomeIncreasePercentage;
        }
        
        public override void Save()
        {
            PlayerPrefs.SetInt(Defs.SAVE_KEY_INCOME_UPGRADE_COUNT, upgradeCount);
        }

        public override void Load()
        {
            upgradeCount = PlayerPrefs.GetInt(Defs.SAVE_KEY_INCOME_UPGRADE_COUNT, 0);
        }
    }

    [Serializable]
    public class MergeData : UpgradableData
    {
        public override void Save()
        {
            
        }

        public override void Load()
        {
            
        }

        public override void Upgrade()
        {
            base.Upgrade();
        }
    }

    [Serializable]
    public class AddData : UpgradableData
    {
        public override void Save()
        {
            PlayerPrefs.SetInt(Defs.SAVE_KEY_ADD_UPGRADE_COUNT, upgradeCount);

        }

        public override void Load()
        {
            upgradeCount = PlayerPrefs.GetInt(Defs.SAVE_KEY_ADD_UPGRADE_COUNT, 0);
        }
    }

    [Serializable]
    [PropertyOrder(-1)]
    public abstract class UpgradableData : ISaveAndLoad
    {
        public Action onUpgradeCountChanged;
        public int UpgradeCount
        {
            get => upgradeCount;
            set => upgradeCount = value;
        }
        
        [SerializeField]
        [FoldoutGroup("UpgradableData")]
        [PropertyOrder(-5)]
        [GUIColor(0.57f, 0.91f, 1)]
        protected int maxUpgradeCount;
        

        [SerializeField]
        [HorizontalGroup("UpgradableData/cost")]
        [PropertyOrder(-4)]
        [HideLabel]
        [GUIColor(0.57f, 0.91f, 1)]
        public Ease upgradeCostIncrease;

        [SerializeField]
        [HideInEditorMode]
        protected int upgradeCount;

        [ShowInInspector]
        [FoldoutGroup("UpgradableData")]
        [PropertyOrder(-4)]
        [GUIColor(0.57f, 0.91f, 1)]
        public float UpgradeCost => upgradeCostIncrease.ApplyValue(upgradeCount);

        [ShowInInspector]
        [HorizontalGroup("UpgradableData/Prop")]
        [PropertyOrder(-5)]
        [SuffixLabel("_upgradePercentSuffix")]
        [GUIColor(0.57f, 0.91f, 1)]
        public int UpgradeLevel => upgradeCount;

        [ShowInInspector]
        [HorizontalGroup("UpgradableData/Prop")]
        [PropertyOrder(-5)]
        [SuffixLabel("%")]
        [LabelWidth(100)]
        [GUIColor(0.57f, 0.91f, 1)]

        public float UpgradePercent => upgradeCount / (float) maxUpgradeCount * 100;

        public bool UpgradeMaxed => UpgradePercent > 99.99f;

        private string UpgradePercentSuffix => "/" + maxUpgradeCount; //used by odin

        public abstract void Save();

        public abstract void Load();

        public float GetCost()
        {
            if (UpgradeMaxed)
                return -1; // "MAX"

            return (int) UpgradeCost;
        }

        private void CheckLevelBound()
        {
            upgradeCount = Mathf.Min(upgradeCount, maxUpgradeCount);
        }

        [Button]
        [ButtonGroup("UpgradableData/Button")]
        [PropertyOrder(-1)]
        [GUIColor(0.57f, 0.91f, 1)]
        public virtual void Upgrade()
        {
            upgradeCount++;
            onUpgradeCountChanged?.Invoke();
            CheckLevelBound();
        }

        [Button]
        [ButtonGroup("UpgradableData/Button")]
        [PropertyOrder(-1)]
        [GUIColor(0.57f, 0.91f, 1)]
        public void Reset()
        {
            upgradeCount = 0;
            //onUpgradeCountChanged?.Invoke();
        }

        [Button]
        [ButtonGroup("UpgradableData/Button")]
        [PropertyOrder(-1)]
        [GUIColor(0.57f, 0.91f, 1)]
        public virtual void Max()
        {
            for (var i = 0; i < maxUpgradeCount; i++)
            {
                upgradeCount++;
                CheckLevelBound();
                onUpgradeCountChanged?.Invoke();
            }
        }

        public void SetUpgradeCount(int newUpgradeCount)
        {
            upgradeCount = newUpgradeCount;
        }
    }
}
using System.Collections.Generic;
using Scripts.BaseGameScripts.Helper;
using Scripts.GameScripts.SourceManagement;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.BaseGameScripts.SourceManagement
{
    public sealed class SourceManager : SingletonMono<SourceManager>
    {
        private readonly Dictionary<BaseSourceDataSo, BaseSource> _dataAndSources =
            new Dictionary<BaseSourceDataSo, BaseSource>();

        private BaseSource _tempSource;

        [SerializeField]
        [ReadOnly]
        private BaseSource[] sources;

        protected override void OnAwake()
        {
            sources = FindObjectsOfType<BaseSource>();
            for (var i = 0; i < sources.Length; i++)
            {
                var currentSource = sources[i];
                _dataAndSources.Add(currentSource.BaseSourceDataSo, currentSource);
            }
        }

        private void OnEnable()
        {
            SubscribeEvent();
        }
        private void OnDisable()
        {
            UnsubscribeEvent();
        }
        private void SubscribeEvent()
        {
            SourceActionManager.addSource += AddSource;
            SourceActionManager.trySpendSource += TrySpendSource;
            SourceActionManager.getCurrentSource += GetCurrentSource;
        }
        private void UnsubscribeEvent()
        {
            SourceActionManager.addSource -= AddSource;
            SourceActionManager.trySpendSource -= TrySpendSource;
            SourceActionManager.getCurrentSource -= GetCurrentSource;
        }


        private int GetCurrentSource(BaseSourceDataSo sourceType)
        {
            if (_dataAndSources.TryGetValue(sourceType, out _tempSource)) return _tempSource.CurrentSource;

            //DebugHelper.LogYellow("SOURCE NAME :'" + sourceType.baseSourceData.sourceName + "'");
            return -1;
        }
        private bool TrySpendSource(int count, BaseSourceDataSo targetSo)
        {
            if (_dataAndSources.TryGetValue(targetSo, out _tempSource))
                if (_tempSource.TrySpendSource(count))
                    return true;

            //DebugHelper.LogYellow("SOURCE NAME :'" + targetSo.baseSourceData.sourceName + "'");
            return false;
        }
        private void AddSource(int count, BaseSourceDataSo targetSo)
        {
            if (_dataAndSources.TryGetValue(targetSo, out _tempSource))
            {
                _tempSource.AddSource(count);
                return;
            }

            DebugHelper.LogRed("THIS IS NOT AN EXIST SOURCE");
        }
    }
}
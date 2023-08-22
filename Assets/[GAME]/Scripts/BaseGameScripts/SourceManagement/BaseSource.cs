using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.BaseGameScripts.Helper;
using Scripts.BaseGameScripts.SaveAndLoad;
using Scripts.BaseGameScripts.SourceManagement;
using UnityEngine;

namespace Scripts.GameScripts.SourceManagement
{
    public class BaseSource : BaseComponent, ISaveAndLoad
    {
        [SerializeField]
        protected BaseSourceDataSo baseSourceDataSo;

        protected int currentSource;
        public int CurrentSource => currentSource;
        public BaseSourceDataSo BaseSourceDataSo => baseSourceDataSo;

        public void Save()
        {
            PlayerPrefs.SetInt(baseSourceDataSo.baseSourceData.sourceName, currentSource);
        }

        public void Load()
        {
            currentSource = PlayerPrefs.GetInt(baseSourceDataSo.baseSourceData.sourceName,
                baseSourceDataSo.baseSourceData.initialSourceCount);
            OnSourceUpdated();
        }

        protected virtual void Awake()
        {
            if (dontDestroyOnLoad)
            {
                TransformOfObj.parent = null;
                DontDestroyOnLoad(Go);
            }
        }

        protected virtual void Start()
        {
            Load();
        }

        public bool TrySpendSource(int count)
        {
            if (currentSource >= count)
            {
                currentSource -= count;
                return true;
            }

            return false;
        }

        public virtual void AddSource(int count)
        {
            currentSource += count;
            OnSourceUpdated();
            //DebugHelper.LogRed(TransformOfObj.name + " TOTAL SOURCE : " + currentSource);
            Save();
        }

        protected virtual void OnSourceUpdated()
        {
            SourceActionManager.onSourceUpdated?.Invoke(currentSource);
        }
    }
}
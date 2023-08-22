using Scripts.BaseGameScripts.Helper;
using Scripts.BaseGameScripts.SaveAndLoad;
using UnityEngine;

namespace Scripts.BaseGameScripts.SaveAndLoadManagement
{
    public class SaveAndLoadManager : SingletonMono<SaveAndLoadManager>, ISaveAndLoad
    {
        private ISaveAndLoad _tempSaveAndLoad;

        [SerializeField]
        private MonoBehaviour[] saveAndLoads;

        public void Save()
        {
            // for (int i = 0; i < saveAndLoads.Length; i++)
            // {
            //     var currentData = saveAndLoads[i];
            //     if (currentData.TryGetComponent(out _tempSaveAndLoad))
            //     {
            //         _tempSaveAndLoad.Save();
            //     }
            //     else
            //     {
            //         DebugHelper.LogYellow(currentData.name + " --- " + "NOT SAVE AND LOAD");
            //     }
            // }
        }

        public void Load()
        {
            for (var i = 0; i < saveAndLoads.Length; i++)
            {
                var currentData = saveAndLoads[i];
                if (currentData.TryGetComponent(out _tempSaveAndLoad))
                    _tempSaveAndLoad.Save();
                else
                    DebugHelper.LogYellow(currentData.name + " --- " + "NOT SAVE AND LOAD");
            }
        }

        protected override void OnAwake()
        {
            // Load();
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            if (hasFocus)
                Save();
        }

        private void OnApplicationQuit()
        {
            Save();
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            if (pauseStatus)
                Save();
        }
    }
}
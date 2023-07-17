using System.Collections.Generic;
using UnityEngine;

namespace Scripts.BaseGameScripts.SaveAndLoad
{
    public class SaveManager : MonoBehaviour
    {
        private readonly List<ISaveAndLoad> _saveAndLoads = new List<ISaveAndLoad>();

        [SerializeField]
        private List<GameObject> saveAndLoads = new List<GameObject>();

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

        public void Register(GameObject go)
        {
            _saveAndLoads.Add(go.GetComponent<ISaveAndLoad>());
        }

        private void Save()
        {
            for (var i = 0; i < _saveAndLoads.Count; i++) _saveAndLoads[i].Save();
        }

        private void Load()
        {
            for (var i = 0; i < _saveAndLoads.Count; i++) _saveAndLoads[i].Load();
        }
    }
}
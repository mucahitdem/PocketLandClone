using System.Collections.Generic;
using UnityEngine;

namespace Scripts.BaseGameScripts.SaveAndLoad
{
    public class SaveManager : MonoBehaviour
    {
        [SerializeField]
        private List<GameObject> saveAndLoads = new List<GameObject>();
        private List<ISaveAndLoad> _saveAndLoads = new List<ISaveAndLoad>();

        private void OnApplicationFocus(bool hasFocus)
        {
            if(hasFocus)
                Save();
        }

        private void OnApplicationQuit()
        {
            Save();
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            if(pauseStatus)
                Save();
        }

        public void Register(GameObject go)
        {
            _saveAndLoads.Add(go.GetComponent<ISaveAndLoad>());
        }

        private void Save()
        {
            for (int i = 0; i < _saveAndLoads.Count; i++)
            {
                _saveAndLoads[i].Save();
            }
        }
        
        private void Load()
        {
            for (int i = 0; i < _saveAndLoads.Count; i++)
            {
                _saveAndLoads[i].Load();
            }
        }
    }
}
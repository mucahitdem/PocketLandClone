using System.Collections.Generic;
using Scripts.BaseGameScripts.SaveAndLoad;
using UnityEngine;

namespace Scripts.BaseGameSystemRelatedScripts
{
    public class SaveManager : MonoBehaviour
    {
        [SerializeField]
        private List<GameObject> saveAndLoads = new List<GameObject>();

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

        private void Save()
        {
            for (int i = 0; i < saveAndLoads.Count; i++)
            {
                (saveAndLoads[i]).GetComponent<ISaveAndLoad>().Save();
            }
        }
        
        private void Load() // initial loads are better
        {
            for (int i = 0; i < saveAndLoads.Count; i++)
            {
                (saveAndLoads[i]).GetComponent<ISaveAndLoad>().Load();
            }
        }
    }
}
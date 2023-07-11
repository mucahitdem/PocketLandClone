using System;
using System.Collections.Generic;
using Scripts.BaseGameScripts.Helper;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.BaseGameScripts.SaveAndLoad
{
    public class SaveAndLoadManager : MonoBehaviour
    {
        [ReadOnly]
        [ShowInInspector]
        private List<Type> _saveAndLoads = new List<Type>();

        private void Awake()
        {
            GetAllSaveAndLoadDataOnScene();
        }

        private void GetAllSaveAndLoadDataOnScene()
        {
            var subClasses = AssemblyManager.GetClassesImplementedInterface(typeof(ISaveAndLoad));
            
            for (var i = 0; i < subClasses.Count; i++)
            {
                var currentType = subClasses[i];
                _saveAndLoads.Add(currentType);
            }
        }
    }
}
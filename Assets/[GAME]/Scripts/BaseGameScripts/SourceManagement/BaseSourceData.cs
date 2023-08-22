using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.BaseGameScripts.SourceManagement
{
    [Serializable]
    public class BaseSourceData
    {
        public int initialSourceCount;
        [PreviewField(ObjectFieldAlignment.Left)]
        public Sprite sourceIcon;
        public string sourceName;
    }
}
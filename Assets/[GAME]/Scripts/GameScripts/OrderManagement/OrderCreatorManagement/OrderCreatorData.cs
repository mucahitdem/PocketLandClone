using System;
using Scripts.GameScripts.ItemManagement;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.GameScripts.OrderManagement.OrderCreatorManagement
{
    [Serializable]
    public class OrderCreatorData
    {
        [PreviewField(ObjectFieldAlignment.Left)]
        public Sprite[] customerFaces;
    }
}
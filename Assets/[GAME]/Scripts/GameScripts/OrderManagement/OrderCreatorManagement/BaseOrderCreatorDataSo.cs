using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.GameScripts.OrderManagement.OrderCreatorManagement
{
    [CreateAssetMenu(fileName = "Order Creator Data", menuName = "Game/Order Creator Data", order = 0)]
    [InlineEditor]
    public class BaseOrderCreatorDataSo : ScriptableObject
    {
        public BaseOrderCreatorData baseOrderCreatorData;
    }
}
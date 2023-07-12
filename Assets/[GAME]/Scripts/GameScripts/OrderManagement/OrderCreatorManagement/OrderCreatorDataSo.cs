using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.GameScripts.OrderManagement.OrderCreatorManagement
{
    [CreateAssetMenu(fileName = "Order Creator Data", menuName = "Game/Order Creator Data", order = 0)]
    [InlineEditor]
    public class OrderCreatorDataSo : ScriptableObject
    {
        public OrderCreatorData orderCreatorData;
    }
}
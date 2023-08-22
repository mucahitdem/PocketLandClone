using Scripts.GameScripts.ItemManagement;
using UnityEngine;

namespace Scripts.GameScripts.InteractionManagement
{
    public class PlayerInteractionManager : BaseInteractionManager
    {
        private Transform _collidedTransform;

        private BaseItem item;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out item))
            {
                InteractionActionManager.onCollectedItem?.Invoke(item.BaseItemDataSo);
                item.Pool.AddObjToPool(item); //item.gameObject.SetActive(false); // use pooling
                item = null;
            }
        }
    }
}
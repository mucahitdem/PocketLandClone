using System;
using Scripts.GameScripts.XpManagement;
using UnityEngine;

namespace Scripts.GameScripts.InteractionManagement
{
    public class PlayerInteractionManager : BaseInteractionManager
    {
        public Action<float> onXpCollected;
        
        private XpSphere _xpSphere;
        private Transform _collidedTransform;
        
        private void OnCollisionEnter(Collision other)
        {
            _collidedTransform = other.transform;
            if (_collidedTransform.CompareTag(Defs.TAG_XP_SPHERE))
            {
                if (_collidedTransform.TryGetComponent(out _xpSphere))
                {
                    onXpCollected?.Invoke(_xpSphere.Xp);
                    other.gameObject.SetActive(false);
                }
            }
        }
    }
}
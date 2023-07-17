using System;
using Scripts.GameScripts.XpManagement;
using UnityEngine;

namespace Scripts.GameScripts.InteractionManagement
{
    public class PlayerInteractionManager : BaseInteractionManager
    {
        private Transform _collidedTransform;

        private XpSphere _xpSphere;
        public Action<float> onXpCollected;

        private void OnCollisionEnter(Collision other)
        {
            _collidedTransform = other.transform;
            if (_collidedTransform.CompareTag(Defs.TAG_XP_SPHERE))
                if (_collidedTransform.TryGetComponent(out _xpSphere))
                {
                    onXpCollected?.Invoke(_xpSphere.Xp);
                    other.gameObject.SetActive(false);
                }
        }
    }
}
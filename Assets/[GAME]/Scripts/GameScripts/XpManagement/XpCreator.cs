using Scripts.BaseGameScripts.Component;
using Scripts.BaseGameScripts.Helper;
using Scripts.GameScripts.StatsManagement;
using UnityEngine;

namespace Scripts.GameScripts.XpManagement
{
    public class XpCreator : BaseComponent
    {
        [SerializeField]
        private XpSphere xpSphere;
        
        protected override void SubscribeEvent()
        {
            base.SubscribeEvent();
            StatsActionManager.onXpDropped += OnXpDropped;
        }

        protected override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            StatsActionManager.onXpDropped -= OnXpDropped;
        }

        private void OnXpDropped(Vector3 posToCreate, float xpVal)
        {
            DebugHelper.LogRed("XP DROPPED");
            var createdXpSphere = Instantiate(xpSphere, posToCreate, Quaternion.identity);
            createdXpSphere.LoadXp(xpVal);
        }
    }
}
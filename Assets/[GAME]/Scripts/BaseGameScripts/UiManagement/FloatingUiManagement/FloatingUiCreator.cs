using Scripts.BaseGameScripts.ComponentManagement;
using UnityEngine;

namespace Scripts.BaseGameScripts.UiManagement.FloatingUiManagement
{
    public class FloatingUiCreator : BaseComponent
    {
        [SerializeField]
        private BaseFloatingUi baseFloatingUi;


        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            UiActionManager.createFloatingUi += CreateFloatingUi;
        }

        public override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            UiActionManager.createFloatingUi -= CreateFloatingUi;
        }

        private void CreateFloatingUi(Vector3 pos, string message)
        {
            var createdUi = baseFloatingUi.BasePoolItem.PullObjFromPool<BaseFloatingUi>(pos, new Vector3(45, 45, 0));
            createdUi.SetData(message);
        }
    }
}
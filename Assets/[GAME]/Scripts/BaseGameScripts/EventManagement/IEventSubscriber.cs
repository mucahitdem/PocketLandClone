namespace Scripts.BaseGameScripts.EventManagement
{
    public interface IEventSubscriber
    {
        public void SubscribeEvent();
        void UnsubscribeEvent();
    }
}
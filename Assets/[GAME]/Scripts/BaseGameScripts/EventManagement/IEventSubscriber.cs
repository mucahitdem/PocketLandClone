namespace Scripts.BaseGameScripts.EventManagement
{
    public interface IEventSubscriber
    {
        protected void SubscribeEvent();
        protected void UnsubscribeEvent();
    }
}
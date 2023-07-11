namespace Scripts.BaseGameScripts.Helper
{
    public interface IEventSubscriber
    {
        protected void SubscribeEvent();
        protected void UnsubscribeEvent();
    }
}
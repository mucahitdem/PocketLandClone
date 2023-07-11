namespace Scripts.BaseGameScripts.Helper
{
    public interface IEventSubscriber
    {
        void SubscribeEvent();
        void UnsubscribeEvent();
    }
}
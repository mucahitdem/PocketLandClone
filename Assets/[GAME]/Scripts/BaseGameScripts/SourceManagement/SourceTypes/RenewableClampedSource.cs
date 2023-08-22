using Scripts.BaseGameScripts.TimerManagement;
using Scripts.GameScripts.SourceManagement;
using UnityEngine;

namespace Scripts.BaseGameScripts.SourceManagement.SourceTypes
{
    public class RenewableClampedSource : BaseSource
    {
        private RenewableClampedSourceDataSo _dataSo;

        [SerializeField]
        private Timer timer;

        protected override void Awake()
        {
            base.Awake();
            _dataSo = (RenewableClampedSourceDataSo) baseSourceDataSo;
        }

        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            if (timer)
                timer.onTimerEnded += OnTimerEnded;
        }

        private void OnTimerEnded()
        {
            AddSource(1);
        }

        public override void AddSource(int count)
        {
            currentSource += count;
            currentSource = Mathf.Clamp(currentSource, 0, _dataSo.data.maxSourceCount);
            OnSourceUpdated();
            Save();
        }

        protected override void OnSourceUpdated()
        {
            SourceActionManager.onClampedSourceUpdated?.Invoke(currentSource, _dataSo.data.maxSourceCount);
        }
    }
}
using System;
using Sirenix.OdinInspector;

namespace Scripts.BaseGameScripts.TimerManagement
{
    [Serializable]
    public class TimerData
    {
        [Title("Repeat")]
        public bool isRepeating;

        [Title("Starting Timer")]
        public bool restartManually;

        [Title("Timer")]
        public float timerValue;

        public TimerData(float timerValue, bool isRepeating, bool restartManually)
        {
            this.timerValue = timerValue;
            this.isRepeating = isRepeating;
            this.restartManually = restartManually;
        }
    }
}
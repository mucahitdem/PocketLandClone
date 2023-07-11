using System;
using Sirenix.OdinInspector;

namespace Scripts.BaseGameSystemRelatedScripts.TimerManagement
{
    [Serializable]
    public class TimerData
    {
        public TimerData(float timerValue, bool isRepeating, bool restartManually)
        {
            this.timerValue = timerValue;
            this.isRepeating = isRepeating;
            this.restartManually = restartManually;
        }
        
        [Title("Timer")]
        public float timerValue;
        
        [Title("Repeat")]
        public bool isRepeating;

        [Title("Starting Timer")]
        public bool restartManually;
    }
}
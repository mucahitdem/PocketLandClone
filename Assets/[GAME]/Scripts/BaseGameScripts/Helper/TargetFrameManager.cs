using Scripts.BaseGameScripts.ComponentManagement;
using UnityEngine;

namespace Scripts.GameScripts
{
    public class TargetFrameManager : BaseComponent
    {
        [SerializeField]
        private int targetFrameRate;

        private void Awake()
        {
            Application.targetFrameRate = targetFrameRate;
        }
    }
}
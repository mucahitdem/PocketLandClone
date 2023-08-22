using System;

namespace Scripts.GameScripts.GameStateManagement
{
    public static class GameStateActionManager
    {
        public static Action onStartState;
        public static Action onPlayingState;
        public static Action onLoseState;
        public static Action onWinState;
    }
}
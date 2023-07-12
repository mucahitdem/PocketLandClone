using System;

namespace Scripts.BaseGameScripts.CoinControl
{
    public static class CoinActionManager
    {
        public static Action<float> onGainedCoin;
        public static Func<bool> spendCoinIfEnough;
    }
}
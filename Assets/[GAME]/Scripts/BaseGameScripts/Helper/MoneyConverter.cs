using System;
using System.Globalization;

namespace Scripts.BaseGameScripts.Helper
{
    public static class MoneyConverter
    {
        private static readonly string[] s_suffixes = {"", "k", "M", "G"};
        private static string s_text;

        public static string CurrencyConvert(float cash)
        {
            int k;
            if (Math.Abs(cash) < 0.001f)
                k = 0; // log10 of 0 is not valid
            else
                k = (int) (Math.Log10(cash) / 3); // get number of digits and divide by 3

            var divider = Math.Pow(10, k * 3); // actual number we print
            var money = cash / divider;
            var moneyInt = (int) money;

            if (Math.Abs(moneyInt - money) < 0.0001f)
                s_text = moneyInt.ToString(CultureInfo.InvariantCulture) + s_suffixes[k];
            else
                s_text = money.ToString("F0", new CultureInfo("en-US")) + s_suffixes[k];


            return s_text;
        }
    }
}
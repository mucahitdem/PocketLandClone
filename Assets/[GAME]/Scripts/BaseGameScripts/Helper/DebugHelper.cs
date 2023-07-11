using UnityEngine;

namespace Scripts.BaseGameScripts.Helper
{
    public static class DebugHelper
    {
        public static void LogRed(string message)
        {
            LogWithColor(message, "red");
        }

        public static void LogGreen(string message)
        {
            LogWithColor(message, "green");
        }

        public static void LogYellow(string message)
        {
            LogWithColor(message, "yellow");
        }

        private static void LogWithColor(string message, string color)
        {
            Debug.Log("<b><color=" + color + ">" + message + "</color></b>");
        }
    }
}
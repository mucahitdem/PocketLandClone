#if UNITY_EDITOR
using UnityEditor;

namespace Scripts.GameScripts
{
    public static class DefineSymbolsManager
    {
        public static void AddDefineSymbol(string symbol)
        {
            string defineSymbols = PlayerSettings.GetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup);

            if (!defineSymbols.Contains(symbol))
            {
                defineSymbols += ";" + symbol;
                PlayerSettings.SetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup, defineSymbols);
                AssetDatabase.Refresh();
            }
        }
        public static void RemoveDefineSymbol(string symbol)
        {
            string defineSymbols = PlayerSettings.GetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup);

            if (defineSymbols.Contains(symbol))
            {
                defineSymbols = defineSymbols.Replace(symbol, "");
                defineSymbols = defineSymbols.Replace(";;", ";"); // Remove any duplicate semicolons if present.
                PlayerSettings.SetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup, defineSymbols);
                AssetDatabase.Refresh();
            }
        }
    }
}
#endif

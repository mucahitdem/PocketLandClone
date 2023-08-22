using System.IO;
using UnityEditor;

namespace Scripts.GameScripts.DevHelperTools.Editor
{
    public class ScriptCreatorEditor : EditorWindow
    {
        [MenuItem("Custom/Create C# Script")]
        public static void CreateNewScript()
        {
            var scriptName = "NewScript"; // Default name for the new script
            var scriptTemplate = GetScriptTemplate(); // Get the C# script template

            // Create a new C# script and save it in the Assets folder
            var newScriptPath = Path.Combine("Assets", scriptName + ".cs");
            File.WriteAllText(newScriptPath, scriptTemplate);

            // Refresh the Asset Database so Unity recognizes the new script
            AssetDatabase.Refresh();

            // Select the new script in the Project window
            Selection.activeObject = AssetDatabase.LoadAssetAtPath<MonoScript>(newScriptPath);
        }

        // The C# script template we want to use
        private static string GetScriptTemplate()
        {
            return @"
using UnityEngine;

public class #SCRIPTNAME# : MonoBehaviour
{
    // Add your script logic here

    // #SCRIPTNAME# is replaced by the actual script name when the script is created
}";
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Scripts.GameScripts.DevHelperTools.Editor
{
    public class ScriptGeneratorWindow : EditorWindow
    {
        private string[] baseTypeNames;

        private string[] derivedTypeNames;
        private string scriptName = "NewScript";

        private readonly string scriptTemplate = @"
using UnityEngine;

namespace #NAMESPACE#
{
    public class #SCRIPTNAME# : #BASETYPE#
    {
        // Add your script logic here

        // #SCRIPTNAME# is replaced by the actual script name when the script is created
    }
}";

        private int selectedBaseTypeIndex;
        private int selectedDerivedTypeIndex;

        private Object selectedFolder;

        [MenuItem("Window/Script Generator")]
        public static void ShowWindow()
        {
            GetWindow<ScriptGeneratorWindow>("Script Generator");
        }

        private void OnEnable()
        {
            // Get all available MonoBehaviour derived types
            var derivedTypes = ReflectionUtility.GetDerivedTypes(typeof(MonoBehaviour));
            derivedTypeNames = new string[derivedTypes.Length];
            for (var i = 0; i < derivedTypes.Length; i++)
                derivedTypeNames[i] = derivedTypes[i].Name; // Use the class name only

            // Get all available MonoBehaviour base types
            var baseTypeList = new List<string>();
            baseTypeList.Add("MonoBehaviour"); // Default base type
            foreach (var derivedType in derivedTypes)
            {
                var baseType = derivedType.BaseType;
                while (baseType != null && baseType != typeof(MonoBehaviour))
                {
                    baseTypeList.Add(baseType.Name); // Use the class name only
                    baseType = baseType.BaseType;
                }
            }

            baseTypeNames = baseTypeList.ToArray();
        }

        private void OnGUI()
        {
            GUILayout.Label("Create C# Script", EditorStyles.boldLabel);

            scriptName = EditorGUILayout.TextField("Script Name", scriptName);

            // Display a dropdown menu for selecting the derived type
            selectedDerivedTypeIndex =
                EditorGUILayout.Popup("Derived Type", selectedDerivedTypeIndex, derivedTypeNames);

            // Display a dropdown menu for selecting the base type
            selectedBaseTypeIndex = EditorGUILayout.Popup("Base Type", selectedBaseTypeIndex, baseTypeNames);

            selectedFolder = EditorGUILayout.ObjectField("Destination Folder", selectedFolder, typeof(Object), false);

            EditorGUILayout.Space();

            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Select Folder")) ShowFolderSelectionDialog();

            if (GUILayout.Button("Create Script")) CreateNewScript();
            EditorGUILayout.EndHorizontal();
        }

        private void CreateNewScript()
        {
            // Get the selected derived type
            var selectedDerivedType = Type.GetType("UnityEngine." + derivedTypeNames[selectedDerivedTypeIndex]);

            // Get the selected base type
            var selectedBaseType = Type.GetType("UnityEngine." + baseTypeNames[selectedBaseTypeIndex]);

            // Replace #SCRIPTNAME# with the actual script name
            var scriptContent = scriptTemplate.Replace("#SCRIPTNAME#", scriptName);

            // Replace #NAMESPACE# with the actual namespace based on the selected derived type
            var namespaceName = selectedDerivedType.Namespace;
            scriptContent = scriptContent.Replace("#NAMESPACE#", namespaceName);

            // Replace #BASETYPE# with the actual base type
            var baseTypeName = selectedBaseType.Name;
            scriptContent = scriptContent.Replace("#BASETYPE#", baseTypeName);

            // Create a new C# script and save it in the destination folder
            var folderPath = AssetDatabase.GetAssetPath(selectedFolder);
            var newScriptPath = Path.Combine(folderPath, scriptName + ".cs");
            File.WriteAllText(newScriptPath, scriptContent);

            // Refresh the Asset Database so Unity recognizes the new script
            AssetDatabase.Refresh();

            // Load the new script as a MonoScript
            var newScript = AssetDatabase.LoadAssetAtPath<MonoScript>(newScriptPath);

            // Select the new script in the Project window
            Selection.activeObject = newScript;

            // Close the window
            Close();
        }

        private void ShowFolderSelectionDialog()
        {
            var folderPath = EditorUtility.OpenFolderPanel("Select Folder", "Assets", "");
            if (!string.IsNullOrEmpty(folderPath)) selectedFolder = AssetDatabase.LoadAssetAtPath<Object>(folderPath);
        }
    }

// Helper class for reflection
    public static class ReflectionUtility
    {
        public static Type[] GetDerivedTypes(Type baseType)
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => baseType.IsAssignableFrom(p) && p.IsClass && !p.IsAbstract)
                .ToArray();
        }
    }
}
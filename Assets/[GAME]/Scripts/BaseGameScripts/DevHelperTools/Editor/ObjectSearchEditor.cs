using System.Text;
using UnityEditor;
using UnityEngine;

public class ObjectSearchEditor : EditorWindow
{
    private GameObject[] allObjects;
    private GameObject[] matchingObjects;
    private string searchQuery = "";

    [MenuItem("Window/Object Search")]
    public static void ShowWindow()
    {
        GetWindow<ObjectSearchEditor>("Object Search");
    }

    private void OnGUI()
    {
        GUILayout.Label("Enter Search Query (Type 't:' for Components)", EditorStyles.boldLabel);
        searchQuery = EditorGUILayout.TextField(searchQuery);

        SearchObjectsByName(searchQuery);

        GUILayout.Space(10);

        // List the matching objects and their components
        if (matchingObjects != null && matchingObjects.Length > 0)
        {
            GUILayout.Label("Matching Objects:", EditorStyles.boldLabel);

            foreach (var obj in matchingObjects)
                if (GUILayout.Button(GetButtonLabel(obj)))
                    Selection.activeObject = obj;
        }
        else
        {
            GUILayout.Label("No objects found matching the search query.", EditorStyles.boldLabel);
        }
    }

    private string GetButtonLabel(GameObject obj)
    {
        var objectName = obj.name;

        if (searchQuery.StartsWith("t:"))
        {
            // Show matching components and derived components
            var components = obj.GetComponents<Component>();
            var labelBuilder = new StringBuilder(objectName);

            var remainingWidth =
                position.width - GUI.skin.button.CalcSize(new GUIContent(objectName)).x - 30f; // 30f: For padding

            foreach (var component in components)
                if (component != null && IsComponentMatchingSearch(component, searchQuery.Remove(0, 2).ToLower()))
                {
                    var componentName = "[" + component.GetType().Name + "]";
                    var componentWidth = GUI.skin.button.CalcSize(new GUIContent(componentName)).x;

                    if (remainingWidth >= componentWidth)
                    {
                        labelBuilder.Append(" " + componentName);
                        remainingWidth -= componentWidth + 5f; // 5f: For spacing between component names
                    }
                    else
                    {
                        break;
                    }
                }

            return labelBuilder.ToString();
        }

        return objectName;
    }

    private bool IsComponentMatchingSearch(Component component, string searchQuery)
    {
        var componentType = component.GetType();

        while (componentType != null)
        {
            if (componentType.Name.ToLower().Contains(searchQuery)) return true;

            componentType = componentType.BaseType;
        }

        return false;
    }

    private void SearchObjectsByName(string query)
    {
        allObjects = Resources.FindObjectsOfTypeAll<GameObject>();
        matchingObjects = new GameObject[0];

        var searchComponents = false;
        if (query.StartsWith("t:"))
        {
            query = query.Remove(0, 2);
            searchComponents = true;
        }

        foreach (var obj in allObjects)
            if (obj.scene.IsValid())
            {
                if (searchComponents)
                {
                    var components = obj.GetComponents<Component>();
                    foreach (var component in components)
                        if (component != null && IsComponentMatchingSearch(component, query.ToLower()))
                        {
                            ArrayUtility.Add(ref matchingObjects, obj);
                            break;
                        }
                }
                else
                {
                    if (obj.name.ToLower().Contains(query.ToLower())) ArrayUtility.Add(ref matchingObjects, obj);
                }
            }
    }
}
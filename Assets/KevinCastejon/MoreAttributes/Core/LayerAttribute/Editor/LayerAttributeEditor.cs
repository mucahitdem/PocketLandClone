using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(LayerAttribute))]
internal class LayerAttributeEditor : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (property.propertyType != SerializedPropertyType.Integer)
        {
            Debug.LogWarning("Layer attribute must be used with 'int' property type");
            base.OnGUI(position, property, label);
            return;
        }

        property.intValue = EditorGUI.LayerField(position, label, property.intValue);
    }
}
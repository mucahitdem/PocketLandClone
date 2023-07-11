//-----------------------------------------------------------------------
// <copyright file="Vector2IntMinMaxAttributeDrawer.cs" company="Sirenix IVS">
// Copyright (c) Sirenix IVS. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Sirenix.OdinInspector.Editor.ValueResolvers;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR && UNITY_2017_2_OR_NEWER

namespace Sirenix.OdinInspector.Editor.Drawers
{
    /// <summary>
    ///     Draws Vector2Int properties marked with <see cref="MinMaxSliderAttribute" />.
    /// </summary>
    public class Vector2IntMinMaxAttributeDrawer : OdinAttributeDrawer<MinMaxSliderAttribute, Vector2Int>
    {
        private ValueResolver<float> maxGetter;
        private ValueResolver<float> minGetter;
        private ValueResolver<Vector2Int> vector2IntMinMaxGetter;

        /// <summary>
        ///     Initializes the drawer by resolving any optional references to members for min/max value.
        /// </summary>
        protected override void Initialize()
        {
            // Min member reference.
            minGetter = ValueResolver.Get(Property, Attribute.MinValueGetter, Attribute.MinValue);
            maxGetter = ValueResolver.Get(Property, Attribute.MaxValueGetter, Attribute.MaxValue);

            // Min max member reference.
            if (Attribute.MinMaxValueGetter != null)
                vector2IntMinMaxGetter = ValueResolver.Get<Vector2Int>(Property, Attribute.MinMaxValueGetter);
        }

        /// <summary>
        ///     Draws the property.
        /// </summary>
        protected override void DrawPropertyLayout(GUIContent label)
        {
            ValueResolver.DrawErrors(minGetter, maxGetter, vector2IntMinMaxGetter);

            // Get the range of the slider from the attribute or from member references.
            Vector2 range;
            if (vector2IntMinMaxGetter != null && !vector2IntMinMaxGetter.HasError)
            {
                range = vector2IntMinMaxGetter.GetValue();
            }
            else
            {
                range.x = minGetter.GetValue();
                range.y = maxGetter.GetValue();
            }

            EditorGUI.BeginChangeCheck();
            var value = SirenixEditorFields.MinMaxSlider(label, ValueEntry.SmartValue, range, Attribute.ShowFields);
            if (EditorGUI.EndChangeCheck()) ValueEntry.SmartValue = new Vector2Int((int) value.x, (int) value.y);
        }
    }
}
#endif // UNITY_EDITOR && UNITY_2017_2_OR_NEWER
﻿//Cristian Pop - https://boxophobic.com/

using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class PolyverseSkiesShaderGUI : ShaderGUI
{
    private bool multiSelection;

    public override void OnGUI(MaterialEditor materialEditor, MaterialProperty[] props)
    {
        //base.OnGUI(materialEditor, props);

        var material0 = materialEditor.target as Material;
        var materials = materialEditor.targets;

        if (materials.Length > 1)
            multiSelection = true;

        DrawDynamicInspector(material0, materialEditor, props);
    }

    private void DrawDynamicInspector(Material material, MaterialEditor materialEditor, MaterialProperty[] props)
    {
        var customPropsList = new List<MaterialProperty>();

        if (multiSelection)
            for (var i = 0; i < props.Length; i++)
            {
                var prop = props[i];

                if (prop.flags == MaterialProperty.PropFlags.HideInInspector)
                    continue;

                customPropsList.Add(prop);
            }
        else
            for (var i = 0; i < props.Length; i++)
            {
                var prop = props[i];

                if (prop.flags == MaterialProperty.PropFlags.HideInInspector) continue;

                if (material.HasProperty("_BackgroundMode"))
                {
                    if (material.GetInt("_BackgroundMode") == 0 && prop.name == "_BackgroundCubemapSpace")
                        continue;

                    if (material.GetInt("_BackgroundMode") == 0 && prop.name == "_BackgroundCubemap")
                        continue;

                    if (material.GetInt("_BackgroundMode") == 0 && prop.name == "_BackgroundExposure")
                        continue;

                    if (material.GetInt("_BackgroundMode") == 1 && prop.name == "_SkyColor")
                        continue;

                    if (material.GetInt("_BackgroundMode") == 1 && prop.name == "_EquatorColor")
                        continue;

                    if (material.GetInt("_BackgroundMode") == 1 && prop.name == "_GroundColor")
                        continue;

                    if (material.GetInt("_BackgroundMode") == 1 && prop.name == "_EquatorHeight")
                        continue;

                    if (material.GetInt("_BackgroundMode") == 1 && prop.name == "_EquatorSmoothness")
                        continue;
                }

                customPropsList.Add(prop);
            }

        //Draw Custom GUI
        for (var i = 0; i < customPropsList.Count; i++)
        {
            var prop = customPropsList[i];

            if (prop.type == MaterialProperty.PropType.Texture)
            {
                EditorGUI.BeginChangeCheck();

                EditorGUI.showMixedValue = prop.hasMixedValue;

                Texture tex = null;

                if (prop.textureDimension == TextureDimension.Tex2D)
                    tex = (Texture2D) EditorGUILayout.ObjectField(prop.displayName, prop.textureValue,
                        typeof(Texture2D), false, GUILayout.Height(50));

                if (prop.textureDimension == TextureDimension.Cube)
                    tex = (Cubemap) EditorGUILayout.ObjectField(prop.displayName, prop.textureValue, typeof(Cubemap),
                        false, GUILayout.Height(50));

                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck()) prop.textureValue = tex;
            }
            else
            {
                materialEditor.ShaderProperty(customPropsList[i], customPropsList[i].displayName);
            }
        }

        GUILayout.Space(10);
    }
}
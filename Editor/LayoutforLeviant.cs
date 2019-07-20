﻿//Made by Aidan.ogg#0001 for Leviant#8796
using UnityEditor;
using UnityEngine;

public static class LayoutforLeviant
{
    public static void Initialize(Material material)
    {
        FoldoutforLeviant.Initialize(material);
    }

    public static bool BeginFold(int bit, string label)
    {
        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
        GUILayout.Space(3);
        EditorGUI.indentLevel++;

        FoldoutforLeviant fold = FoldoutforLeviant.Get(bit);
        bool foldState = EditorGUI.Foldout(EditorGUILayout.GetControlRect(),
            fold.state, label, true);
        fold.state = foldState;

        EditorGUI.indentLevel--;
        if (foldState) GUILayout.Space(5);

        EditorGUILayout.BeginHorizontal();
        GUILayout.Space(1);
        EditorGUILayout.BeginVertical();

        return foldState;
    }

    public static void EndFold()
    {
        EditorGUILayout.EndVertical();
        GUILayout.Space(1);
        EditorGUILayout.EndHorizontal();

        GUILayout.Space(3);
        //EditorGUI.indentLevel--;
        EditorGUILayout.EndVertical();
        GUILayout.Space(0);
    }
}

using Assets.BattleBots.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Armature))]
public class ArmatureInspectorGUI : Editor
{
    SerializedProperty name;
    SerializedProperty Slot;
    SerializedProperty Rarity;

    void OnEnable()
    {
        // Setup the SerializedProperties.
        name = serializedObject.FindProperty("name");
        Slot = serializedObject.FindProperty("Slot");
        Rarity = serializedObject.FindProperty("Rarity");
    }

    public override void OnInspectorGUI()
    {
        
    }
}

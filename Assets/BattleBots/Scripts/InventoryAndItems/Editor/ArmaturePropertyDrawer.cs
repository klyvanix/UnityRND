using Assets.BattleBots.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

#if true
[CustomPropertyDrawer(typeof(Armature))]
public class ArmaturePropertyDrawer : PropertyDrawer
{
    public override VisualElement CreatePropertyGUI(SerializedProperty property)
    {
        var root = new VisualElement();

        var container = new VisualElement();

        // Create property fields.
        var name = new PropertyField(property.FindPropertyRelative("name"));
        var visualSprite = new PropertyField(property.FindPropertyRelative("visualSprite"));

        // Add fields to the container.
        container.Add(name);
        container.Add(visualSprite);

        var foldout = new Foldout() { viewDataKey = "ArmatureFullInspectorFoldout", text = "FullInspector" };
        root.Add(foldout);
        return root;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        var amountRect = new Rect(position.x, position.y, 30, position.height);
        var unitRect = new Rect(position.x + 35, position.y, 50, position.height);
        var nameRect = new Rect(position.x + 90, position.y, position.width - 90, position.height);

        EditorGUI.PropertyField(amountRect, property.FindPropertyRelative("name"), GUIContent.none);
        EditorGUI.PropertyField(unitRect, property.FindPropertyRelative("visualSprite"), GUIContent.none);

        EditorGUI.EndProperty();
    }
}
#endif

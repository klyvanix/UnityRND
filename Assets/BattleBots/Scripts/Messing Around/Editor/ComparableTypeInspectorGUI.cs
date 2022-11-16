using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Assets.Experimentation;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

[CustomPropertyDrawer(typeof(ComparableType))]
public class ComparableTypeInspectorGUI : PropertyDrawer
{
    public override VisualElement CreatePropertyGUI(SerializedProperty property)
    {
        var container = new VisualElement();

        var amountField = new PropertyField(property.FindPropertyRelative("value"));
        var checkMark = new PropertyField(property.FindPropertyRelative("test"));
        var text = new PropertyField(property.FindPropertyRelative("text"));
        var list = new PropertyField(property.FindPropertyRelative("intList"));
        var Armature = new PropertyField(property.FindPropertyRelative("Armature"));
        var Armor = new PropertyField(property.FindPropertyRelative("Armor"));

        container.Add(amountField);
        container.Add(checkMark);
        container.Add(text);
        container.Add(list);
        container.Add(Armature);
        container.Add(Armor);

        return container;
    }
}

using Assets.BattleBots.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

#if false
[CustomPropertyDrawer(typeof(Armature))]
public class ArmaturePropertyDrawer : PropertyDrawer
{
    private float lineHeight = 20f;

    private HeaderAttribute header;

    public override VisualElement CreatePropertyGUI(SerializedProperty property)
    {
        var root = new VisualElement();

        var container = new VisualElement();

        // Create property fields.
        var name = new PropertyField(property.FindPropertyRelative("name"));
        var visualSprite = new PropertyField(property.FindPropertyRelative("visualSprite"));


        var price = new PropertyField(property.FindPropertyRelative("price"));
        var baseDamage = new PropertyField(property.FindPropertyRelative("baseDamage"));
        var Type = new PropertyField(property.FindPropertyRelative("Type"));
        var Range = new PropertyField(property.FindPropertyRelative("Range"));
        var Slot = new PropertyField(property.FindPropertyRelative("Slot"));
        var Rarity = new PropertyField(property.FindPropertyRelative("Rarity"));
        var Element = new PropertyField(property.FindPropertyRelative("Element"));

        // Add fields to the container.
        container.Add(name);
        container.Add(visualSprite); 
        container.Add(price);
        container.Add(baseDamage);
        container.Add(Type);
        container.Add(Range);
        container.Add(Slot);
        container.Add(Rarity);
        container.Add(Element);

        //var foldout = new Foldout() { viewDataKey = "ArmatureFullInspectorFoldout", text = "FullInspector" };
        //root.Add(foldout);
        return root;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        var spriteRect = new Rect(position.x, position.y, 50, lineHeight);
        var nameRect = new Rect(position.x + 55, position.y, position.width - 55, lineHeight);
        position.y += lineHeight;
        var headerRect = new Rect(position.x, position.y, position.width, lineHeight);


        EditorGUI.PropertyField(nameRect, property.FindPropertyRelative("name"), GUIContent.none);
        EditorGUI.PropertyField(spriteRect, property.FindPropertyRelative("visualSprite"), GUIContent.none);
        //EditorGUI.BeginFoldoutHeaderGroup();

        //var amountRect = new Rect(position.x, position.y, 30, position.height);
        //var unitRect = new Rect(position.x + 35, position.y, 50, position.height);
        //var nameRect = new Rect(position.x + 90, position.y, position.width - 90, position.height);

        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return lineHeight * 5;
    }
}
#endif

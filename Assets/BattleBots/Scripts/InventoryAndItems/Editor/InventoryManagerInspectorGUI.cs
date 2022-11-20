using Assets.BattleBots.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(InventoryManager))]
public class InventoryManagerInspectorGUI : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var InventoryManager = (InventoryManager)target;

        if(GUILayout.Button("Equip Random Armature To Random Slot"))
        {
            InventoryManager.PlayerInventory.replacementArmatureIndex = InventoryManager.SelectRandomArmatureIndex();
            //Populate Data and then Raise the Event.
            InventoryManager.Register();
            InventoryManager.EquipArmatureEvent.TriggerEvent();
            InventoryManager.Unregister();
        }

        if (GUILayout.Button("Equip Random Armor To Random Slot"))
        {
            InventoryManager.PlayerInventory.replacementArmorIndex = InventoryManager.SelectRandomArmorIndex();
            //Populate Data and then Raise the Event.
            InventoryManager.Register();
            InventoryManager.EquipArmorEvent.TriggerEvent();
            InventoryManager.Unregister();

        }
    }
}

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
            var ArmatureIndex = InventoryManager.SelectRandomArmatureIndex();
            ArmatureVariables.armatureIndex = ArmatureIndex;
            //ArmatureVariables.armature = InventoryManager.PlayerInventory.ArmatureList[ArmatureIndex];
            //Populate Data and then Raise the Event.
            InventoryManager.EquipArmatureEvent.TriggerEvent();
        }
    }
}

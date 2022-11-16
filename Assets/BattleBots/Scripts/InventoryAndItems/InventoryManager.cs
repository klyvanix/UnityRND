using Assets.BattleBots;
using Assets.BattleBots.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InventoryManager : MonoBehaviour
{
    public Inventory PlayerInventory;
    public Inventory PlayerBank;
    public BattleBotData BattleBotData;

    public EventObject EquipArmatureEvent;

    public int SelectRandomArmatureIndex()
    {
        if(PlayerInventory.ArmatureList.Count > 0)
            return UnityEngine.Random.Range(0, PlayerInventory.ArmatureList.Count);
        else
            return -1;
    }

    public void Awake()
    {
        EquipArmatureEvent.onEventTrigger += EquipArmatureEvent_onEventTrigger;
    }

    private void EquipArmatureEvent_onEventTrigger()
    {
        //grab a reference to the armature from the player inventory we want to equip.
        //check whether there is an open slot on the player armature slots.
        //if there is no armature equipped in the slot equip the armature from the slot and remove it from your inventory.
        //if there is an armature equipped in the slot remove the armature from the equipped slot and store it in inventory, then equip the armature into the slot.

        var armature = PlayerInventory.ArmatureList[ArmatureVariables.armatureIndex];
        if (BattleBotData.playerBot.isArmatureSlotEmpty(armature))
        {
            PlayerInventory.RemoveArmature(ArmatureVariables.armatureIndex);
            BattleBotData.playerBot.EquipArmatureToSlot(armature);
        }
        else
        {
            var equippedArmature = BattleBotData.playerBot.GetEquippedArmature((int)armature.Slot);
            PlayerInventory.AddArmature(equippedArmature);
            BattleBotData.playerBot.EquipArmatureToSlot(armature);
        }
    }
}

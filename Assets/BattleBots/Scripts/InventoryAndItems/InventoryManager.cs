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
    public EventObject EquipArmorEvent;

    //public int armatureIndex;

    public int SelectRandomArmatureIndex()
    {
        if(PlayerInventory.ArmatureList.Count > 0)
            return UnityEngine.Random.Range(0, PlayerInventory.ArmatureList.Count);

        return -1;
    }

    public int SelectRandomArmorIndex()
    {
        if(PlayerInventory.ArmorList.Count > 0)
            return UnityEngine.Random.Range(0, PlayerInventory.ArmorList.Count);

        return -1;
    }

    public void Register()
    {
        EquipArmatureEvent.onEventTrigger += EquipArmatureEvent_onEventTrigger;
        EquipArmorEvent.onEventTrigger += EquipArmorEvent_onEventTrigger;
    }

    public void Unregister()
    {
        EquipArmatureEvent.onEventTrigger -= EquipArmatureEvent_onEventTrigger;
        EquipArmorEvent.onEventTrigger -= EquipArmorEvent_onEventTrigger;
    }

    private void EquipArmatureEvent_onEventTrigger()
    {
        //grab a reference to the armature from the player inventory we want to equip.
        //check whether there is an open slot on the player armature slots.
        //if there is no armature equipped in the slot equip the armature from the slot and remove it from your inventory.
        //if there is an armature equipped in the slot remove the armature from the equipped slot and store it in inventory, then equip the armature into the slot.
        if (PlayerInventory.indexArmatureList == -1)
            return;

        var armature = PlayerInventory.ArmatureList[PlayerInventory.indexArmatureList];
        if (BattleBotData.playerBot.CheckIfArmatureSlotIsEmpty((int)armature.Slot))
        {
            BattleBotData.playerBot.EquipArmatureToSlot(armature);
            PlayerInventory.RemoveArmature(PlayerInventory.indexArmatureList);
        }
        else
        {
            var newArmature = BattleBotData.playerBot.FetchArmatureFromSlot((int)armature.Slot);
            PlayerInventory.AddArmature(newArmature);
            PlayerInventory.RemoveArmature(PlayerInventory.indexArmatureList);
            BattleBotData.playerBot.UnEquipArmatureFromSlot((int)armature.Slot);
            BattleBotData.playerBot.EquipArmatureToSlot(armature);
        }
    }

    private void EquipArmorEvent_onEventTrigger()
    {
        throw new NotImplementedException();
    }
}

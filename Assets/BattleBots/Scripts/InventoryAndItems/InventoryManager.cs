using Assets.BattleBots;
using Assets.BattleBots.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InventoryManager : MonoBehaviour
{
    [Header("PlayerData")]
    public Inventory PlayerInventory;
    public Inventory PlayerBank;
    public BattleBotData BattleBotData;
    [Header ("Events")]
    public EventObject EquipArmatureEvent;
    public EventObject EquipArmorEvent;

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
        //if there is an armature equipped in the slot remove the armature from the equipped slot and store it in inventory.
        //equip the armature into the slot.
        if (PlayerInventory.replacementArmatureIndex == -1)
            return;

        var armature = PlayerInventory.ArmatureList[PlayerInventory.replacementArmatureIndex];
        if (BattleBotData.playerBot.CheckIfArmatureSlotIsEmpty((int)armature.Slot))
        {
            BattleBotData.playerBot.EquipArmatureToSlot(armature);
            PlayerInventory.RemoveArmature(PlayerInventory.replacementArmatureIndex);
        }
        else
        {
            var newArmature = BattleBotData.playerBot.FetchArmatureFromSlot((int)armature.Slot);
            PlayerInventory.AddArmature(newArmature);
            PlayerInventory.RemoveArmature(PlayerInventory.replacementArmatureIndex);
            BattleBotData.playerBot.UnEquipArmatureFromSlot((int)armature.Slot);
            BattleBotData.playerBot.EquipArmatureToSlot(armature);
        }
    }

    private void EquipArmorEvent_onEventTrigger()
    {
        //grab a reference to the armor from the player inventory we want to equip.
        //check whether there is an open slot on the player armor slots.
        //if there is no armor equipped in the slot equip the armor from the slot and remove it from your inventory.
        //if there is an armor equipped in the slot remove the armor from the equipped slot and store it in inventory.
        //equip the armor into the slot.
        if (PlayerInventory.replacementArmorIndex == -1)
            return;

        var armor = PlayerInventory.ArmorList[PlayerInventory.replacementArmorIndex];
        if (BattleBotData.playerBot.CheckIfArmorSlotIsEmpty((int)armor.Slot))
        {
            BattleBotData.playerBot.EquipArmorToSlot(armor);
            PlayerInventory.RemoveArmor(PlayerInventory.replacementArmorIndex);
        }
        else
        {
            var newArmor = BattleBotData.playerBot.FetchArmorFromSlot((int)armor.Slot);
            PlayerInventory.AddArmor(newArmor);
            PlayerInventory.RemoveArmor(PlayerInventory.replacementArmorIndex);
            BattleBotData.playerBot.UnEquipArmorFromSlot((int)armor.Slot);
            BattleBotData.playerBot.EquipArmorToSlot(armor);
        }
        BattleBotData.playerBot.UpdateArmor();
    }
}

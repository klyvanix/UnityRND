using Assets.BattleBots.Scripts;
using System;
using UnityEngine;

[Serializable]
public class ArmorSlot
{
    [SerializeField]
    public Armor EquippedArmor;
    [SerializeField]
    private ArmorEquippedSlot SlotPosition;
    [SerializeField]
    private bool isEmpty;
    [SerializeField]
    private Sprite Image;

    public bool IsEmpty { get { return isEmpty; } }

    public ArmorSlot()
    {
        isEmpty = true;
        EquippedArmor = null;
        SlotPosition = ArmorEquippedSlot.UnEquipped;
    }

    public ArmorSlot(ArmorEquippedSlot slotPosition)
    {
        isEmpty = true;
        EquippedArmor = null;
        SlotPosition = slotPosition;
    }

    public void UnequipSlot()
    {
        EquippedArmor = null;
        isEmpty = true;
    }

    public void EquipSlot(Armor armor)
    {
        EquippedArmor = armor;
        EquippedArmor.isEquipped = true;
        isEmpty = false;
    }
}

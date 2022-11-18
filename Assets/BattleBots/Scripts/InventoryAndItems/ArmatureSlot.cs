using Assets.BattleBots.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ArmatureSlot
{
    [SerializeField]
    public Armature EquippedArmature;
    [SerializeField]
    private ArmatureEquippedSlot SlotPosition;
    [SerializeField]
    private bool isEmpty;
    [SerializeField]
    private Sprite Image;

    public bool IsEmpty { get { return isEmpty; } }

    public string Label
    {
        get
        {
            switch(SlotPosition)
            {
                case ArmatureEquippedSlot.Head:
                    return "Head";
                case ArmatureEquippedSlot.Arm:
                    return "Arm";
                case ArmatureEquippedSlot.Special:
                    return "Special";
                default:
                    return "";
            }
        }
    }

    public ArmatureSlot()
    {
        isEmpty = true;
        EquippedArmature = null;
        SlotPosition = ArmatureEquippedSlot.None;
    }
    public ArmatureSlot(ArmatureEquippedSlot slotPosition)
    {
        isEmpty = true;
        EquippedArmature = null;
        SlotPosition = slotPosition;
    }

    public void UnequipSlot()
    {
        EquippedArmature = null;
        isEmpty = true;
    }

    public void EquipSlot(Armature armature)
    {
        EquippedArmature = armature;
        EquippedArmature.isEquipped = true;
        isEmpty = false;
    }


}

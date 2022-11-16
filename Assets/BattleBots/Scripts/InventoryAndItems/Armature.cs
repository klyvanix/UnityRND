using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.BattleBots.Scripts
{
    [Serializable]
    public class Armature : EquipableItem
    {
        private int baseDamage;
        private bool isEquipped;
        private int equippedSlot;
        public ArmatureType Type;
        public ArmatureRange Range;
        public ArmatureEquippedSlot Slot;
        public EquipmentElementalType DamageType;

        [SerializeField]
        private int levelRequirement;

        public Armature(string name, 
                        int baseDmg, 
                        int levelRequired, 
                        int value,
                        ArmatureType type, 
                        ArmatureRange range, 
                        ArmatureEquippedSlot slot, 
                        EquipmentElementalType damageType, 
                        EquipmentRarity rarity)
        {
            nameOfInventoryItem = name;
            itemValue = value;
            Rarity = rarity;
            EquipmentType = EquipmentType.Armature;
            baseDamage = baseDmg;
            Type = type;
            Range = range;
            Slot = slot;
            DamageType = damageType;
            levelRequirement = levelRequired;

            equippedSlot = -1; 
            isEquipped = false;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.BattleBots.Scripts
{
    [Serializable]
    public class Armature
    {
        public string name;
        public int value;
        public int baseDamage;
        public Sprite visualSprite;
        public bool isEquipped;
        public ArmatureType Type;
        public ArmatureRange Range;
        public ArmatureEquippedSlot Slot;
        public EquipmentRarity Rarity;
        public EquipmentType EquipmentType;
        public EquipmentElementalType DamageType;

        [SerializeField]
        private int levelRequirement;

        public Armature(string name, 
                        int baseDmg, 
                        int levelRequired, 
                        int price,
                        ArmatureType type, 
                        ArmatureRange range, 
                        ArmatureEquippedSlot slot, 
                        EquipmentElementalType damageType, 
                        EquipmentRarity rarity)
        {
            this.name = name;
            this.value = price;
            Rarity = rarity;
            EquipmentType = EquipmentType.Armature;
            baseDamage = baseDmg;
            Type = type;
            Range = range;
            Slot = slot;
            DamageType = damageType;
            levelRequirement = levelRequired;
            isEquipped = false;
        }

        public Armature()
        {
            name = "";
            value = -1;
            Rarity = EquipmentRarity.Common;
            EquipmentType = EquipmentType.Armature;
            baseDamage = -1;
            Type = ArmatureType.None;
            Slot = ArmatureEquippedSlot.Arm;
        }

        public bool isEqual(Armature target)
        {
            if (this.name != target.name)
                return false;
            if (this.value != target.value)
                return false;
            if (this.Rarity != target.Rarity)
                return false;
            if (this.baseDamage != target.baseDamage)
                return false;
            if (this.Type != target.Type)
                return false;

            return true;
        }
    }
}
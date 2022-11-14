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
        [SerializeField]
        private string armatureName;
        [SerializeField]
        private int baseDamage;
        [SerializeField]
        private int itemValue;
        [SerializeField]
        private bool isEquipped;
        [SerializeField]
        private int equippedSlot;
        public ArmatureType Type;
        public ArmatureRange Range;
        public ArmatureEquippedSlot Slot;
        public ArmatureDamageType DamageType;
        public ItemRarity Rarity;

        [SerializeField]
        private int levelRequirement;

        public int BaseDamage { get => baseDamage; set => baseDamage = value; }
        public string ArmatureName { get => armatureName; set => armatureName = value; }
        public string LevelRequirement { get => armatureName; }
        public int Value { get => itemValue; set => itemValue = value; }
        public bool IsEquipped { get => isEquipped; set => isEquipped = value; }
        public int EquippedSlot { get => equippedSlot; set => equippedSlot = value; }

        public Armature()
        {
            armatureName = string.Empty;
            baseDamage = 0;
            Type = ArmatureType.None;
            Range = ArmatureRange.Default;
            Slot = ArmatureEquippedSlot.UnEquipped;
            DamageType = ArmatureDamageType.None;
            Rarity = ItemRarity.Common;
            isEquipped = false;
            equippedSlot = -1;
        }
        public Armature(string name, int baseDmg, int levelRequired, ArmatureType type, ArmatureRange range, ArmatureEquippedSlot slot, ArmatureDamageType damageType, ItemRarity rarity)
        {
            armatureName = name;
            baseDamage = baseDmg;
            levelRequirement = levelRequired;
            Type = type;
            Range = range;
            Slot = slot;
            DamageType = damageType;
            Rarity = rarity;
            isEquipped = false;
            equippedSlot = -1;
        }
    }
}

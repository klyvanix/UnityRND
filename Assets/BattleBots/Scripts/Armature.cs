using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.BattleBots.Scripts
{
    public enum ArmatureType
    {
        Gun,
        Melee,
        Sniper,
        Explosive,
        Default
    }

    public enum ArmatureRange
    {
        Close,
        Mid,
        Long,
        Default
    }

    public enum ArmatureSlotType
    {
        Head,
        Arm,
        Special,
        Default
    }

    public enum DamageType
    {
        Fire,
        Ice,
        Energy,
        Void,
        Nano,
        Default
    }

    public enum ArmatureRarity
    {
        Common,
        Uncommon,
        Rare,
        Exceptional,
        Exotic,
        Legendary,
        Default
    }

    [Serializable]
    public class Armature
    {
        [SerializeField]
        private string armatureName;
        [SerializeField]
        private int baseDamage;
        public ArmatureType Type;
        public ArmatureRange Range;
        public ArmatureSlotType Slot;
        public DamageType DamageType;
        public ArmatureRarity Rarity;

        [SerializeField]
        private int levelRequirement;

        public int BaseDamage { get => baseDamage; set => baseDamage = value; }
        public string ArmatureName { get => armatureName; set => armatureName = value; }
        public string LevelRequirement { get => armatureName; }

        public Armature()
        {
            armatureName = string.Empty;
            baseDamage = 0;
            Type = ArmatureType.Default;
            Range = ArmatureRange.Default;
            Slot = ArmatureSlotType.Default;
            DamageType = DamageType.Default;
            Rarity = ArmatureRarity.Default;
        }
        public Armature(string name, int baseDmg, int levelRequired, ArmatureType type, ArmatureRange range, ArmatureSlotType slot, DamageType damageType, ArmatureRarity rarity)
        {
            armatureName = name;
            baseDamage = baseDmg;
            levelRequirement = levelRequired;
            Type = type;
            Range = range;
            Slot = slot;
            DamageType = damageType;
            Rarity = rarity;
        }
    }
}

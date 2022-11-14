using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.BattleBots.Scripts
{
    public enum ArmatureType
    {
        Gun,
        Melee,
        Sniper,
        Explosive,
        None
    }

    public enum ArmatureRange
    {
        Close,
        Mid,
        Long,
        Default
    }

    public enum ArmatureEquippedSlot
    {
        Head,
        Arm,
        Special,
        UnEquipped
    }

    public enum ArmatureDamageType
    {
        Fire,
        Ice,
        Energy,
        Void,
        Nano,
        None
    }

    public enum ItemRarity
    {
        Common,
        Uncommon,
        Rare,
        Exceptional,
        Exotic,
        Legendary
    }

    public enum ArmorEquippedSlot
    {
        Body,
        Head,
        UnEquipped
    }
    public static class ArmatureVariables
    {
        public static List<string> ArmatureMeleeWeaponList = new List<string>() { "Knuckles", "Blade", "Hammer", "Sword", "Spike"};
        public static List<string> ArmatureGunWeaponList = new List<string>() { "Bolter", "Blaster", "Pistol"};
        public static List<string> ArmatureSniperWeaponList = new List<string>() { "Rifle", "Sniper", "Long Gun", "Cannon" };
        public static List<string> ArmatureExplosiveWeaponList = new List<string>() { "Rocket", "Explosive"};
        public static List<string> ArmatureProducerList = new List<string>() { "Delta Wolves", "Hypertrain", "Frostmoore", "Vectra", "Noral Industries" };
    }

    public static class ArmorVariables
    {

    }
}

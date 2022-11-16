using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.BattleBots.Scripts
{
    public enum EquipmentType
    {
        Armor,
        Armature,
        Consumable
    }

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
        Unassigned
    }

    public enum ArmatureEquippedSlot
    {
        Head = 0,
        Arm = 1,
        Special = 2,
        UnEquipped = 3
    }

    public enum EquipmentElementalType
    {
        Fire,
        Ice,
        Energy,
        Void,
        Nano,
        None
    }

    public enum EquipmentRarity
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
        Body = 0,
        Arm = 1,
        UnEquipped = 2
    }
    public static class ArmatureVariables
    {
        public static int numberOfArmatureSlots = 3;
        public static int armatureIndex = -1;
        public static Armature armature;

        public static List<string> ArmatureMeleeWeaponList = new List<string>() { "Knuckles", "Blade", "Hammer", "Sword", "Spike", "Hand", "Carver", "Grinder"};
        public static List<string> ArmatureGunWeaponList = new List<string>() { "Bolter", "Blaster", "Pistol", "Gun", "Shooter"};
        public static List<string> ArmatureSniperWeaponList = new List<string>() { "Rifle", "Sniper",  "Cannon", "Ballista"};
        public static List<string> ArmatureExplosiveWeaponList = new List<string>() { "Rocket", "Explosive"};
        public static List<string> ArmatureProducerList = new List<string>() { "Delta Wolves", "Frostmoore Corporation", "Vectra Fabricators", "Noral Industries" };
    }

    public static class ArmorVariables
    {
        public static int numberOfArmorSlots = 2;
        public static int armorIndex = -1;
        public static Armor armor;
    }

    public static class EquipmentVariables
    {
        public static int minBaseDamageValue = 8;
        public static int maxBaseDamageValue = 15;
    }
}

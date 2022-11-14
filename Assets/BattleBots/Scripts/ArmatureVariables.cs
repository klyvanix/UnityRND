using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.BattleBots.Scripts
{
    public static class ArmatureVariables
    {
        public static List<string> ArmatureMeleeWeaponList = new List<string>() { "Knuckles", "Blade", "Hammer", "Sword", "Spike"};
        public static List<string> ArmatureGunWeaponList = new List<string>() { "Bolter", "Blaster", "Pistol"};
        public static List<string> ArmatureSniperWeaponList = new List<string>() { "Rifle", "Sniper", "Long Gun", "Cannon" };
        public static List<string> ArmatureExplosiveWeaponList = new List<string>() { "Rocket", "Explosive"};
        public static List<string> ArmatureProducerList = new List<string>() { "Delta Wolves", "Hypertrain", "Frostmoore", "Vectra", "Noral Industries" };
    }
}

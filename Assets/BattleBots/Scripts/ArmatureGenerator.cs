using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.BattleBots.Scripts
{
    public static class ArmatureGenerator
    {
        private static Random randomSeed = new Random();

        private static int LengthOfArmatureTypeEnum
        {
            get { return Enum.GetNames(typeof(ArmatureType)).Length; }
        }
        private static int LengthOfArmatureRangeEnum
        {
            get { return Enum.GetNames(typeof(ArmatureType)).Length; }
        }

        private static int LengthOfDamageTypeEnum
        {
            get { return Enum.GetNames(typeof(DamageType)).Length; }
        }

        public static Armature GenerateArmature()
        {
            ArmatureType newArmatureType = GenerateNewArmatureTypeAttribute();
            ArmatureRange newArmaturerange = GenerateArmatureRangeAttribute(newArmatureType);
            ArmatureRarity newArmaturerarity = GenerateArmatureRarityAttribute();
            int newArmaturebaseDamage = GenerateBaseDamageAttribute(newArmaturerarity);
            DamageType newArmatureDamageType = GenerateDamageTypeAttribute();
            ArmatureSlotType newArmatureSlot = GenerateArmatureSlot(newArmatureType);
            string newArmatureName = GenerateArmatureName(newArmatureType, newArmatureDamageType, newArmatureSlot);
            return new Armature (newArmatureName, newArmaturebaseDamage, newArmatureType, newArmaturerange, newArmatureSlot, newArmatureDamageType, newArmaturerarity);
        }

        private static ArmatureType GenerateNewArmatureTypeAttribute()
        {
            //May refactor when we can verify the random seed doesn't go outside our range.
            ArmatureType returnType = ArmatureType.Default;
            while (returnType == ArmatureType.Default)
            {
                var randomValue = randomSeed.Next(0, LengthOfArmatureTypeEnum - 1);
                switch (randomValue)
                {
                    case 0:
                        returnType = ArmatureType.Gun;
                        break;
                    case 1:
                        returnType = ArmatureType.Melee;
                        break;
                    case 2:
                        returnType = ArmatureType.Sniper;
                        break;
                    case 3:
                        returnType = ArmatureType.Explosive;
                        break;
                    default:
                        returnType = ArmatureType.Default;
                        break;
                }
            }
            return returnType;
        }

        private static ArmatureRange GenerateArmatureRangeAttribute(ArmatureType type)
        {
            switch(type)
            {
                case ArmatureType.Sniper:
                    return ArmatureRange.Long;
                case ArmatureType.Melee:
                    return ArmatureRange.Close;
                case ArmatureType.Gun:
                    return GenerateGunRange();
                case ArmatureType.Explosive:
                    return GenerateGunRange();
                default:
                    return ArmatureRange.Mid;
            }
        }
        #region Range Helpers
        private static ArmatureRange GenerateGunRange()
        {
            switch(randomSeed.Next(0, LengthOfArmatureRangeEnum - 1)) 
            {
                case 0:
                    return ArmatureRange.Close;
                case 1:
                    return ArmatureRange.Mid;
                case 2:
                    return ArmatureRange.Long;
                default:
                    return ArmatureRange.Mid;
            }
        }
        #endregion

        private static ArmatureRarity GenerateArmatureRarityAttribute()
        {
            var seed = randomSeed.Next(0, 100);
            if (seed >= 0 && seed < 50)
                return ArmatureRarity.Common;
            else if (seed >= 50 && seed < 70)
                return ArmatureRarity.Uncommon;
            else if (seed >= 70 && seed < 85)
                return ArmatureRarity.Rare;
            else if (seed >= 85 && seed < 93)
                return ArmatureRarity.Exceptional;
            else if (seed >= 93 && seed < 99)
                return ArmatureRarity.Exotic;
            else
                return ArmatureRarity.Legendary;
        }

        private static int GenerateBaseDamageAttribute(ArmatureRarity rarity)
        {
            var seed = randomSeed.Next(5, 15);
            return seed * ((int)rarity + 1);
        }

        private static DamageType GenerateDamageTypeAttribute()
        {
            switch(randomSeed.Next(0, LengthOfDamageTypeEnum - 1))
            {
                case 0:
                    return DamageType.Fire;
                case 1:
                    return DamageType.Ice;
                case 2:
                    return DamageType.Energy;
                case 3:
                    return DamageType.Void;
                case 4:
                    return DamageType.Nano;
                default:
                    return DamageType.Fire;
            }
        }

        private static ArmatureSlotType GenerateArmatureSlot(ArmatureType newArmatureType)
        {
            if (newArmatureType == ArmatureType.Melee)
                return ArmatureSlotType.Arm;
            else if(newArmatureType == ArmatureType.Gun)
            {
                return ArmatureSlotType.Arm;
            }
            return ArmatureSlotType.Head;
        }

        private static string GenerateArmatureName(ArmatureType newArmatureType, DamageType newArmatureDamageType, ArmatureSlotType newArmatureSlot)
        {
            string returnString = "";
            switch(newArmatureDamageType)
            {
                case DamageType.Fire:
                    returnString += "Fire";
                    break;
                case DamageType.Ice:
                    returnString += "Icy";
                    break;
                case DamageType.Energy:
                    returnString += "Raging";
                    break;
                case DamageType.Void:
                    returnString += "Void";
                    break;
                case DamageType.Nano:
                    returnString += "Nano";
                    break;
            }

            switch(newArmatureType)
            {
                case ArmatureType.Melee:
                    returnString += GenerateMeleeWeaponName();
                    break;
                case ArmatureType.Sniper:
                    returnString += GenerateSniperWeaponName();
                    break;
                case ArmatureType.Gun:
                    returnString += GenerateGunWeaponName();
                    break;
                case ArmatureType.Explosive:
                    returnString += GenerateExplosiveWeaponName();
                    break;
                default:
                    break;
            }

            returnString += GenerateNameFlavorText();

            return returnString;
        }

        private static string GenerateMeleeWeaponName()
        {
            return " " + ArmatureVariables.ArmatureMeleeWeaponList[randomSeed.Next(0, ArmatureVariables.ArmatureMeleeWeaponList.Count)];
        }

        private static string GenerateGunWeaponName()
        {
            return " " + ArmatureVariables.ArmatureGunWeaponList[randomSeed.Next(0, ArmatureVariables.ArmatureGunWeaponList.Count)];
        }

        private static string GenerateSniperWeaponName()
        {
            return " " + ArmatureVariables.ArmatureSniperWeaponList[randomSeed.Next(0, ArmatureVariables.ArmatureSniperWeaponList.Count)];
        }

        private static string GenerateExplosiveWeaponName()
        {
            return " " + ArmatureVariables.ArmatureExplosiveWeaponList[randomSeed.Next(0, ArmatureVariables.ArmatureExplosiveWeaponList.Count)];
        }

        private static string GenerateNameFlavorText()
        {
            return "";
        }
    }
}

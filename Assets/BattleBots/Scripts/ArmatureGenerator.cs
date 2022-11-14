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
            get { return Enum.GetNames(typeof(ArmatureDamageType)).Length; }
        }

        public static Armature GenerateArmature()
        {
            ArmatureType newArmatureType = GenerateNewArmatureTypeAttribute();
            ArmatureRange newArmaturerange = GenerateArmatureRangeAttribute(newArmatureType);
            ItemRarity newArmaturerarity = GenerateArmatureRarityAttribute();
            int newArmaturebaseDamage = GenerateBaseDamageAttribute(newArmaturerarity);
            ArmatureDamageType newArmatureDamageType = GenerateDamageTypeAttribute();
            ArmatureEquippedSlot newArmatureSlot = GenerateArmatureSlot(newArmatureType);
            string newArmatureName = GenerateArmatureName(newArmatureType, newArmatureDamageType, newArmatureSlot);
            int levelRequirement = GenerateLevelRequirement(newArmaturerarity);
            return new Armature (newArmatureName, newArmaturebaseDamage, levelRequirement, newArmatureType, newArmaturerange, newArmatureSlot, newArmatureDamageType, newArmaturerarity);
        }

        private static ArmatureType GenerateNewArmatureTypeAttribute()
        {
            //May refactor when we can verify the random seed doesn't go outside our range.
            ArmatureType returnType = ArmatureType.None;
            while (returnType == ArmatureType.None)
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
                        returnType = ArmatureType.None;
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

        private static ItemRarity GenerateArmatureRarityAttribute()
        {
            var seed = randomSeed.Next(0, 100);
            if (seed >= 0 && seed < 50)
                return ItemRarity.Common;
            else if (seed >= 50 && seed < 70)
                return ItemRarity.Uncommon;
            else if (seed >= 70 && seed < 85)
                return ItemRarity.Rare;
            else if (seed >= 85 && seed < 93)
                return ItemRarity.Exceptional;
            else if (seed >= 93 && seed < 99)
                return ItemRarity.Exotic;
            else
                return ItemRarity.Legendary;
        }

        private static int GenerateBaseDamageAttribute(ItemRarity rarity)
        {
            var seed = randomSeed.Next(5, 15);
            return seed * ((int)rarity + 1);
        }

        private static ArmatureDamageType GenerateDamageTypeAttribute()
        {
            switch(randomSeed.Next(0, LengthOfDamageTypeEnum - 1))
            {
                case 0:
                    return ArmatureDamageType.Fire;
                case 1:
                    return ArmatureDamageType.Ice;
                case 2:
                    return ArmatureDamageType.Energy;
                case 3:
                    return ArmatureDamageType.Void;
                case 4:
                    return ArmatureDamageType.Nano;
                default:
                    return ArmatureDamageType.Fire;
            }
        }

        private static ArmatureEquippedSlot GenerateArmatureSlot(ArmatureType newArmatureType)
        {
            if (newArmatureType == ArmatureType.Melee)
                return ArmatureEquippedSlot.Arm;
            else if(newArmatureType == ArmatureType.Gun)
            {
                return ArmatureEquippedSlot.Arm;
            }
            return ArmatureEquippedSlot.Head;
        }
        #region Name Generation
        private static string GenerateArmatureName(ArmatureType newArmatureType, ArmatureDamageType newArmatureDamageType, ArmatureEquippedSlot newArmatureSlot)
        {
            string returnString = "";
            switch(newArmatureDamageType)
            {
                case ArmatureDamageType.Fire:
                    returnString += "Fire";
                    break;
                case ArmatureDamageType.Ice:
                    returnString += "Icy";
                    break;
                case ArmatureDamageType.Energy:
                    returnString += "Raging";
                    break;
                case ArmatureDamageType.Void:
                    returnString += "Void";
                    break;
                case ArmatureDamageType.Nano:
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
        #endregion

        private static int GenerateLevelRequirement(ItemRarity newArmaturerarity)
        {
            return 10 * ( 1 + ((int)newArmaturerarity)) + randomSeed.Next(0,10);
        }
    }
}

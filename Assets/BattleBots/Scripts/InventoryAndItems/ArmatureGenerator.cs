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
            get { return Enum.GetNames(typeof(EquipmentElementalType)).Length; }
        }

        public static Armature GenerateArmature()
        {
            ArmatureType newArmatureType = GenerateNewArmatureTypeAttribute();
            ArmatureRange newArmaturerange = GenerateArmatureRangeAttribute(newArmatureType);
            EquipmentRarity newArmaturerarity = GenerateArmatureRarityAttribute();
            int newArmaturebaseDamage = GenerateBaseDamageAttribute(newArmaturerarity);
            EquipmentElementalType newArmatureDamageType = GenerateDamageTypeAttribute();
            ArmatureEquippedSlot newArmatureSlot = GenerateArmatureSlot(newArmatureType);
            string newArmatureName = GenerateArmatureName(newArmatureType, newArmatureDamageType, newArmatureSlot);
            int levelRequirement = GenerateLevelRequirement(newArmaturerarity, newArmaturebaseDamage, newArmatureDamageType);
            return new Armature (newArmatureName, 
                                 newArmaturebaseDamage, 
                                 levelRequirement,
                                 100,
                                 newArmatureType, 
                                 newArmaturerange, 
                                 newArmatureSlot, 
                                 newArmatureDamageType, 
                                 newArmaturerarity);
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

        #region Range Generation
        private static ArmatureRange GenerateArmatureRangeAttribute(ArmatureType type)
        {
            switch (type)
            {
                case ArmatureType.Sniper:
                    return ArmatureRange.Long;
                case ArmatureType.Melee:
                    return ArmatureRange.Close;
                case ArmatureType.Gun:
                    return GenerateDynamicRange();
                case ArmatureType.Explosive:
                    return GenerateDynamicRange();
                default:
                    return ArmatureRange.Mid;
            }
        }
        private static ArmatureRange GenerateDynamicRange()
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

        private static EquipmentRarity GenerateArmatureRarityAttribute()
        {
            var seed = randomSeed.Next(0, 100);
            if (seed >= 0 && seed < 50)
                return EquipmentRarity.Common;
            else if (seed >= 50 && seed < 70)
                return EquipmentRarity.Uncommon;
            else if (seed >= 70 && seed < 85)
                return EquipmentRarity.Rare;
            else if (seed >= 85 && seed < 93)
                return EquipmentRarity.Exceptional;
            else if (seed >= 93 && seed < 99)
                return EquipmentRarity.Exotic;
            else
                return EquipmentRarity.Legendary;
        }

        private static int GenerateBaseDamageAttribute(EquipmentRarity rarity)
        {
            var seed = randomSeed.Next(EquipmentVariables.minBaseDamageValue, EquipmentVariables.maxBaseDamageValue);
            return seed * ((int)rarity + 1);
        }

        private static EquipmentElementalType GenerateDamageTypeAttribute()
        {
            var seed = randomSeed.Next(0, 13);
            if (seed < 4)
                return EquipmentElementalType.None;
            else if (seed < 6)
                return EquipmentElementalType.Fire;
            else if (seed < 9)
                return EquipmentElementalType.Ice;
            else if (seed < 11)
                return EquipmentElementalType.Energy;
            else if (seed < 12)
                return EquipmentElementalType.Nano;
            else
                return EquipmentElementalType.Void;
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
        private static string GenerateArmatureName(ArmatureType newArmatureType, EquipmentElementalType newArmatureDamageType, ArmatureEquippedSlot newArmatureSlot)
        {
            string returnString = "";

            returnString += string.Format("{0} ", ArmatureVariables.ArmatureProducerList[randomSeed.Next(0, ArmatureVariables.ArmatureProducerList.Count)]);

            switch(newArmatureDamageType)
            {
                case EquipmentElementalType.Fire:
                    returnString += "Firey ";
                    break;
                case EquipmentElementalType.Ice:
                    returnString += "Icy ";
                    break;
                case EquipmentElementalType.Energy:
                    returnString += "Electrifying ";
                    break;
                case EquipmentElementalType.Void:
                    returnString += "Void ";
                    break;
                case EquipmentElementalType.Nano:
                    returnString += "Nano ";
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
            return ArmatureVariables.ArmatureMeleeWeaponList[randomSeed.Next(0, ArmatureVariables.ArmatureMeleeWeaponList.Count)];
        }

        private static string GenerateGunWeaponName()
        {
            return ArmatureVariables.ArmatureGunWeaponList[randomSeed.Next(0, ArmatureVariables.ArmatureGunWeaponList.Count)];
        }

        private static string GenerateSniperWeaponName()
        {
            return ArmatureVariables.ArmatureSniperWeaponList[randomSeed.Next(0, ArmatureVariables.ArmatureSniperWeaponList.Count)];
        }

        private static string GenerateExplosiveWeaponName()
        {
            return ArmatureVariables.ArmatureExplosiveWeaponList[randomSeed.Next(0, ArmatureVariables.ArmatureExplosiveWeaponList.Count)];
        }

        private static string GenerateNameFlavorText()
        {
            return "";
        }
        #endregion

        #region Level Generation
        private static int GenerateLevelRequirement(EquipmentRarity newArmaturerarity, int newArmaturebaseDamage, EquipmentElementalType newArmatureDamageType)
        {
            return 10 * (((int)newArmaturerarity)) 
                + GenerateDamageLevelRequirement(newArmaturebaseDamage) 
                + GenerateElementalTypeLevelRequirement(newArmatureDamageType);
        }

        private static int GenerateDamageLevelRequirement(int newArmaturebaseDamage)
        {
            return newArmaturebaseDamage - EquipmentVariables.minBaseDamageValue;
        }

        private static int GenerateElementalTypeLevelRequirement(EquipmentElementalType newArmatureDamageType)
        {
            switch(newArmatureDamageType)
            {
                case EquipmentElementalType.Fire:
                    return 1;
                case EquipmentElementalType.Ice:
                    return 1;
                case EquipmentElementalType.Energy:
                    return 2;
                case EquipmentElementalType.Nano:
                    return 3;
                case EquipmentElementalType.Void:
                    return 4;
                default: 
                    return 0;
            }
        }
        #endregion
    }
}

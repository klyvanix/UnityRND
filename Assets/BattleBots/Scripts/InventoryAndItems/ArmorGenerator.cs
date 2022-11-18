using System;
using Random = UnityEngine.Random;

namespace Assets.BattleBots.Scripts
{
    public static class ArmorGenerator
    {
        private static int LengthOfArmorTypeEnum
        {
            get { return Enum.GetNames(typeof(ArmorSlotType)).Length; }
        }

        public static Armor GenerateArmor()
        {
            ArmorSlotType armorSlotType = GenerateArmorSlotType();
            EquipmentRarity rarity = GenerateArmatureRarityAttribute();
            EquipmentElementalType element = GenerateElementalType();
            int armorValue = GenerateArmorValue(rarity);
            int price = 100;
            int levelRequirement = GenerateLevelRequirement(rarity, armorValue, element);
            string name = GenerateArmorName(armorSlotType, element);
            return new Armor(name, armorValue, price, levelRequirement, rarity, element, armorSlotType);
        }

        private static ArmorSlotType GenerateArmorSlotType()
        {
            var seed = Random.Range(0, 10);
            if (seed < 6)
                return ArmorSlotType.Arm;
            else
                return ArmorSlotType.Body;
        }

        private static EquipmentRarity GenerateArmatureRarityAttribute()
        {
            var seed = Random.Range(0, 100);
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

        private static int GenerateArmorValue(EquipmentRarity rarity)
        {
            var seed = Random.Range(EquipmentVariables.minBaseArmorValue, EquipmentVariables.maxBaseArmorVlaue);
            return 10 + seed + (2 * (int)rarity + 1);
        }
        private static EquipmentElementalType GenerateElementalType()
        {
            var seed = Random.Range(0, 13);
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

        private static int GenerateLevelRequirement(EquipmentRarity rarity, 
                                                    int armorValue,
                                                    EquipmentElementalType element)
        {
            return 10 * (((int)rarity))
                + GenerateArmorValueLevelRequirement(armorValue)
                + GenerateElementalTypeLevelRequirement(element);
        }

        private static int GenerateArmorValueLevelRequirement(int armorValue)
        {
            return armorValue - EquipmentVariables.minBaseArmorValue;
        }

        private static int GenerateElementalTypeLevelRequirement(EquipmentElementalType elementalType)
        {
            switch (elementalType)
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

        private static string GenerateArmorName(ArmorSlotType armorSlotType, EquipmentElementalType element)
        {
            string returnString = "";
            returnString += string.Format("{0} ", ArmorVariables.ArmorProducerList[Random.Range(0, ArmorVariables.ArmorProducerList.Count)]);

            switch(armorSlotType)
            {
                case ArmorSlotType.Arm:
                    returnString += GenerateArmSlotName();
                    break;
                case ArmorSlotType.Body:
                    returnString += GenerateBodySlotName();
                    break;
            }

            returnString += GenerateFlavorText();

            return returnString;
        }

        private static string GenerateArmSlotName()
        {
            return string.Format("{0} ", ArmorVariables.ArmSlotTitles[Random.Range(0, ArmorVariables.ArmSlotTitles.Count)]);
        }

        private static string GenerateBodySlotName()
        {
            return string.Format("{0} ", ArmorVariables.BodySlotTitles[Random.Range(0, ArmorVariables.BodySlotTitles.Count)]);
        }

        private static string GenerateFlavorText()
        {
            return string.Format("{0} ", EquipmentVariables.FlavorText[Random.Range(0, EquipmentVariables.FlavorText.Count)]);
        }
    }
}

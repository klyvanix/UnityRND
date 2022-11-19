using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.BattleBots.Scripts
{
    [Serializable]
    public class Armor
    {
        public string name;
        public Sprite visualSprite;

        [Header("Attributes")]
        public int armorValue;
        public int price;
        public bool isEquipped;
        public EquipmentElementalType Element;
        public EquipmentRarity Rarity;
        public ArmorSlotType Slot;

        [Header("Type")]
        public EquipmentType EquipmentType;

        [SerializeField]
        private int levelRequirement;

        public Armor(string name,
                     int armorValue,
                     int price,
                     int levelRequirement,
                     EquipmentRarity rarity,
                     EquipmentElementalType element,
                     ArmorSlotType slot)
        {
            this.name = name;
            this.armorValue = armorValue;
            this.price = price;
            Rarity = rarity;
            Slot = slot;
            this.levelRequirement = levelRequirement;

            EquipmentType = EquipmentType.Armor;
            this.isEquipped = false;
        }

        public Armor()
        {
            name = "";
            price = -1;
            armorValue = -1;
            levelRequirement = -1;
            Rarity = EquipmentRarity.Common;
            EquipmentType = EquipmentType.Armor;
            Slot = ArmorSlotType.None;
            Element = EquipmentElementalType.None;
            this.isEquipped = false;
        }

        public bool isEqual(Armor target)
        {
            if (this.name != target.name)
                return false;
            if (this.price != target.price)
                return false;
            if (this.Rarity != target.Rarity)
                return false;

            return true;
        }
    }
}

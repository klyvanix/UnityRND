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
        public int armorValue;
        public int price;
        public Sprite visualSprite;
        public bool isEquipped;
        public EquipmentRarity Rarity;
        public EquipmentType EquipmentType;
        public ArmorEquippedSlot Slot;
    }
}

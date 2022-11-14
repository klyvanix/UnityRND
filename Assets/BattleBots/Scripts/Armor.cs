using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.BattleBots.Scripts
{
    [Serializable]
    public class Armor: EquipableItem
    {
        [SerializeField]
        private string armorName;
        [SerializeField]
        private int armorValue;
        [SerializeField]
        private int itemValue;
        [SerializeField]
        private bool isEquipped;
        [SerializeField]
        private int equippedSlot;
        public ItemRarity Rarity;
        public ArmorEquippedSlot Slot;

        public string Name { get => armorName; }
        public int ArmorValue { get => armorValue; }
        public int Value { get => itemValue; set => itemValue = value; }
        public bool IsEquipped { get => isEquipped; set => isEquipped = value; }
        public int EquippedSlot { get => equippedSlot; set => equippedSlot = value; }

        public Armor(string name, int armorValue, int monetaryValue,ItemRarity rarity, ArmorEquippedSlot slot)
        {
            armorName = name;
            this.armorValue = armorValue;
            itemValue = monetaryValue;
            Rarity = rarity;
            Slot = slot;
            isEquipped = false;
            equippedSlot = -1;
        }
    }
}

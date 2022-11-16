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
        public int armorValue;
        public ArmorEquippedSlot Slot;
    }
}

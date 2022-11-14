using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.BattleBots.Scripts
{
    internal interface EquipableItem
    {
        public int Value { get; set; }
        public bool IsEquipped { get; set; }
        public int EquippedSlot { get; set; }
    }
}

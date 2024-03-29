﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.BattleBots.Scripts
{
    public abstract class InventoryItem : ScriptableObject
    {
        public string itemName;
        public int itemValue;
        public EquipmentRarity Rarity;
        public EquipmentType EquipmentType;
        public Sprite visualSprite;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.BattleBots.Scripts
{
    [Serializable]
    public class BattleBot
    {
        [SerializeField]
        private string botName;
        [SerializeField]
        private int maxHealth;
        [SerializeField]
        private int armor;
        [SerializeField]
        private int energy;
        [SerializeField]
        private int accuracy;
        [SerializeField]
        private int speed;
        [SerializeField]
        private int strength;
        [SerializeField]
        private int focus;
        [SerializeField]
        private int level;
        [SerializeField]
        private Armature[] armatures;
        [SerializeField]
        private Armor[] armors;

        public string Name { get => botName; set => botName = value; }

        public int Health { get => maxHealth; set => maxHealth = value; }

        public int Armor { get => armor; set => armor = value; }

        public int Energy { get => energy; set => energy = value; }

        public int Accuracy { get => accuracy; set => accuracy = value; }

        public int Strength { get => strength; set => strength = value; }

        public int Speed { get => speed; set => speed = value; }

        public int Focus { get => focus; set => focus = value; }

        public int Level { get => level; set => level = value; }

        public BattleBot(string name, int health, int armor, int energy, int accuracy, int strength, int speed, int focus,int level)
        {
            botName = name;
            maxHealth = health;
            this.armor = armor;
            this.energy = energy;
            this.accuracy = accuracy;
            this.strength = strength;
            this.speed = speed;
            this.focus = focus;
            this.level = level;
            armatures = new Armature[ArmatureVariables.numberOfArmatureSlots];
            armors = new Armor[ArmorVariables.numberOfArmorSlots];
        }

        public BattleBot()
        {
            level = 1;
            maxHealth = 100;
            armor = 0;
            energy = 50;
            accuracy = 50;
            strength = 10;
            speed = 10;
            focus = 10;
            armatures = new Armature[ArmatureVariables.numberOfArmatureSlots];
            armors = new Armor[ArmorVariables.numberOfArmorSlots];
        }

        public void UnEquipArmatureFromSlot(int index)
        {
            if (armatures[index] != null)
                armatures[index] = null;
        }

        public void EquipArmatureToSlot(Armature armature)
        {
            var index = (int)armature.Slot;
            armatures[index] = armature;
        }

        public void EquipArmorToSlot(Armor armor)
        {
            //var index = (int)Armor.Slot;
            var index = 0;
            if (armors[index] == null)
                armors[index] = armor;
        }

        public void UnEquipArmorFromSlot(int index)
        {
            if(armors[index] != null)
                armors[index] = null;
        }

        internal bool isArmatureSlotEmpty(Armature armature)
        {
            if (armatures[(int)armature.Slot].nameOfInventoryItem == null)
                return true;

            return false;
        }

        internal Armature GetEquippedArmature(int value)
        {
            return armatures[value];
        }
    }
}

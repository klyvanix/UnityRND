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
        private int armorValue;
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

        public ArmatureSlot[] ArmatureSlots;
        public Armor[] armors;

        public string Name { get => botName; set => botName = value; }

        public int Health { get => maxHealth; set => maxHealth = value; }

        public int Armor { get => armorValue; set => armorValue = value; }

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
            this.armorValue = armor;
            this.energy = energy;
            this.accuracy = accuracy;
            this.strength = strength;
            this.speed = speed;
            this.focus = focus;
            this.level = level;
            ArmatureSlots = new ArmatureSlot[ArmatureVariables.numberOfArmatureSlots];
            armors = new Armor[ArmorVariables.numberOfArmorSlots];
        }

        public BattleBot()
        {
            level = 1;
            maxHealth = 100;
            armorValue = 0;
            energy = 50;
            accuracy = 50;
            strength = 10;
            speed = 10;
            focus = 10;
            ArmatureSlots = new ArmatureSlot[ArmatureVariables.numberOfArmatureSlots];
            armors = new Armor[ArmorVariables.numberOfArmorSlots];
        }

        public void InitializeSlots()
        {
            int i;
            for(i = 0; i < ArmatureVariables.numberOfArmatureSlots; i++)
            {
                ArmatureEquippedSlot slotPosition = ArmatureEquippedSlot.Unassigned;
                if (i == (int)ArmatureEquippedSlot.Head)
                    slotPosition = ArmatureEquippedSlot.Head;
                if(i == (int)ArmatureEquippedSlot.Arm)
                    slotPosition = ArmatureEquippedSlot.Arm;
                if (i == (int)ArmatureEquippedSlot.Special)
                    slotPosition = ArmatureEquippedSlot.Special;

                ArmatureSlots[i] = new ArmatureSlot(slotPosition);
            }
            for(i = 0; i < ArmorVariables.numberOfArmorSlots; i++)
            {
                ArmorEquippedSlot slotPosition = ArmorEquippedSlot.UnEquipped;
                if (i == (int)ArmorEquippedSlot.Arm)
                    slotPosition = ArmorEquippedSlot.Arm;
                if (i == (int)ArmorEquippedSlot.Body)
                    slotPosition = ArmorEquippedSlot.Body;
                //ArmorS
            }
        }

        public bool CheckIfArmatureSlotIsEmpty(int slotIndex)
        {
            return ArmatureSlots[slotIndex].IsEmpty;
        }

        public void UnEquipArmatureFromSlot(int index)
        {
            if (ArmatureSlots[index] != null)
                ArmatureSlots[index].UnequipSlot();
        }

        public Armature FetchArmatureFromSlot(int index)
        {
            if (ArmatureSlots[index] != null)
            {
                var armature = ArmatureSlots[index].EquippedArmature;
                armature.isEquipped = false;
                return armature;
            }
            return null;
        }

        public void EquipArmatureToSlot(Armature armature)
        {
            var index = (int)armature.Slot;
            ArmatureSlots[index].EquipSlot(armature);
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
    }
}

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
        private int maxHealth;
        [SerializeField]
        private int currentHealth;
        private int baseArmorValue;
        [SerializeField]
        private int currentArmorValue;
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
        public ArmorSlot[] ArmorSlots;

        public BattleBot(string name,
                         int health,
                         int armor,
                         int energy,
                         int accuracy,
                         int strength,
                         int speed,
                         int focus,
                         int level)
        {
            botName = name;
            maxHealth = health;
            this.baseArmorValue = armor;
            this.energy = energy;
            this.accuracy = accuracy;
            this.strength = strength;
            this.speed = speed;
            this.focus = focus;
            this.level = level;
            ArmatureSlots = new ArmatureSlot[ArmatureVariables.numberOfArmatureSlots];
            ArmorSlots = new ArmorSlot[ArmorVariables.numberOfArmorSlots];
        }

        public BattleBot()
        {
            level = 1;
            maxHealth = 100;
            baseArmorValue = 0;
            energy = 50;
            accuracy = 50;
            strength = 10;
            speed = 10;
            focus = 10;
            ArmatureSlots = new ArmatureSlot[ArmatureVariables.numberOfArmatureSlots];
            ArmorSlots = new ArmorSlot[ArmorVariables.numberOfArmorSlots];
        }

        public void InitializeSlots()
        {
            int i;
            for(i = 0; i < ArmatureVariables.numberOfArmatureSlots; i++)
            {
                ArmatureEquippedSlot armatureSlotPosition = ArmatureEquippedSlot.None;
                if (i == (int)ArmatureEquippedSlot.Head)
                    armatureSlotPosition = ArmatureEquippedSlot.Head;
                if(i == (int)ArmatureEquippedSlot.Arm)
                    armatureSlotPosition = ArmatureEquippedSlot.Arm;
                if (i == (int)ArmatureEquippedSlot.Special)
                    armatureSlotPosition = ArmatureEquippedSlot.Special;

                ArmatureSlots[i] = new ArmatureSlot(armatureSlotPosition);
            }

            for(i = 0; i < ArmorVariables.numberOfArmorSlots; i++)
            {
                ArmorSlotType armorSlotPosition = ArmorSlotType.None;
                if (i == (int)ArmorSlotType.Body)
                    armorSlotPosition = ArmorSlotType.Body;
                if (i == (int)ArmorSlotType.Arm)
                    armorSlotPosition = ArmorSlotType.Arm;

                ArmorSlots[i] = new ArmorSlot(armorSlotPosition);
            }
        }

        public bool CheckIfArmatureSlotIsEmpty(int slotIndex)
        {
            return ArmatureSlots[slotIndex].IsEmpty;
        }

        public bool CheckIfArmorSlotIsEmpty(int slotIndex)
        {
            return ArmorSlots[slotIndex].IsEmpty;
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

        public Armor FetchArmorFromSlot(int index)
        {
            if (ArmorSlots[index] != null)
            {
                var armor = ArmorSlots[index].EquippedArmor;
                armor.isEquipped = false;
                return armor;
            }
            return null;
        }

        public void EquipArmorToSlot(Armor armor)
        {
            var index = (int)armor.Slot;
            ArmorSlots[index].EquipSlot(armor);
        }

        public void UnEquipArmorFromSlot(int index)
        {
            if (ArmorSlots[index] != null)
                ArmorSlots[index].UnequipSlot();
        }

        public void UpdateArmor()
        {
            currentArmorValue = baseArmorValue;
            foreach(var armor in ArmorSlots)
            {
                if(armor.EquippedArmor.armorValue > 0)
                    currentArmorValue += armor.EquippedArmor.armorValue;
            }
        }
    }
}

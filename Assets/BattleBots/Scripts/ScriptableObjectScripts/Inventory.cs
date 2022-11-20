using Assets.BattleBots.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.BattleBots
{
    [CreateAssetMenu]
    public class Inventory : ScriptableObject
    {
        //These need to be dictionaries.
        public List<Armature> ArmatureList;
        public List<Armor> ArmorList;
        //public List<Consumable> ConsumableList;
        public int Slots;

        public Armature armature;
        public Armor armor;
        public int replacementArmatureIndex;
        public int replacementArmorIndex;

        //Inventory Manager would be responsible for checking whether there is room in the Inventory.
        public bool RoomInInventory
        {
            get
            {
                if (ArmatureList.Count + ArmorList.Count /* + ConsumableList.Count */ <= Slots)
                    return true;
                return false;
            }
        }

        public void AddArmature(Armature armature)
        {
            ArmatureList.Add(armature);
        }

        public void AddArmor(Armor armor)
        {
            ArmorList.Add(armor);
        }

        public void RemoveArmature(int index)
        {
            if (ArmatureList[index] != null)
                ArmatureList.RemoveAt(index);
        }

        public void RemoveArmor(int index)
        {
            if (ArmorList[index] != null)
                ArmorList.RemoveAt(index);
        }

        public void ResetInventory()
        {
            ArmatureList.Clear();
            ArmorList.Clear();

            Slots = 0;
            replacementArmatureIndex = 0;
            replacementArmorIndex = 0;
        }
    }
}

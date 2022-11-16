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
        public SerializableDictionary<int, Armature> ArmatureDictionary;
        public List<Armature> ArmatureList;
        public List<Armor> ArmorList;
        //public List<Consumable> ConsumableList;
        public int Slots;
        public int ArmatureListIndex;
        public int ArmorListIndex;


        public void RemoveArmature(int index)
        {
            if (ArmatureList[index] != null)
                ArmatureList.RemoveAt(index);
        }
        public void AddArmature(Armature armature)
        {
            ArmatureList.Add(armature);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
namespace Assets.BattleBots.Scripts
{
    public class BattleBotObject : MonoBehaviour
    {
        public BattleBot BattleBot;

        //public AttachedArmatureDictionary AttachedArmatureList;
        public static int EquippableArmatureSlots = 3;

        //public AttachedArmorDictionary AttachedArmorList;
        public static int EquippableArmorSlots = 2;

        public void Awake()
        {
            BattleBot = new BattleBot();
        }
    }
} 

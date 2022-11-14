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
        public List<Armature> AttachedArmatureList;
        public readonly int ArmatureSlots = 3;

        private void Start()
        {
            BattleBot = new BattleBot();
            AttachedArmatureList = new List<Armature>();
            for (int i = 0; i < ArmatureSlots; i++)
            {
                AttachedArmatureList.Add(ArmatureGenerator.GenerateArmature());
            }
        }
    }
} 

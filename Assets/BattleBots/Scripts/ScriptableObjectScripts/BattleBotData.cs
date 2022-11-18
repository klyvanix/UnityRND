using Assets.BattleBots.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.BattleBots
{
    [CreateAssetMenu]
    public class BattleBotData : ScriptableObject
    {
        public BattleBot playerBot;
        [SerializeField]
        private int credits;

        public int Credits
        {
            get { return credits; }
            set { credits = value; }
        }

        public void ResetBotData()
        {
            playerBot = new BattleBot();
            playerBot.InitializeSlots();
        }

        public void ResetAll()
        {
            playerBot = new BattleBot();
            playerBot.InitializeSlots();
            credits = 0;
        }
    }
}

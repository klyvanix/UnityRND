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

        public void ResetBotData()
        {
            playerBot = new BattleBot();
            playerBot.InitializeSlots();
        }
    }
}

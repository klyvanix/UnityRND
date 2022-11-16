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
        public List<BattleBot> Enemies;
    }
}

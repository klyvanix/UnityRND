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
        private int meleePower;
        [SerializeField]
        private int focus;
        [SerializeField]
        private int level;

        public string Name { get => botName; set => botName = value; }

        public int Health { get => maxHealth; set => maxHealth = value; }

        public int Armor { get => armor; set => armor = value; }

        public int Energy { get => energy; set => energy = value; }

        public int Accuracy { get => accuracy; set => accuracy = value; }

        public int MeleePower { get => meleePower; set => meleePower = value; }

        public int Speed { get => speed; set => speed = value; }

        public int Focus { get => focus; set => focus = value; }

        public int Level { get => level; set => level = value; }

        public BattleBot(string name, int health, int armor, int energy, int accuracy, int meleePower, int speed, int focus,int level)
        {
            botName = name;
            maxHealth = health;
            this.armor = armor;
            this.energy = energy;
            this.accuracy = accuracy;
            this.meleePower = meleePower;
            this.speed = speed;
            this.focus = focus;
            this.level = level;
        }

        public BattleBot()
        {
            level = 1;
            maxHealth = 100;
            armor = 0;
            energy = 50;
            accuracy = 50;
            meleePower = 10;
            speed = 10;
            focus = 10;
        }
    }
}

using Assets.BattleBots.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Experimentation
{
    [CreateAssetMenu(menuName = "Generic/ComparableType")]
    public class ComparableType : ScriptableObject
    {
        public int value;
        public bool test;
        public string text;
        public List<int> intList;
        public Armature Armature;
        public Armor Armor;
    }
}

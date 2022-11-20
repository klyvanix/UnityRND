using Assets.BattleBots;
using Assets.BattleBots.Scripts;
using System.Collections.Generic;
using UnityEngine;

public class BattleBotGameManager : MonoBehaviour
{
    public Inventory EquipmentList;
    public BattleBotData BattleBotData;
    [Header("Equipment")]
    public List<ElementalType> ListOfElements;
}

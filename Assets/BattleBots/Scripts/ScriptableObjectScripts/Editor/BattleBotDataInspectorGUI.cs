using Assets.BattleBots;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BattleBotData))]
public class BattleBotDataInspectorGUI : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var battleBotData = (BattleBotData)target;

        if (GUILayout.Button("Test Button"))
        {
            battleBotData.ResetBotData();
        }
    }
}

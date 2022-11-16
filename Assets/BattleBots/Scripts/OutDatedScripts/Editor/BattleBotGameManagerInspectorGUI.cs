using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Assets.BattleBots.Scripts;

[CustomEditor(typeof(BattleBotGameManager))]
public class BattleBotGameManagerInspectorGUI : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var Manager = (BattleBotGameManager)target;

        if(GUILayout.Button("GenerateArmature"))
        {
            Manager.EquipmentList.ArmatureList.Add(ArmatureGenerator.GenerateArmature());
        }
    }
}

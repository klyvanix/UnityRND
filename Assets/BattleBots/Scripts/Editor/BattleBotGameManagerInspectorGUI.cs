using Assets.BattleBots.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BattleBotGameManager))]
public class BattleBotGameManagerInspectorGUI : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var BBGM = (BattleBotGameManager)target;

        if(GUILayout.Button("Generate Armature"))
        {
            BBGM.EquipmentList.ArmatureList.Add(ArmatureGenerator.GenerateArmature());
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EffectSpawner))]
public class EffectSpawnerEditor : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var targetComponent = target as EffectSpawner;

        if (GUILayout.Button("Good")) targetComponent.Show(EffectSpawner.EffectType.good);
        if (GUILayout.Button("Great")) targetComponent.Show(EffectSpawner.EffectType.great);
        if (GUILayout.Button("Perfect")) targetComponent.Show(EffectSpawner.EffectType.perfect);
        if (GUILayout.Button("Miss")) targetComponent.Show(EffectSpawner.EffectType.miss);
    }
}

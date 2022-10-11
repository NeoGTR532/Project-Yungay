using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Cinematicas))]
public class Button : Editor
{
    Cinematicas myTarget;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        myTarget = target as Cinematicas;


        if (GUILayout.Button("CreateTargets"))
            myTarget.CreatePosition();
    }
}

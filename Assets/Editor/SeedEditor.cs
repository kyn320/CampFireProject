using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MapSeed))]
public class SeedEditor : Editor {

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        MapSeed myScript = (MapSeed)target;
        if (GUILayout.Button("SetWidth"))
        {
            myScript.SetWidth();
        }
        if (GUILayout.Button("SetHeight")) {
            myScript.SetHeight();
        }

    }
}

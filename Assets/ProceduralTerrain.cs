using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Threading;
using Noise;

[CustomEditor(typeof(ProceduralTerrainComp))]
[CanEditMultipleObjects]
public class ProceduralTerrain : Editor {
	// Use this for initialization
	public override void OnInspectorGUI () {
		DrawDefaultInspector();
		
		if(GUILayout.Button("Generate New Terrain")) {
			((ProceduralTerrainComp)target).Regenerate();
		}
	}
}

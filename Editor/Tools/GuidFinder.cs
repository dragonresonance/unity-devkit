#if UNITY_EDITOR


using UnityEditor;
using UnityEngine;
using UnityObject = UnityEngine.Object;


namespace DragonResonance.Editor.Tools
{
	public class GuidFinder : EditorWindow
	{
		private bool _wasFound = false;
		private UnityObject _foundObject = null;
		private string _foundPath = "";
		private string _inputGuid = "";


		#region Events

			private void OnGUI()
			{
				EditorGUILayout.LabelField("Prompt", EditorStyles.boldLabel);
				_inputGuid = EditorGUILayout.TextField("GUID", _inputGuid);
				if (GUILayout.Button("Find"))
					_wasFound = TryFindAsset(_inputGuid, out _foundPath, out _foundObject);

				EditorGUILayout.LabelField("Results", EditorStyles.boldLabel);
				if (_wasFound) {
					EditorGUILayout.LabelField("Asset found!");
					EditorGUILayout.TextField("Path", _foundPath);

					if (GUILayout.Button("Highlight asset in Project"))
						EditorGUIUtility.PingObject(_foundObject);

					if (GUILayout.Button("Select asset in Project"))
						Selection.objects = new[] { _foundObject };
				}
				else {
					EditorGUILayout.LabelField("Asset not found.");
				}
			}

		#endregion


		#region Publics

			[MenuItem("Window/Dragon Resonance/GUID Finder")]
			public static void CreateWindow() => GetWindow<GuidFinder>("GUID Finder");

		#endregion


		#region Privates

			private static bool TryFindAsset(string guid, out string path, out UnityObject unityObject)
			{
				path = AssetDatabase.GUIDToAssetPath(guid);
				unityObject = AssetDatabase.LoadAssetAtPath<UnityObject>(path);
				return !string.IsNullOrEmpty(path);
			}

		#endregion
	}
}


#endif


/*                                                                              */
/*           |>  Based on the script of tomekkie2 @ Unity Forums.  <|           */
/*                                                                              */
/*       ________________________________________________________________       */
/*           _________   _______ ________  _______  _______  ___    _           */
/*           |        \ |______/ |______| |  _____ |       | |  \   |           */
/*           |________/ |     \_ |      | |______| |_______| |   \__|           */
/*           ______ _____ _____ _____ __   _ _____ __   _ _____ _____           */
/*           |____/ |____ [___  |   | | \  | |___| | \  | |     |____           */
/*           |    \ |____ ____] |___| |  \_| |   | |  \_| |____ |____           */
/*       ________________________________________________________________       */
/*                                                                              */
/*           David Tabernero M.  <https://github.com/davidtabernerom>           */
/*           Dragon Resonance    <https://github.com/dragonresonance>           */
/*                  Copyright © 2021-2025. All rights reserved.                 */
/*                Licensed under the Apache License, Version 2.0.               */
/*                         See LICENSE.md for more info.                        */
/*       ________________________________________________________________       */
/*                                                                              */
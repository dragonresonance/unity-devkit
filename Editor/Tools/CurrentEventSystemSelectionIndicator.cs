#if UNITY_EDITOR


using UnityEditor;
using UnityEngine.EventSystems;
using UnityEngine;


namespace DragonResonance.Editor.Tools
{
	public class CurrentEventSystemSelectionIndicator : EditorWindow
	{
		#region Events

			private void OnInspectorUpdate() => Repaint();

			private void OnGUI()
			{
				if (Application.isPlaying) {
					if (EventSystem.current != null && EventSystem.current.currentSelectedGameObject != null) {
						EditorGUILayout.ObjectField("Current selection", EventSystem.current.currentSelectedGameObject, typeof(GameObject), true);
					}
					else {
						EditorGUILayout.LabelField("No GameObject selected.");
					}
				}
				else {
					EditorGUILayout.LabelField("The application must be playing to display the selected GameObject.");
				}
			}

		#endregion


		#region Publics

			[MenuItem("Window/Dragon Resonance/Current EventSystem Selection Indicator")]
			public static void CreateWindow() => GetWindow<CurrentEventSystemSelectionIndicator>("Current EventSystem Selection Indicator");

		#endregion
	}
}


#endif


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
/*                  Copyright © 2021-2026. All rights reserved.                 */
/*                Licensed under the Apache License, Version 2.0.               */
/*                         See LICENSE.md for more info.                        */
/*       ________________________________________________________________       */
/*                                                                              */
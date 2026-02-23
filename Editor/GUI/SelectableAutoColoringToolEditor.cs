#if UNITY_EDITOR


using System.Linq;
using UnityEngine;


namespace DragonResonance.GUI
{
	[UnityEditor.CustomEditor(typeof(SelectableAutoColoringTool), true)]
	[UnityEditor.CanEditMultipleObjects]
	public class ButtonAutoColoringToolEditor : UnityEditor.Editor
	{
		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();
			SelectableAutoColoringTool selectedColoringTool = (SelectableAutoColoringTool)base.target;
			SelectableAutoColoringTool[] selectedColoringTools = base.targets.Cast<SelectableAutoColoringTool>().ToArray();

			UnityEditor.EditorGUI.BeginChangeCheck();
			Color newColor = UnityEditor.EditorGUILayout.ColorField("Pick Color", selectedColoringTool.CachedBaseColor);
			if (UnityEditor.EditorGUI.EndChangeCheck()) {
				foreach (SelectableAutoColoringTool coloringTool in selectedColoringTools) {
					UnityEditor.Undo.RecordObject(coloringTool, "Change Color");
					coloringTool.ApplyColoring(newColor);
				}
			}
		}
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
/*                  Copyright © 2021-2025. All rights reserved.                 */
/*                Licensed under the Apache License, Version 2.0.               */
/*                         See LICENSE.md for more info.                        */
/*       ________________________________________________________________       */
/*                                                                              */
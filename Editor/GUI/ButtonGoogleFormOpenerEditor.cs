#if UNITY_EDITOR


using UnityEditor;
using UnityEngine;


namespace DragonResonance.GUI
{
	[CustomEditor(typeof(ButtonGoogleFormOpener), true)]
	public class ButtonGoogleFormOpenerEditor : UnityEditor.Editor
	{
		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();
			ButtonGoogleFormOpener selectedOpener = (ButtonGoogleFormOpener)base.target;

			EditorGUILayout.Separator();
			EditorGUILayout.LabelField("Formatted URL", EditorStyles.boldLabel);
			GUILayout.TextArea(selectedOpener.FormattedUrl(), GUILayout.ExpandHeight(true));
			if (GUILayout.Button(nameof(ButtonGoogleFormOpener.Open)))
				selectedOpener.Open();
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
/*                  Copyright © 2021-2026. All rights reserved.                 */
/*                Licensed under the Apache License, Version 2.0.               */
/*                         See LICENSE.md for more info.                        */
/*       ________________________________________________________________       */
/*                                                                              */
#if UNITY_EDITOR


using UnityEditor;
using UnityEngine;


namespace DragonResonance.Editor.Tools
{
	[CustomEditor(typeof(PipelineBuildingTool))]
	public class PipelineBuildingToolEditor : UnityEditor.Editor
	{
		private static readonly float BuildButtonHeight = 32f;
		private static readonly Color IncludedColor = new(0.4f, 0.8f, 0.4f, 1f);


		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();
			PipelineBuildingTool pipelineBuildingTool = (PipelineBuildingTool)base.target;


			EditorGUILayout.LabelField("Pipeline", EditorStyles.boldLabel);
			int order = 0;
			Color defaultBackgroundColor = UnityEngine.GUI.backgroundColor;
			foreach (SBuildConfiguration configuration in pipelineBuildingTool.BuildConfigurations) {
				UnityEngine.GUI.backgroundColor = configuration.included ? IncludedColor : defaultBackgroundColor;	// Tint with color

				EditorGUILayout.BeginVertical("box");
				configuration.included = EditorGUILayout.BeginToggleGroup($"{++order}.\t{configuration.alias}", configuration.included);
				{
					EditorGUILayout.LabelField("Target/Subtarget", $"{configuration.target}/{configuration.subtarget}");
					EditorGUILayout.TextField("Path", pipelineBuildingTool.GetBuildPath(configuration));

					EditorGUILayout.BeginHorizontal();
					{
						EditorGUILayout.LabelField(
							configuration.included ? "\tThis build IS included in the pipeline." : "\tThis build IS NOT included in the pipeline.",
							EditorStyles.boldLabel);
						if (GUILayout.Button("Build now"))
							pipelineBuildingTool.Build(configuration);
					}
					EditorGUILayout.EndHorizontal();
				}
				EditorGUILayout.EndToggleGroup();
				EditorGUILayout.EndVertical();
			}

			/*EditorGUILayout.BeginHorizontal();
			{
				EditorGUILayout.LabelField($"{++order}. {configuration.alias}");
				if (GUILayout.Button("Build"))
					pipelineBuildingTool.Build(configuration);
			}
			EditorGUILayout.EndHorizontal();*/

			UnityEngine.GUI.backgroundColor = IncludedColor;
			if (GUILayout.Button("Execute Building Pipeline", GUILayout.Height(BuildButtonHeight)))
				pipelineBuildingTool.Build();
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
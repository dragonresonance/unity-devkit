#if UNITY_EDITOR


using DragonResonance.Logging;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;


namespace DragonResonance.Editor.Tools
{
	[CreateAssetMenu(menuName = "Dragon Resonance/Pipeline Building Asset", fileName = "New Pipeline Building Asset")]
	public class PipelineBuildingTool : ScriptableObject
	{
		[Header("Configuration")]
		[SerializeField] private string _buildsLocation = "./Builds";
		[SerializeField] private SBuildConfiguration[] _buildConfigurations = { };


		#region Publics

			[ContextMenu(nameof(Build))]
			public void Build()
			{
				Log.Emphasis($"Building pipeline ...");
				{
					foreach (SBuildConfiguration configuration in _buildConfigurations)
						if (configuration.included)
							Build(configuration);
				}
				Log.Emphasis("Pipeline finished!");
			}


			public void Build(int index) => Build(_buildConfigurations[index]);
			public void Build(SBuildConfiguration configuration)
			{
				Log.Info($"Building {configuration.alias} ...");
				{
					BuildPipeline.BuildPlayer(new BuildPlayerOptions() {
						scenes = EditorBuildSettings.scenes.Where(scene => scene.enabled).Select(scene => scene.path).ToArray(),
						target = configuration.target,
						subtarget = (int)configuration.subtarget,
						options = configuration.options,
						locationPathName = GetBuildPath(configuration.folderName, configuration.binaryFilename),
						extraScriptingDefines = configuration.extraScriptingDefines,
					});
				}
				Log.Info("Building finished!");
			}


			public string GetBuildPath(SBuildConfiguration configuration) =>
				GetBuildPath(configuration.folderName, configuration.binaryFilename);
			public string GetBuildPath(string folderName, string binaryFilename) =>
				Path.Combine(Path.GetRelativePath(".", _buildsLocation), folderName, binaryFilename);

		#endregion


		#region Properties

			public IEnumerable<SBuildConfiguration> BuildConfigurations => _buildConfigurations;

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
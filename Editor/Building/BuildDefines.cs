#if UNITY_EDITOR


using DragonResonance.Extensions;
using DragonResonance.Logging;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Build;
using UnityEditor;


namespace DragonResonance.Editor.Building
{
	[InitializeOnLoad]
	public static partial class BuildDefines
	{
		#region Constructors

			static BuildDefines() => OrganizeBuildDefinitions();

		#endregion


		#region Publics

			[MenuItem("Tools/Dragon Resonance/Building/Organize Build Definitions")]
			public static void OrganizeBuildDefinitions()
			{
				Log.Info("Organizing Build Definitions...");
				{
					List<string> definitions = new(BuildDefines.CurrentDefinitions);
					{
						ReplenishDefinitions(definitions, DemonstrationValidDefinitions);
						ReplenishDefinitions(definitions, LoggingValidDefinitions);
						ReplenishDefinitions(definitions, BuildPropertiesIntegrationValidDefinitions);

						#if STEAMWORKS_INTEGRATION
							ReplenishDefinitions(SteamworksIntegrationValidDefinitions);
						#endif
						#if EOS_INTEGRATION
							ReplenishDefinitions(EOSIntegrationValidDefinitions);
						#endif
					}
					ApplyDefinitions(new SortedSet<string>(definitions));
				}
				Log.Info($"Done!");
			}

			public static void ToggleBuildDefinition(string definition)
			{
				definition = definition.Trim();
				if (string.IsNullOrEmpty(definition)) return;

				List<string> definitions = new(BuildDefines.CurrentDefinitions);
				{
					if (definitions.Contains(definition)) {
						definitions.Remove(definition);
						definitions.AddOrIgnore(FormatToggledDefinition(definition));
					}
					else {
						definitions.Remove(FormatToggledDefinition(definition));
						definitions.AddOrIgnore(definition);
					}
				}
				ApplyDefinitions(definitions);
			}

		#endregion


		#region Privates

			private static string FormatToggledDefinition(string definition) =>
				definition.StartsWith('_') ? definition.TrimStart('_') : $"_{definition}";

			private static void ApplyDefinitions(IEnumerable<string> definitions)
			{
				PlayerSettings.SetScriptingDefineSymbols(
					NamedBuildTarget.FromBuildTargetGroup(EditorUserBuildSettings.selectedBuildTargetGroup),
					definitions.ToArray());
			}

			private static void ReplenishDefinitions(List<string> list, IReadOnlyList<string> definitions, int fallbackIndex = 0)
			{
				if (definitions.Count == 0) return;
				int validSetDefinitionIndex = definitions.IndexOf(list);
				list.RemoveAll(definitions.Contains);
				list.Add((validSetDefinitionIndex != -1) ?
					definitions[validSetDefinitionIndex] :
					definitions[fallbackIndex]);
			}

		#endregion


		#region Properties

			public static IEnumerable<string> CurrentDefinitions => PlayerSettings
				.GetScriptingDefineSymbols(NamedBuildTarget.FromBuildTargetGroup(EditorUserBuildSettings.selectedBuildTargetGroup))
				.Split(';');

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
#if UNITY_EDITOR


using DragonResonance.Settings;
using UnityEditor;
using UnityEngine;


namespace DragonResonance.Editor.Settings
{
	public class DragonResonanceRuntimeSettingsProvider : SettingsProvider
	{
		private const string SettingsPath = "Project/Dragon Resonance/Runtime";

		private static DragonResonanceRuntimeSettings _settings;


		#region Constructors

			public DragonResonanceRuntimeSettingsProvider(string path, SettingsScope scope) : base(path, scope) { }

		#endregion



		#region Publics

			[SettingsProvider]
			public static SettingsProvider Create()
			{
				string[] guids = AssetDatabase.FindAssets($"t:{nameof(DragonResonanceRuntimeSettings)}");

				if (guids.Length > 0) {
					string path = AssetDatabase.GUIDToAssetPath(guids[0]);
					_settings = AssetDatabase.LoadAssetAtPath<DragonResonanceRuntimeSettings>(path);
				}
				else {
					_settings = ScriptableObject.CreateInstance<DragonResonanceRuntimeSettings>();
					AssetDatabase.CreateAsset(_settings, $"Assets/DragonResonanceSettings.asset");
					AssetDatabase.SaveAssets();
				}

				return new DragonResonanceRuntimeSettingsProvider(SettingsPath, SettingsScope.Project);
			}

			public override void OnGUI(string searchContext)
			{
				EditorGUI.BeginChangeCheck();
				{
					_settings.RuntimeTestBool = EditorGUILayout.Toggle("Runtime Test Bool", _settings.RuntimeTestBool);
					_settings.RuntimeTestString = EditorGUILayout.TextField("Runtime Test String", _settings.RuntimeTestString);
				}
				if (EditorGUI.EndChangeCheck())
					EditorUtility.SetDirty(_settings);
			}

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
/*                  Copyright © 2021-2025. All rights reserved.                 */
/*                Licensed under the Apache License, Version 2.0.               */
/*                         See LICENSE.md for more info.                        */
/*       ________________________________________________________________       */
/*                                                                              */
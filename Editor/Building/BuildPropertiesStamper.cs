#if UNITY_EDITOR && OUTPUT_BUILD_PROPERTIES


using DragonResonance.Logging;
using System.IO;
using System;
using UnityEditor.Build.Reporting;
using UnityEditor.Build;
using UnityEditor;
using UnityEngine;
using Version = DragonResonance.Miscellany.Version;


namespace DragonResonance.Editor.Building
{
	public class BuildPropertiesStamper : IPostprocessBuildWithReport
	{
		private const string OUTPUT_FILEPATH     = "./build.properties";

		private const string APP_NAME_KEY        = "application_name";
		private const string APP_VERSION_KEY     = "application_version";
		private const string BUILD_TARGET_KEY    = "build_target";
		private const string BUILD_DATETIME_KEY  = "build_datetime";
		private const string BUILD_TIMESTAMP_KEY = "build_timestamp";
		private const string COMPANY_NAME_KEY    = "company_name";
		private const string ENGINE_NAME_KEY     = "engine_name";
		private const string ENGINE_VERSION_KEY  = "engine_version";


		#region Events

			public void OnPostprocessBuild(BuildReport report) => StampBuildingData(report);

		#endregion


		#region Publics

			public static string GetFormattedTimestampDatetime() => $"{DateTimeOffset.UtcNow:yyMMddHHmmss}";
			public static string GetFormattedLine(string key, string value) => $"{key}={value}";

			public static void StampBuildingData(BuildReport report)
			{
				string buildDirectory = Path.GetDirectoryName(report.summary.outputPath) ?? ".";
				string outputPath = Path.Combine(buildDirectory, OUTPUT_FILEPATH);

				Log.Info($"Stamping data to {outputPath}...");
				{
					Directory.CreateDirectory(Path.GetDirectoryName(outputPath)!);
					File.WriteAllLines(outputPath, new[] {
						GetFormattedLine(APP_NAME_KEY, Application.productName),
						GetFormattedLine(APP_VERSION_KEY, Version.AppVersionLower),
						GetFormattedLine(BUILD_TARGET_KEY, report.summary.platform.ToString()),
						GetFormattedLine(BUILD_DATETIME_KEY, $"{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}"),
						GetFormattedLine(BUILD_TIMESTAMP_KEY, GetFormattedTimestampDatetime()),
						GetFormattedLine(COMPANY_NAME_KEY, Application.companyName),
						GetFormattedLine(ENGINE_NAME_KEY, "Unity"),
						GetFormattedLine(ENGINE_VERSION_KEY, Application.unityVersion),
					});
				}
				Log.Info($"Done!");
			}

		#endregion


		#region Properties

			public int callbackOrder => 0;	// Implicit override

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
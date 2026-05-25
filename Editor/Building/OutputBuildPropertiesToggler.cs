#if UNITY_EDITOR


using UnityEditor;


namespace DragonResonance.Editor.Building
{
	[InitializeOnLoad]
	public static class OutputBuildPropertiesToggler
	{
		private const string OUTPUT_BUILD_PROPERTIES_DEFINE = "OUTPUT_BUILD_PROPERTIES";


		#region Constructors

			static OutputBuildPropertiesToggler() => BuildDefines.SetupBuildDefinition(OUTPUT_BUILD_PROPERTIES_DEFINE, false);

		#endregion


		#region Publics

			#if OUTPUT_BUILD_PROPERTIES
				[MenuItem("Build/Output Build Properties [ON]/Disable output")]
			#else
				[MenuItem("Build/Output Build Properties [OFF]/Enable output")]
			#endif
			public static void SwitchLogging() => BuildDefines.ToggleBuildDefinition(OUTPUT_BUILD_PROPERTIES_DEFINE);

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
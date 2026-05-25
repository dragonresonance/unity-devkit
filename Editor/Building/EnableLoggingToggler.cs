#if UNITY_EDITOR


using UnityEditor;


namespace DragonResonance.Editor.Building
{
	[InitializeOnLoad]
	public static class EnableLoggingToggler
	{
		private const string ENABLE_LOGGING_DEFINE = "ENABLE_LOGGING";


		#region Constructors

			static EnableLoggingToggler() => BuildDefines.SetupBuildDefinition(ENABLE_LOGGING_DEFINE, false);

		#endregion


		#region Publics

			#if ENABLE_LOGGING
				[MenuItem("Build/Logging [ON]/Disable logging")]
			#else
				[MenuItem("Build/Logging [OFF]/Enable logging")]
			#endif
			public static void SwitchLogging() => BuildDefines.ToggleBuildDefinition(ENABLE_LOGGING_DEFINE);

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
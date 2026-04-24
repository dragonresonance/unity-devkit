#if UNITY_EDITOR


namespace DragonResonance.Editor.Building
{
	public partial class BuildDefines // Definitions
	{
		private static readonly string[] DemonstrationValidDefinitions = {
			/* 0 */ "_DEMO_BUILD", // Default
			/* 1 */ "DEMO_BUILD",
		};

		private static readonly string[] LoggingValidDefinitions = {
			/* 0 */ "ENABLE_LOGGING", // Default
			/* 1 */ "_ENABLE_LOGGING",
		};

		private static readonly string[] ContexterIntegrationValidDefinitions = {
			/* 0 */ "_ENABLE_CONTEXTER", // Default
			/* 1 */ "ENABLE_CONTEXTER",
		};

		private static readonly string[] BuildPropertiesIntegrationValidDefinitions = {
			/* 0 */ "OUTPUT_BUILD_PROPERTIES", // Default
			/* 1 */ "_OUTPUT_BUILD_PROPERTIES",
		};

		#if STEAMWORKS_INTEGRATION
		private static readonly string[] SteamworksIntegrationValidDefinitions = {
			/* 0 */ "_DISABLESTEAMWORKS", // Default
			/* 1 */ "DISABLESTEAMWORKS",
		};
		#endif

		#if EOS_INTEGRATION
		private static readonly string[] EOSIntegrationValidDefinitions = {
			/* 0 */ "_EOS_DISABLE", // Default
			/* 1 */ "EOS_DISABLE",
		};
		#endif
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
#if UNITY_EDITOR


using UnityEditor;


namespace DragonResonance.Editor.Building
{
	public static class DemoBuildToggler
	{
		private const string DEMO_BUILD_DEFINE = "DEMO_BUILD";


		#region Publics

			#if DEMO_BUILD
				[MenuItem("DEMO MODE/Switch to Release")]
			#else
				[MenuItem("RELEASE MODE/Switch to Demo")]
			#endif
			public static void SwitchDemoMode() => BuildDefines.ToggleBuildDefinition(DEMO_BUILD_DEFINE);

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
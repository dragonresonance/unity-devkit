#if TEST_INTEGRATION


#if !DISABLESTEAMWORKS
using PossumScream.Integration.Steamworks;
#endif


#if !EOS_DISABLE
using PossumScream.Integration.EOS;
#endif




namespace PossumScream.Integration
{
	public partial class IntegrationMaster // Initialization
	{
		#region Controls


			public bool CheckInitialization()
			{
				#if !DISABLESTEAMWORKS
					// Steamworks
					return SteamManager.TryGetInstance(out SteamManager steamManagerInstance) && steamManagerInstance.Initialized;
				#elif !EOS_DISABLE
					// Epic Online Services
					return EpicManager.TryGetInstance(out EpicManager epicManagerInstance) && epicManagerInstance.Initialized;
				#else
					// No integration
					return false;
				#endif
			}


		#endregion




		#region Actions


			//


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
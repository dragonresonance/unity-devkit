#if TEST_INTEGRATION


#if !DISABLESTEAMWORKS
using PossumScream.Integration.Steamworks;
using Steamworks;
#endif


#if !EOS_DISABLE
using PossumScream.Integration.EOS;
#endif




namespace PossumScream.Integration
{
	public partial class IntegrationMaster // Achievements
	{
		#region Controls


			public bool CheckIfAchievementExists(string name)
			{
				#if !DISABLESTEAMWORKS
					// Steamworks
					return SteamUserStats.GetAchievement(name, out _);
				#elif !EOS_DISABLE
					// Epic Online Services
					return false;
				#else
					// No integration
					return false;
				#endif
			}


			public bool CheckIfAchievementAchieved(string name)
			{
				#if !DISABLESTEAMWORKS
					// Steamworks
					return SteamUserStats.GetAchievement(name, out bool achieved) && achieved;
				#elif !EOS_DISABLE
					// Epic Online Services
					return false;
				#else
					// No integration
					return false;
				#endif
			}




			public bool SetAchievement(string name)
			{
				#if !DISABLESTEAMWORKS
					// Steamworks
					return SteamUserStats.SetAchievement(name);
				#elif !EOS_DISABLE
					// Epic Online Services
					return false;
				#else
					// No integration
					return false;
				#endif
			}


			public bool UnsetAchievement(string name)
			{
				#if !DISABLESTEAMWORKS
					// Steamworks
					return SteamUserStats.ClearAchievement(name);
				#elif !EOS_DISABLE
					// Epic Online Services
					return false;
				#else
					// No integration
					return false;
				#endif
			}




			public bool StoreStats()
			{
				#if !DISABLESTEAMWORKS
					// Steamworks
					return SteamUserStats.StoreStats();
				#elif !EOS_DISABLE
					// Epic Online Services
					return false;
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
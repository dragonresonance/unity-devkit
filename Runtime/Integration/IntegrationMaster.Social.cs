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
	public partial class IntegrationMaster // Social
	{
		#region Controls


			public string GetPersonaName()
			{
				#if !DISABLESTEAMWORKS
					// Steamworks
					return SteamFriends.GetPersonaName();
				#elif !EOS_DISABLE
					// Epic Online Services
					return null;
				#else
					// No integration
					return null;
				#endif
			}


			public int GetFriendCount()
			{
				#if !DISABLESTEAMWORKS
					// Steamworks
					return SteamFriends.GetFriendCount(EFriendFlags.k_EFriendFlagAll);
				#elif !EOS_DISABLE
					// Epic Online Services
					return -1;
				#else
					// No integration
					return -1;
				#endif
			}


			public string[] GetFriendList()
			{
				#if !DISABLESTEAMWORKS
					// Steamworks
					int friendCount = GetFriendCount();
					string[] friendList = new string[friendCount];

					for (int friendIndex = 0; friendIndex < friendCount; friendIndex++) {
						CSteamID steamId = SteamFriends.GetFriendByIndex(friendIndex, EFriendFlags.k_EFriendFlagAll);
						friendList[friendIndex] = SteamFriends.GetFriendPersonaName(steamId);
					}

					return friendList;
				#elif !EOS_DISABLE
					// Epic Online Services
					return null;
				#else
					// No integration
					return null;
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
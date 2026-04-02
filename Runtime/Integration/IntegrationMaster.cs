#if TEST_INTEGRATION


#if !(UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || UNITY_STANDALONE_OSX || STEAMWORKS_WIN || STEAMWORKS_LIN_OSX) || !EOS_DISABLE
#define DISABLESTEAMWORKS
#endif
#if !(UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || UNITY_STANDALONE_OSX || EOS_PREVIEW_PLATFORM) || !DISABLESTEAMWORKS
#define EOS_DISABLE
#endif


using PossumScream.Behaviours;
using UnityEngine;


#if !DISABLESTEAMWORKS
using PossumScream.Integration.Steamworks;
using Steamworks;
#endif


#if !EOS_DISABLE
using PossumScream.Integration.EOS;
#endif




namespace PossumScream.Integration
{
	public partial class IntegrationMaster : PersistentSingletonBehaviour<IntegrationMaster>
	{
		[Header("Components")]
		[SerializeField] private IntegrationTester _integrationTester = null;




		#region Events


			#if !DISABLESTEAMWORKS || !EOS_DISABLE
			private void Start()
			{
				if (this._integrationTester == null) return;

				this._integrationTester.TestInitialization();
			}
			#endif


		#endregion




		#region Controls


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
/*                  Copyright © 2021-2026. All rights reserved.                 */
/*                Licensed under the Apache License, Version 2.0.               */
/*                         See LICENSE.md for more info.                        */
/*       ________________________________________________________________       */
/*                                                                              */
#if TEST_INTEGRATION


#if !(UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || UNITY_STANDALONE_OSX || EOS_PREVIEW_PLATFORM)
#define EOS_DISABLE
#endif


using NaughtyAttributes;
using PossumScream.Behaviours;
using UnityEngine;


#if !EOS_DISABLE
//
#endif




namespace PossumScream.Integration.EOS
{
	public class EpicManager : PersistentSingletonBehaviour<EpicManager>
	{
		[Header("Configuration")]
		#pragma warning disable CS0414
		// ReSharper disable once NotAccessedField.Local
		[SerializeField] [Label("[DANGER!] Edit Critical Configuration")] private bool _editCriticalConfiguration = false;
		#pragma warning restore CS0414

		[EnableIf("_editCriticalConfiguration")] [SerializeField] private bool _initialized = false;




		#region Properties


			public bool Initialized => this._initialized;


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
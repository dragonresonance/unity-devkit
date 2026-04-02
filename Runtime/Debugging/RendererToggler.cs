#if ENABLE_INPUT_SYSTEM


using DragonResonance.Behaviours;
using UnityEngine.InputSystem;
using UnityEngine;


namespace DragonResonance.Debugging
{
	public class RendererToggler : PossumBehaviour
	{
		[SerializeField] private Key _toggleKey = Key.F1;


		private Renderer _renderer_internal = null;	// Caching only, use the property instead


		#region Events

			private void Update()
			{
				if (Keyboard.current[_toggleKey].wasPressedThisFrame)
					this.Renderer.enabled = !this.Renderer.enabled;
			}

		#endregion


		#region Properties

			public Renderer Renderer => ((_renderer_internal != null) ? _renderer_internal : (_renderer_internal = GetComponent<Renderer>()));

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
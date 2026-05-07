using DragonResonance.Behaviours;
using UnityEngine.UI;
using UnityEngine;


namespace DragonResonance.GUI
{
	public class ButtonUrlOpener : PossumBehaviour
	{
		[SerializeField] protected string _url = "https://example.com/";


		private Button _button_internal = null;	// Caching only, use the property instead


		#region Events

			private void OnEnable() => this.Button.onClick.AddListener(Open);
			private void OnDisable() => this.Button.onClick.RemoveListener(Open);

		#endregion


		#region Publics

			public virtual void Open() => Application.OpenURL(_url);

		#endregion


		#region Properties

			public Button Button => (_button_internal = GetComponentIfNull(_button_internal));

		#endregion
	}
}


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
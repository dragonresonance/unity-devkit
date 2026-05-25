#if UNITY_EDITOR


using DragonResonance.Extensions;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityObject = UnityEngine.Object;


namespace DragonResonance.Editor.Building
{
	[InitializeOnLoad]
	public static class PreloadedAssets
	{
		#region Constructors

			static PreloadedAssets() => Reapply();

		#endregion


		#region Publics

			public static List<UnityObject> List() =>
				PlayerSettings.GetPreloadedAssets().ToList();

			public static void Reapply() => Apply(List());
			public static void Apply(IEnumerable<UnityObject> preloadedAssets) =>
				PlayerSettings.SetPreloadedAssets(preloadedAssets
					.Where(asset => (asset != null))
					.OrderBy(asset => asset.name)
					.ToArray());

			public static void Add(UnityObject unityObject)
			{
				List<UnityObject> preloadedAssets = List();
				preloadedAssets.AddOrIgnore(unityObject);
				Apply(preloadedAssets);
			}

			public static void Remove(UnityObject unityObject)
			{
				List<UnityObject> preloadedAssets = List();
				preloadedAssets.Remove(unityObject);
				Apply(preloadedAssets);
			}

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
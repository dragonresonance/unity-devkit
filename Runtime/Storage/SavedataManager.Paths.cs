using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;


namespace DragonResonance.Storage
{
	public partial class SavedataManager
	{

		#region Publics

			public string GetOptimizedPersistentDataPath() => GetOptimizedPersistentDataPath(".");
			public string GetOptimizedPersistentDataPath(string path) => GetOptimizedPersistentDataPath(".", path);
			public string GetOptimizedPersistentDataPath(string path, string filename)
			{
				string optimizedPersistentDataPath = Application.persistentDataPath;

				#if UNITY_STANDALONE_WIN
					optimizedPersistentDataPath =
						Regex.Replace(optimizedPersistentDataPath, @"\bLocalLow\b", "Roaming", RegexOptions.IgnoreCase);
				#endif

				return Path.GetFullPath(Path.Combine(optimizedPersistentDataPath, path, filename));
			}

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
/*                  Copyright © 2021-2025. All rights reserved.                 */
/*                Licensed under the Apache License, Version 2.0.               */
/*                         See LICENSE.md for more info.                        */
/*       ________________________________________________________________       */
/*                                                                              */
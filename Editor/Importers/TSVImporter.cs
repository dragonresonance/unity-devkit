#if UNITY_EDITOR


using System.IO;
using UnityEditor.AssetImporters;
using UnityEditor;
using UnityEngine;


namespace DragonResonance.Editor.Importers
{
	[ScriptedImporter(1, "tsv")]
	public class TSVImporter : ScriptedImporter
	{
		public override void OnImportAsset(AssetImportContext context)
		{
			TextAsset textAsset = new(File.ReadAllText(context.assetPath));

			context.AddObjectToAsset(Path.GetFileNameWithoutExtension(context.assetPath), textAsset);
			context.SetMainObject(textAsset);

			AssetDatabase.SaveAssets();
		}
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
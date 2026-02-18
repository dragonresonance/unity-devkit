using DragonResonance.Behaviours;
using DragonResonance.Extensions;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System;
using UnityEngine;


#if SIMPLEJSON
	using Tabernero.SimpleJSON;
#endif




namespace DragonResonance.Storage
{
	public partial class SavedataManager : PersistentSingletonPossumBehaviour<SavedataManager>
	{
		private const string ASSEMBLY_CLASS_SEPARATOR = "::";


		[SerializeField] private bool _loadOnStart = true;
		[SerializeField] private bool _compactedJSON = false;
		[SerializeField] private string _defaultFilename = "local.json";
		//[SerializeField] private SSavableOverride[] _overrides = { };


		private readonly Dictionary<Type, string> _data = new();




		#region Events


			private void Start()
			{
				if (_loadOnStart)
					Load();
			}


		#endregion




		#region Publics - File Management
		#if SIMPLEJSON


			[ContextMenu(nameof(Load))]
			public void Load()
			{
				string filePath = GetOptimizedPersistentDataPath(_defaultFilename);
				if (!File.Exists(filePath)) return;

				string content = File.ReadAllText(filePath, Encoding.UTF8);
				JSONNode jsonNode = JSONNode.Parse(content);

				_data.Clear();
				foreach (KeyValuePair<string, JSONNode> jsonDataKeyValuePair in jsonNode) {
					string[] parts = jsonDataKeyValuePair.Key.Split(ASSEMBLY_CLASS_SEPARATOR, 2);
					Type type = Type.GetType($"{parts[1]}, {parts[0]}");
					if (type != null)
						_data.AddOrSet(type, jsonDataKeyValuePair.Value.ToString());
				}
			}


			[ContextMenu(nameof(Save))]
			public void Save()
			{
				JSONNode jsonNode = JSONNode.Parse("{}");

				foreach (KeyValuePair<Type, string> dataKeyValuePair in _data)
					jsonNode.Add(
						$"{dataKeyValuePair.Key.Assembly.GetName().Name}{ASSEMBLY_CLASS_SEPARATOR}{dataKeyValuePair.Key.FullName}",
						JSONNode.Parse(dataKeyValuePair.Value));

				string persistentDataPath = GetOptimizedPersistentDataPath();
				if (Directory.CreateDirectory(persistentDataPath).Exists)
					File.WriteAllText(Path.Combine(persistentDataPath, _defaultFilename), jsonNode.ToString(_compactedJSON));
			}


		#endif
		#endregion




		#region Publics - Data Management


			public bool Get<T>(out T data, T fallback) where T : ISavableData
			{
				data = fallback;

				if (_data.TryGetValue(typeof(T), out string jsonData)) {
					JsonUtility.FromJsonOverwrite(jsonData, data);
					return true;
				}

				return false;
			}


			public void Set<T>(T data) where T : ISavableData
			{
				string jsonData = JsonUtility.ToJson(data);
				_data.AddOrSet(typeof(T), jsonData);
			}


		#endregion




		#region Privates

			//

		#endregion




		#region Properties


			public bool CompactedJSON => _compactedJSON;
			public Dictionary<Type, string> Data => _data;


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
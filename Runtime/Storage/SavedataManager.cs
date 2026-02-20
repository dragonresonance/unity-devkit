using DragonResonance.Behaviours;
using DragonResonance.Extensions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
		[SerializeField] private bool _useCompactData = false;
		[SerializeField] private string _defaultFilePath = "local.json";
		[SerializeField] private SSavableOverride[] _overrides = { };


		private bool _ready = false;
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
				foreach (string filePath in this.FilePaths) {
					string dataFilePath = GetOptimizedPersistentDataPath(filePath);
					if (!File.Exists(dataFilePath)) return;

					string content = File.ReadAllText(dataFilePath, Encoding.UTF8);
					JSONNode jsonNode = JSONNode.Parse(content);

					_data.Clear();
					foreach (KeyValuePair<string, JSONNode> jsonDataKeyValuePair in jsonNode) {
						string[] parts = jsonDataKeyValuePair.Key.Split(ASSEMBLY_CLASS_SEPARATOR, 2);
						Type type = Type.GetType($"{parts[1]}, {parts[0]}");
						if (type != null)
							_data.AddOrSet(type, jsonDataKeyValuePair.Value.ToString());
					}
				}

				_ready = true;
			}


			[ContextMenu(nameof(Save))]
			public void Save()
			{
				HashSet<Type> storedTypes = new();
				JSONNode temporalJsonNode = null;
				string persistentDataPath = GetOptimizedPersistentDataPath();
				if (!Directory.CreateDirectory(persistentDataPath).Exists) return;

				foreach (SSavableOverride savableOverride in _overrides) {
					temporalJsonNode = JSONNode.Parse("{}");
					foreach (string savableType in savableOverride.Types) {
						Type type = Type.GetType(savableType);
						if (type == null) continue;

						temporalJsonNode.Add(
							$"{type.Assembly.GetName().Name}{ASSEMBLY_CLASS_SEPARATOR}{type.FullName}",
							JSONNode.Parse(_data[type]));
						storedTypes.Add(type);
					}
					File.WriteAllText(Path.Combine(persistentDataPath, savableOverride.FilePath), temporalJsonNode.ToString(_useCompactData));
				}

				temporalJsonNode = JSONNode.Parse("{}");
				foreach (KeyValuePair<Type, string> keyValuePair in _data.Where(dataEntryPair => !storedTypes.Contains(dataEntryPair.Key))) {
					temporalJsonNode.Add(
						$"{keyValuePair.Key.Assembly.GetName().Name}{ASSEMBLY_CLASS_SEPARATOR}{keyValuePair.Key.FullName}",
						JSONNode.Parse(_data[keyValuePair.Key]));
					storedTypes.Add(keyValuePair.Key);
				}
				File.WriteAllText(Path.Combine(persistentDataPath, _defaultFilePath), temporalJsonNode.ToString(_useCompactData));
			}


			[ContextMenu(nameof(SaveReload))]
			public void SaveReload()
			{
				Save();
				Load();
			}


		#endif
		#endregion




		#region Publics - Data Management


			public bool Get<T>(out T data, T fallback) where T : ISavableData
			{
				data = fallback;

				#if SIMPLEJSON
					if (!_ready) Load();
				#endif

				if (_data.TryGetValue(typeof(T), out string jsonData)) {
					data = JsonUtility.FromJson<T>(jsonData);
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


			public bool Ready => _ready;
			public bool UseCompactData => _useCompactData;
			public string DefaultFilePath => _defaultFilePath;
			public string OptimizedPersistentDataPath => GetOptimizedPersistentDataPath();
			public Dictionary<Type, string> Data => _data;

			public IEnumerable<string> FilePaths => _overrides.Select(savable => savable.FilePath).Prepend(_defaultFilePath);


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
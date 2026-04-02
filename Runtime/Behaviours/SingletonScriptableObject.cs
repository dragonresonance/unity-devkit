using UnityEngine;


namespace DragonResonance.Behaviours
{
	public class SingletonScriptableObject<T> : ScriptableObject where T : ScriptableObject
	{
		internal static T _instance = null;


		#region Events

			protected void Awake() => AssessInstance();
			protected void OnValidate() => AssessInstance();

		#endregion


		#region Publics

			public static bool TryGetInstance(out T instance) => ((instance = GetInstance()) != null);

			public static T GetInstance()
			{
				if ((_instance == null) && (FindAnyObjectByType(typeof(T)) is SingletonScriptableObject<T> instance))
					instance.AssessInstance();

				return _instance;
			}

		#endregion


		#region Inheritables

			protected virtual void AssessInstance()
			{
				if (_instance == null)
					_instance = this as T;
				else if (_instance != this)
					Debug.LogError($"This instance ({base.name}) is inaccessible as Instance");
			}

		#endregion


		#region Properties

			public static T CachedInstance => _instance;
			public static T Instance => GetInstance();

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
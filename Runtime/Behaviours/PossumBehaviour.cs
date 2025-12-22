using UnityEngine;
using UnityObject = UnityEngine.Object;


namespace DragonResonance.Behaviours
{
	public abstract partial class PossumBehaviour : MonoBehaviour
	{
		#if UNITY_EDITOR
		#pragma warning disable 0414
		// ReSharper disable once NotAccessedField.Local
		[SerializeField] private string _description = "";
		#pragma warning restore 0414
		#endif


		#region Privates

			protected T GetComponentIfNull<T>(T statement) where T : Component =>
				((statement == null) ? GetComponent<T>() : statement);
			protected T GetComponentInChildrenIfNull<T>(T statement) where T : Component =>
				((statement == null) ? GetComponentInChildren<T>() : statement);
			protected T GetComponentInParentIfNull<T>(T statement) where T : Component =>
				((statement == null) ? GetComponentInParent<T>() : statement);

			protected T FindComponentIfNull<T>(T statement) where T : Component =>
				FindComponentIfNull(statement, true);
			protected T FindComponentIfNull<T>(T statement, bool includeInactive) where T : Component =>
				FindComponentIfNull(statement, (includeInactive ? FindObjectsInactive.Include : FindObjectsInactive.Exclude));
			protected T FindComponentIfNull<T>(T statement, FindObjectsInactive includeInactive) where T : Component =>
				((statement == null) ? FindAnyObjectByType<T>(includeInactive) : statement);

		#endregion


		#region Properties

			public RectTransform rectTransform => (RectTransform)base.transform;

		#endregion


		#if UNITY_EDITOR

			protected static T FindFirstAssetIfNull<T>(UnityObject statement) where T : UnityObject
			{
				if (statement != null) return (T)statement;
				string[] guids = UnityEditor.AssetDatabase.FindAssets("t:" + typeof(T).Name);
				if (guids.Length == 0) return null;
				return UnityEditor.AssetDatabase.LoadAssetAtPath<T>(UnityEditor.AssetDatabase.GUIDToAssetPath(guids[0]));
			}

		#endif
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
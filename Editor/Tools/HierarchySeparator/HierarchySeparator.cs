using DragonResonance.Behaviours;
using UnityEngine;


[ExecuteAlways]
[DisallowMultipleComponent]
public sealed class HierarchySeparator : PossumBehaviour
{
	[SerializeField] private Color _backgroundColor = new Color32(50, 50, 50, byte.MaxValue);
	[SerializeField] [Range(0f, 1f)] private float _textVisibility = 0.6f;
	[SerializeField] [Range(0f, 1f)] private float _accentVisibility = 0.2f;


	#region Events

		private void Awake()
		{
			#if !UNITY_EDITOR
				DestroyDynamically(this.gameObject);	// Should NOT run this, but just in case...
			#else
				LockTransform();
			#endif
		}

		private void OnValidate() => LockTransform();
		private void OnTransformParentChanged() => LockTransform();
		private void OnTransformChildrenChanged() => LockTransform();

	#endregion


	#region Privates

		private void LockTransform()
		{
			//	Mark GameObject as static and tag as EditorOnly so gets destroyed on build
			base.gameObject.isStatic = true;
			if (!base.gameObject.CompareTag("EditorOnly"))
				base.gameObject.tag = "EditorOnly";

			//	Set Transform
			base.transform.position = Vector3.zero;
			base.transform.rotation = Quaternion.identity;
			base.transform.localScale = Vector3.one;
			base.transform.hideFlags = HideFlags.HideInInspector | HideFlags.NotEditable;

			//	Move self to root
			base.transform.SetParent(null);

			//	Move children to scene
			foreach (Transform child in children) {
				child.SetParent(null, true);
				Warning($"{child.name} was detached from separator {this.DisplayLabel} and moved to the scene root.", child);
			}
		}

	#endregion


	#region Properties

		public string DisplayLabel => base.name;
		public Color BackgroundColor => _backgroundColor;
		public Color TextColor => Color.Lerp(this.BackgroundColor, Color.white, _textVisibility);
		public Color AccentColor => Color.Lerp(this.BackgroundColor, Color.white, _accentVisibility);

	#endregion
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
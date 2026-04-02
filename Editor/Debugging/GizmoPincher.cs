using PossumScream.Constants;
using UnityEngine;

#if UNITY_EDITOR_
using PossumScream.Editor.Editors;
using UnityEditor;
#endif



namespace PossumScream.Editor.Debugging
{
	#if UNITY_EDITOR_
	[CustomEditor(typeof(GizmoPincher))]
	public class GizmoPincherEditor : ScriptlessEditor { }
	#endif




	[RequireComponent(typeof(Transform))]
	public class GizmoPincher : MonoBehaviour
	{
		[SerializeField] private bool _visible = true;
		[SerializeField] private Color _lineColor = MoreColors.pastellightgray;

		[SerializeField] [Min(0f)] private float _forceFactor = 1f;
		[SerializeField] private ForceMode _forceMode = ForceMode.Force;
		[SerializeField] private Rigidbody[] _bodies = {};




		#region Events


			#if UNITY_EDITOR
			private void FixedUpdate()
			{
				foreach (Rigidbody body in this._bodies) {
					Vector3 forceVector = base.transform.position - body.transform.position;
					body.AddForce((forceVector * this._forceFactor), this._forceMode);
				}
			}
			#endif


			#if UNITY_EDITOR
			private void OnDrawGizmos()
			{
				if (!_visible) return;

				Gizmos.color = this._lineColor;
				foreach (Rigidbody body in this._bodies) {
					Gizmos.DrawLine(body.transform.position, base.transform.position);
				}
			}
			#endif


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
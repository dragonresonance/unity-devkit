#if ENABLE_INPUT_SYSTEM


using DragonResonance.Attributes;
using DragonResonance.Mathematics;
using System.Collections.Generic;
using System;
using UnityEngine.InputSystem;
using UnityEngine;


namespace DragonResonance.GUI
{
	public class ParallaxEffector : MonoBehaviour
	{
		[SerializeField] [Min(0f)] private float _speedFactor = 1f;
		[SerializeField] private float _amplitudeFactor = 1f;
		[SerializeField] private List<ParallaxLayer> ParallaxLayers;

		private Camera _currentCamera = null;
		private Vector2 _mousePositionNormalized = Vector2.zero;
		private Vector2 _mouseOffsetNormalized = Vector2.zero;
		private Vector2 _newRectPosition = default;


		#region Events

			private void Start()
			{
				_currentCamera = Camera.main;
				foreach (ParallaxLayer layer in ParallaxLayers)
					layer.StartPosition = layer.Rect.anchoredPosition;
			}


			private void Update()
			{
				_mousePositionNormalized = Mouse.current.position.ReadValue() - (_currentCamera.pixelRect.size / 2);
				_mouseOffsetNormalized = _currentCamera.ScreenToViewportPoint(_mousePositionNormalized);

				foreach (ParallaxLayer layer in ParallaxLayers) {
					//float layerT = layer.Speed * _speedFactor * Time.deltaTime;

					if (layer.Active) {
						/*_newRectPosition = Vector2.Lerp(
							layer.Rect.anchoredPosition,
							layer.StartPosition + (_mouseOffsetNormalized * (layer.Amplitude * _amplitudeFactor)),
							layerT);*/
						_newRectPosition = MathX.ExponentialDecay(
							layer.Rect.anchoredPosition,
							layer.StartPosition + (_mouseOffsetNormalized * (layer.Amplitude * _amplitudeFactor)),
							layer.Speed * _speedFactor,
							Time.deltaTime);
					}
					else {
						/*_newRectPosition = Vector2.Lerp(
							layer.Rect.anchoredPosition,
							layer.StartPosition,
							layerT);*/
						_newRectPosition = MathX.ExponentialDecay(
							layer.Rect.anchoredPosition,
							layer.StartPosition,
							layer.Speed * _speedFactor,
							Time.deltaTime);
					}

					layer.Rect.anchoredPosition = _newRectPosition;
				}
			}

		#endregion


		#region Objects

			[Serializable]
			public class ParallaxLayer
			{
				public string Name = null;
				public bool Active = true;
				public RectTransform Rect = null;
				[Min(0f)] public float Speed = 2f;
				public float Amplitude = 50f;
				[ReadOnly] public Vector2 StartPosition = Vector2.zero;
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
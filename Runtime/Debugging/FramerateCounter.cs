using DragonResonance.Attributes;
using DragonResonance.Behaviours;
using DragonResonance.Extensions;
using DragonResonance.Mathematics;
using System.Text;
using UnityEngine.Events;
using UnityEngine;


namespace DragonResonance.Debugging
{
	public class FramerateCounter : PossumBehaviour
	{
		[SerializeField] [Min(1)] private int _graceSnapshots = 5;
		[SerializeField] [Min(1)] private int _averageSnapshotCount = 30;
		[SerializeField] [Min(0.001f)] private float _snapshotInterval = 0.75f;
		[SerializeField] [MinMaxRange(1, 9999, true)] private Vector2 _framerateCapRange = new(1, 9999);
		[SerializeField] private UnityEvent<string> _targets = null;
		[ReadOnly] [SerializeField] private float _latestFramerate = 0f;




		private readonly StringBuilder _toStringOutput = new();
		private int _snapshotCount = 0;
		private float _snapshotTime = 0f;
		private float _maxFramerate = 0f;
		private float _minFramerate = 0f;
		private float _averageFramerate = default;


		#region Events

			private void Start() => ResetStats();

			private void Update()
			{
				if ((_snapshotTime += Time.unscaledDeltaTime) >= _snapshotInterval) {
					_latestFramerate = MathX.Framerate(_snapshotCount, _snapshotTime);

					// ReSharper disable once ConditionIsAlwaysTrueOrFalse
					if (_graceSnapshots > 0) {
						_graceSnapshots--;
						_averageFramerate = _latestFramerate;
					}
					else {
						_averageFramerate = _averageFramerate.SumToAverage(_latestFramerate, _averageSnapshotCount);
						_maxFramerate = Mathf.Max(_maxFramerate, _latestFramerate);
						_minFramerate = Mathf.Min(_minFramerate, _latestFramerate);
					}
					_snapshotCount = 0;
					_snapshotTime = 0f;
				}
				_snapshotCount++;
			}

			private void LateUpdate() => this._targets?.Invoke(ToString());

		#endregion


		#region Publics

			[ContextMenu(nameof(ResetStats))]
			public void ResetStats()
			{
				_averageFramerate = 0f;
				_snapshotCount = 0;
				_snapshotTime = 0f;
				_maxFramerate = _framerateCapRange.x;
				_minFramerate = _framerateCapRange.y;
			}

		#endregion


		#region Properties

			public override string ToString()
			{
				_toStringOutput.Clear();
				//_toStringOutput.AppendLine($"DeltaTime:  {(Time.unscaledDeltaTime * 1000f):0.0000}");
				//_toStringOutput.AppendLine($"CalcDTime:  {(1000f / _latestFramerate):0.0000}");
				//_toStringOutput.AppendLine($"SnapCount   {_averageSnapshotCount}");
				//_toStringOutput.AppendLine($"SnapGrace:  T-{_graceSnapshots}");
				//_toStringOutput.AppendLine();
				_toStringOutput.AppendLine($"FPS:        {_latestFramerate:000.0000}");
				_toStringOutput.AppendLine($"MinFPS:     {_minFramerate:000.0000}");
				_toStringOutput.AppendLine($"AvgFPS:     {_averageFramerate:000.0000}");
				_toStringOutput.Append(    $"MaxFPS:     {_maxFramerate:000.0000}");
				return _toStringOutput.ToString();
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
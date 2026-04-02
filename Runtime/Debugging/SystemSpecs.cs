using DragonResonance.Behaviours;
using System.Text;
using UnityEngine.Events;
using UnityEngine;


namespace DragonResonance.Debugging
{
	public class SystemSpecs : PossumBehaviour
	{
		[SerializeField] private UnityEvent<string> _targets = null;


		private readonly StringBuilder _toStringOutput = new();


		#region Events

			private void Start() => Refresh();

		#endregion


		#region Publics

			public void Refresh() => this._targets?.Invoke(ToString());

		#endregion


		#region Properties

			public override string ToString()
			{
				_toStringOutput.Clear();

				_toStringOutput.AppendLine($"OSVersion:  {SystemInfo.operatingSystem}");
				_toStringOutput.AppendLine($"DevType:    {SystemInfo.deviceType}");
				_toStringOutput.AppendLine($"Monitor:    {Screen.currentResolution.ToString()}");
				_toStringOutput.AppendLine();
				_toStringOutput.AppendLine($"ViewRes:    {Screen.width} × {Screen.height}");
				_toStringOutput.AppendLine($"Quality:    {QualitySettings.GetQualityLevel()} ({QualitySettings.names[QualitySettings.GetQualityLevel()]})");
				_toStringOutput.AppendLine($"MaxTexSize: {SystemInfo.maxTextureSize}");
				_toStringOutput.AppendLine($"MaxCmapSiz: {SystemInfo.maxCubemapSize}");
				_toStringOutput.AppendLine();
				_toStringOutput.AppendLine($"CPUModel:   {SystemInfo.processorType}");
				_toStringOutput.AppendLine($"CPUCores:   {SystemInfo.processorCount} @ {SystemInfo.processorFrequency}");
				_toStringOutput.AppendLine($"RAMSize:    {SystemInfo.systemMemorySize}");
				_toStringOutput.AppendLine($"GPUModel:   {SystemInfo.graphicsDeviceVendor} {SystemInfo.graphicsDeviceName}");
				_toStringOutput.AppendLine($"GPUVersion: {SystemInfo.graphicsDeviceVersion}");
				_toStringOutput.AppendLine($"GPUMemSize: {SystemInfo.graphicsMemorySize}");
				_toStringOutput.AppendLine($"GPUShdrLvl: {SystemInfo.graphicsShaderLevel}");

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
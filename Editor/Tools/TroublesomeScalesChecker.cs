#if UNITY_EDITOR


using DragonResonance.Logging;
using UnityEditor;
using UnityEngine;
using UnityObject = UnityEngine.Object;


namespace DragonResonance.Editor.Tools
{
	public static class TroublesomeScalesChecker
	{
		private static int _zeroScaleCount = 0;
		private static int _troublesomeScaleCount = 0;


		#region Publics

			[MenuItem("Tools/Dragon Resonance/Optimization/Check scene for troublesome scales")]
			public static void CheckSceneForTroublesomeScales()
			{
				HLogger.LogInfo("Checking scene for troublesome scales...", typeof(TroublesomeScalesChecker));
				{
					Transform[] sceneTransforms = UnityObject.FindObjectsByType<Transform>(FindObjectsInactive.Include, FindObjectsSortMode.None);

					foreach (Transform transform in sceneTransforms) {
						Vector3 transformLocalScale = transform.localScale;

						if (CheckForZeroScale(transformLocalScale)) {
							HLogger.LogInfo($"Has an <color={HLogger.Severity.INFO}><b>all-zero</b></color> scale", transform);
							_zeroScaleCount++;
							continue;
						}

						if (!CheckForUnitScale(transformLocalScale)) {
							HLogger.LogWarning($"Has a <color={HLogger.Severity.WARN}><b>troublesome</b></color> scale <b>→ [ x:<color={HLogger.Severity.WARN}>{transformLocalScale.x}</color>, y:<color={HLogger.Severity.WARN}>{transformLocalScale.y}</color>, z:<color={HLogger.Severity.WARN}>{transformLocalScale.z}</color> ]</b>", transform);
							_troublesomeScaleCount++;
							continue;
						}
					}

					HLogger.LogEmphasis($"Analyzed {sceneTransforms.Length} scene scales", typeof(TroublesomeScalesChecker));
					HLogger.LogEmphasis($"Detected {_zeroScaleCount} all-zero scales", typeof(TroublesomeScalesChecker));
					HLogger.LogEmphasis($"Detected {_troublesomeScaleCount} troublesome scales", typeof(TroublesomeScalesChecker));
				}
				HLogger.LogInfo("Done!", typeof(TroublesomeScalesChecker));
			}

		#endregion


		#region Privates

			private static bool CheckForZeroScale(Vector3 scale)
			{
				return (Mathf.Approximately(scale.x, 0f) &&
				        Mathf.Approximately(scale.y, 0f) &&
				        Mathf.Approximately(scale.z, 0f));
			}

			private static bool CheckForUnitScale(Vector3 scale)
			{
				return (Mathf.Approximately(scale.x, 1f) &&
				        Mathf.Approximately(scale.y, 1f) &&
				        Mathf.Approximately(scale.z, 1f));
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
/*                  Copyright © 2021-2025. All rights reserved.                 */
/*                Licensed under the Apache License, Version 2.0.               */
/*                         See LICENSE.md for more info.                        */
/*       ________________________________________________________________       */
/*                                                                              */
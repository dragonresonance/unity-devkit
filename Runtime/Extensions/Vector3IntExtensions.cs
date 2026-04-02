using UnityEngine;


namespace DragonResonance.Extensions
{
	public static class Vector3IntExtensions
	{
		#region Properties - Operations

			public static Vector3 CalculateNormalized(this Vector3Int vector3int) => (new Vector3(vector3int.x, vector3int.y, vector3int.z)).normalized;

		#endregion


		#region Properties - Casts

			public static Vector2 ToVector2(this Vector3Int vector) => new Vector2(vector.x, vector.y);
			public static Vector2Int ToVector2Int(this Vector3Int vector) => new Vector2Int(vector.x, vector.y);
			public static Vector3 ToVector3(this Vector3Int vector) => new Vector3(vector.x, vector.y, vector.z);
			public static Vector3Int ToVector3Int(this Vector3Int vector) => new Vector3Int(vector.x, vector.y, vector.z);

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
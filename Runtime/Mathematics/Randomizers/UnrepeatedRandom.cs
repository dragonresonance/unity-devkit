using System.Collections.Generic;
using System.Security.Cryptography;
using System;


namespace DragonResonance.Mathematics.Randomizers
{
	public class UnrepeatedRandom
	{
		private uint _seed = 0;
		private Random _randomizer = null;
		private HashSet<int> _used = null;


		#region Constructors

			public UnrepeatedRandom() : this(RandomNumberGenerator.GetInt32(int.MaxValue)) { }
			public UnrepeatedRandom(uint seed) : this((int)seed) { }
			public UnrepeatedRandom(int seed)
			{
				_seed = (uint)seed;
				_randomizer = new Random(seed);
				_used = new HashSet<int>();
			}

		#endregion


		#region Publics

			public int Generate(int maxExclusive) => Generate(0, maxExclusive);
			public int Generate(int minInclusive, int maxExclusive)
			{
				int next = default;
				do next = _randomizer.Next(minInclusive, maxExclusive);
				while (_used.Contains(next));

				_used.Add(next);
				return next;
			}

		#endregion


		#region Properties

			public uint Seed => _seed;

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
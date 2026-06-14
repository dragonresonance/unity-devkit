using System;


namespace DragonResonance.Serializables
{
	[Serializable]
	public struct SerializableItemGroup<T1, T2>
	{
		public T1 First;
		public T2 Second;

		public SerializableItemGroup(T1 first, T2 second)
		{
			First = first;
			Second = second;
		}

		public static implicit operator (T1, T2)(SerializableItemGroup<T1, T2> item) =>
			(item.First, item.Second);
		public static implicit operator SerializableItemGroup<T1, T2>((T1, T2) item) =>
			new(item.Item1, item.Item2);
	}


	[Serializable]
	public struct SerializableItemGroup<T1, T2, T3>
	{
		public T1 First;
		public T2 Second;
		public T3 Third;

		public SerializableItemGroup(T1 first, T2 second, T3 third)
		{
			First = first;
			Second = second;
			Third = third;
		}

		public static implicit operator (T1, T2, T3)(SerializableItemGroup<T1, T2, T3> item) =>
			(item.First, item.Second, item.Third);
		public static implicit operator SerializableItemGroup<T1, T2, T3>((T1, T2, T3) item) =>
			new(item.Item1, item.Item2, item.Item3);
	}


	[Serializable]
	public struct SerializableItemGroup<T1, T2, T3, T4>
	{
		public T1 First;
		public T2 Second;
		public T3 Third;
		public T4 Fourth;

		public SerializableItemGroup(T1 first, T2 second, T3 third, T4 fourth)
		{
			First = first;
			Second = second;
			Third = third;
			Fourth = fourth;
		}

		public static implicit operator (T1, T2, T3, T4)(SerializableItemGroup<T1, T2, T3, T4> item) =>
			(item.First, item.Second, item.Third, item.Fourth);
		public static implicit operator SerializableItemGroup<T1, T2, T3, T4>((T1, T2, T3, T4) item) =>
			new(item.Item1, item.Item2, item.Item3, item.Item4);
	}


	[Serializable]
	public struct SerializableItemGroup<T1, T2, T3, T4, T5>
	{
		public T1 First;
		public T2 Second;
		public T3 Third;
		public T4 Fourth;
		public T5 Fifth;

		public SerializableItemGroup(T1 first, T2 second, T3 third, T4 fourth, T5 fifth)
		{
			First = first;
			Second = second;
			Third = third;
			Fourth = fourth;
			Fifth = fifth;
		}

		public static implicit operator (T1, T2, T3, T4, T5)(SerializableItemGroup<T1, T2, T3, T4, T5> item) =>
			(item.First, item.Second, item.Third, item.Fourth, item.Fifth);
		public static implicit operator SerializableItemGroup<T1, T2, T3, T4, T5>((T1, T2, T3, T4, T5) item) =>
			new(item.Item1, item.Item2, item.Item3, item.Item4, item.Item5);
	}


	[Serializable]
	public struct SerializableItemGroup<T1, T2, T3, T4, T5, T6>
	{
		public T1 First;
		public T2 Second;
		public T3 Third;
		public T4 Fourth;
		public T5 Fifth;
		public T6 Sixth;

		public SerializableItemGroup(T1 first, T2 second, T3 third, T4 fourth, T5 fifth, T6 sixth)
		{
			First = first;
			Second = second;
			Third = third;
			Fourth = fourth;
			Fifth = fifth;
			Sixth = sixth;
		}

		public static implicit operator (T1, T2, T3, T4, T5, T6)(SerializableItemGroup<T1, T2, T3, T4, T5, T6> item) =>
			(item.First, item.Second, item.Third, item.Fourth, item.Fifth, item.Sixth);
		public static implicit operator SerializableItemGroup<T1, T2, T3, T4, T5, T6>((T1, T2, T3, T4, T5, T6) item) =>
			new(item.Item1, item.Item2, item.Item3, item.Item4, item.Item5, item.Item6);
	}


	[Serializable]
	public struct SerializableItemGroup<T1, T2, T3, T4, T5, T6, T7>
	{
		public T1 First;
		public T2 Second;
		public T3 Third;
		public T4 Fourth;
		public T5 Fifth;
		public T6 Sixth;
		public T7 Seventh;

		public SerializableItemGroup(T1 first, T2 second, T3 third, T4 fourth, T5 fifth, T6 sixth, T7 seventh)
		{
			First = first;
			Second = second;
			Third = third;
			Fourth = fourth;
			Fifth = fifth;
			Sixth = sixth;
			Seventh = seventh;
		}

		public static implicit operator (T1, T2, T3, T4, T5, T6, T7)(SerializableItemGroup<T1, T2, T3, T4, T5, T6, T7> item) =>
			(item.First, item.Second, item.Third, item.Fourth, item.Fifth, item.Sixth, item.Seventh);
		public static implicit operator SerializableItemGroup<T1, T2, T3, T4, T5, T6, T7>((T1, T2, T3, T4, T5, T6, T7) item) =>
			new(item.Item1, item.Item2, item.Item3, item.Item4, item.Item5, item.Item6, item.Item7);
	}


	[Serializable]
	public struct SerializableItemGroup<T1, T2, T3, T4, T5, T6, T7, T8>
	{
		public T1 First;
		public T2 Second;
		public T3 Third;
		public T4 Fourth;
		public T5 Fifth;
		public T6 Sixth;
		public T7 Seventh;
		public T8 Eighth;

		public SerializableItemGroup(T1 first, T2 second, T3 third, T4 fourth, T5 fifth, T6 sixth, T7 seventh, T8 eighth)
		{
			First = first;
			Second = second;
			Third = third;
			Fourth = fourth;
			Fifth = fifth;
			Sixth = sixth;
			Seventh = seventh;
			Eighth = eighth;
		}

		public static implicit operator (T1, T2, T3, T4, T5, T6, T7, T8)(SerializableItemGroup<T1, T2, T3, T4, T5, T6, T7, T8> item) =>
			(item.First, item.Second, item.Third, item.Fourth, item.Fifth, item.Sixth, item.Seventh, item.Eighth);
		public static implicit operator SerializableItemGroup<T1, T2, T3, T4, T5, T6, T7, T8>((T1, T2, T3, T4, T5, T6, T7, T8) item) =>
			new(item.Item1, item.Item2, item.Item3, item.Item4, item.Item5, item.Item6, item.Item7, item.Item8);
	}


	[Serializable]
	public struct SerializableItemGroup<T1, T2, T3, T4, T5, T6, T7, T8, T9>
	{
		public T1 First;
		public T2 Second;
		public T3 Third;
		public T4 Fourth;
		public T5 Fifth;
		public T6 Sixth;
		public T7 Seventh;
		public T8 Eighth;
		public T9 Ninth;

		public SerializableItemGroup(T1 first, T2 second, T3 third, T4 fourth, T5 fifth, T6 sixth, T7 seventh, T8 eighth, T9 ninth)
		{
			First = first;
			Second = second;
			Third = third;
			Fourth = fourth;
			Fifth = fifth;
			Sixth = sixth;
			Seventh = seventh;
			Eighth = eighth;
			Ninth = ninth;
		}

		public static implicit operator (T1, T2, T3, T4, T5, T6, T7, T8, T9)(SerializableItemGroup<T1, T2, T3, T4, T5, T6, T7, T8, T9> item) =>
			(item.First, item.Second, item.Third, item.Fourth, item.Fifth, item.Sixth, item.Seventh, item.Eighth, item.Ninth);
		public static implicit operator SerializableItemGroup<T1, T2, T3, T4, T5, T6, T7, T8, T9>((T1, T2, T3, T4, T5, T6, T7, T8, T9) item) =>
			new(item.Item1, item.Item2, item.Item3, item.Item4, item.Item5, item.Item6, item.Item7, item.Item8, item.Item9);
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
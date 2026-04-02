#if UNITY_EDITOR


using DragonResonance.Attributes;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEditor;
using UnityObject = UnityEngine.Object;


namespace DragonResonance.Editor.Attributes
{
	[InitializeOnLoad]
	[CustomPropertyDrawer(typeof(TypeFilterAttribute))]
	public class TypeFilterDrawer : ADropdownArrayAttributeDrawer
	{
		private static List<Type> _types;

		static TypeFilterDrawer()
		{
			AssemblyReloadEvents.afterAssemblyReload += OnAfterAssemblyReload;
		}

		static void OnAfterAssemblyReload()
		{
			_types = AppDomain.CurrentDomain.GetAssemblies()
				.SelectMany(assembly => assembly.GetTypes())
				.Where(type => !type.IsAbstract && !type.IsInterface)
				.ToList();
		}

		protected override string[] GetItems(SerializedProperty property)
		{
			TypeFilterAttribute typeFilterAttribute = (TypeFilterAttribute)base.attribute;
			if (typeFilterAttribute == null)
				return Array.Empty<string>();

			return _types
				.Where(type => typeFilterAttribute.BaseType.IsAssignableFrom(type))
				.Select(type => type.AssemblyQualifiedName)
				.Prepend(string.Empty)
				.ToArray();
		}
	}
}


#endif


/*                                                                              */
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
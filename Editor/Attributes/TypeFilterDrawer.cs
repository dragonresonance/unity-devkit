#if UNITY_EDITOR


using DragonResonance.Attributes;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEditor;
using UnityEngine;


namespace DragonResonance.Editor.Attributes
{
	[CustomPropertyDrawer(typeof(TypeFilterAttribute))]
	public class TypeFilterDrawer : PropertyDrawer
	{
		private List<Type> _types;

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			if (_types == null) {
				TypeFilterAttribute filter = (TypeFilterAttribute)attribute;
				_types = AppDomain.CurrentDomain.GetAssemblies()
					.SelectMany(assembly => assembly.GetTypes())
					.Where(type => filter.BaseType.IsAssignableFrom(type) && !type.IsAbstract && !type.IsInterface)
					.ToList();
			}

			EditorGUI.BeginProperty(position, label, property);
			{
				EditorGUI.BeginChangeCheck();
				string[] typeNames = _types.Select(t => t.Name).ToArray();
				int currentIndex = Mathf.Max(0, _types.FindIndex(type => type.AssemblyQualifiedName == property.stringValue));
				int selectedIndex = EditorGUI.Popup(position, label.text, currentIndex, typeNames);
				if (EditorGUI.EndChangeCheck())
					property.stringValue = _types[selectedIndex].AssemblyQualifiedName;
			}
			EditorGUI.EndProperty();
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
/*                  Copyright © 2021-2025. All rights reserved.                 */
/*                Licensed under the Apache License, Version 2.0.               */
/*                         See LICENSE.md for more info.                        */
/*       ________________________________________________________________       */
/*                                                                              */
#if UNITY_EDITOR


using DragonResonance.Extensions;
using System;
using UnityEditor;
using UnityEngine;


namespace DragonResonance.Editor.Attributes
{
	public class ADropdownArrayAttributeDrawer : PropertyDrawer
	{
		protected virtual string[] GetItems(SerializedProperty property) => Array.Empty<string>();	// The method to override and retrieve the items

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			string[] items = GetItems(property);

			if (items.Length.IsZero()) {
				EditorGUI.HelpBox(position, $"{this.GetType().Name} has zero items", MessageType.Warning);
				return;
			}

			EditorGUI.BeginProperty(position, label, property);
			{
				EditorGUI.BeginChangeCheck();
				int currentIndex = Mathf.Max(0, Array.IndexOf(items, property.stringValue));
				int selectedIndex = EditorGUI.Popup(position, label.text, currentIndex, items);
				if (EditorGUI.EndChangeCheck())
					property.stringValue = items[selectedIndex];
			}
			EditorGUI.EndProperty();
		}
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
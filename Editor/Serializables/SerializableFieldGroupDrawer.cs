#if UNITY_EDITOR


using DragonResonance.Serializables;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;


namespace DragonResonance.Editor.Serializables
{
	[CustomPropertyDrawer(typeof(SerializableKeyValuePair<,>))]
	[CustomPropertyDrawer(typeof(SerializableItemGroup<,>))]
	[CustomPropertyDrawer(typeof(SerializableItemGroup<,,>))]
	[CustomPropertyDrawer(typeof(SerializableItemGroup<,,,>))]
	[CustomPropertyDrawer(typeof(SerializableItemGroup<,,,,>))]
	[CustomPropertyDrawer(typeof(SerializableItemGroup<,,,,,>))]
	[CustomPropertyDrawer(typeof(SerializableItemGroup<,,,,,,>))]
	[CustomPropertyDrawer(typeof(SerializableItemGroup<,,,,,,,>))]
	[CustomPropertyDrawer(typeof(SerializableItemGroup<,,,,,,,,>))]
	public class SerializableFieldGroupDrawer : PropertyDrawer
	{
		private const float SPACING = 4f;


		private static readonly string[] FieldNames = {
			"Key", "Value",
			"First", "Second", "Third", "Fourth", "Fifth", "Sixth", "Seventh", "Eighth", "Ninth",
		};


		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			EditorGUI.BeginProperty(position, label, property);
			{
				position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

				List<SerializedProperty> fields = GetFields(property);
				float fieldWidth = (position.width - SPACING * (fields.Count - 1)) / fields.Count;

				for (int fieldIndex = 0; fieldIndex < fields.Count; fieldIndex++) {
					float positionX = position.x + (fieldIndex * (fieldWidth + SPACING));
					Rect rect = new(positionX, position.y, fieldWidth, EditorGUIUtility.singleLineHeight);
					EditorGUI.PropertyField(rect, fields[fieldIndex], GUIContent.none);
				}
			}
			EditorGUI.EndProperty();
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label) => EditorGUIUtility.singleLineHeight;


		private List<SerializedProperty> GetFields(SerializedProperty property) =>
			FieldNames.Select(property.FindPropertyRelative).Where(prop => (prop != null)).ToList();
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
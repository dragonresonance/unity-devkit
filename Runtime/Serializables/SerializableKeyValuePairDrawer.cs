#if UNITY_EDITOR


using UnityEditor;
using UnityEngine;


namespace DragonResonance.Serializables
{
	[CustomPropertyDrawer(typeof(SerializableKeyValuePair<,>))]
	public class SerializableKeyValuePairDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			EditorGUI.BeginProperty(position, label, property);
			{
				SerializedProperty keyProp = property.FindPropertyRelative("Key");
				SerializedProperty valueProp = property.FindPropertyRelative("Value");

				position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

				float halfWidth = position.width / 2f;
				Rect keyRect = new(position.x, position.y, halfWidth - 2, EditorGUIUtility.singleLineHeight);
				Rect valueRect = new(position.x + halfWidth + 2, position.y, halfWidth - 2, EditorGUIUtility.singleLineHeight);

				EditorGUI.PropertyField(keyRect, keyProp, GUIContent.none);
				EditorGUI.PropertyField(valueRect, valueProp, GUIContent.none);
			}
			EditorGUI.EndProperty();
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label) => EditorGUIUtility.singleLineHeight;
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
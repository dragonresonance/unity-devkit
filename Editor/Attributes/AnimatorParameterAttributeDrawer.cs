#if UNITY_EDITOR


using DragonResonance.Attributes;
using System.Linq;
using System.Reflection;
using System;
using UnityEditor;
using UnityEngine;
using UnityObject = UnityEngine.Object;


namespace DragonResonance.Editor.Attributes
{
	[CustomPropertyDrawer(typeof(AnimatorParameterAttribute))]
	public class AnimatorParameterAttributeDrawer : ADropdownArrayAttributeDrawer
	{
		protected override string[] GetItems(SerializedProperty property)
		{
			AnimatorParameterAttribute animatorParameterAttribute = (AnimatorParameterAttribute)base.attribute;
			if (animatorParameterAttribute == null)
				return Array.Empty<string>();

			UnityObject targetParameterObject = property.serializedObject.targetObject;
			FieldInfo animatorField = targetParameterObject.GetType().GetField(
				animatorParameterAttribute.AnimatorFieldName,
				BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
			if (animatorField == null)
				return Array.Empty<string>();

			Animator animator = (Animator)animatorField.GetValue(targetParameterObject);
			if (animator == null || animator.runtimeAnimatorController == null)
				return Array.Empty<string>();

			return animator.parameters.Select(parameter => parameter.name).ToArray();
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
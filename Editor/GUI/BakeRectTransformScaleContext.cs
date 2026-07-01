#if UNITY_EDITOR


using UnityEditor;
using UnityEngine;


namespace DragonResonance.GUI
{
	public static class BakeRectTransformScaleContext
	{
		[MenuItem("CONTEXT/RectTransform/Bake Scale into Size", validate = true)]
		private static bool BakeScaleValidate(MenuCommand command)
		{
			RectTransform rectTransform = (RectTransform)command.context;
			return (rectTransform.localScale != Vector3.one);
		}


		[MenuItem("CONTEXT/RectTransform/Bake Scale into Size")]
		private static void BakeScale(MenuCommand command)
		{
			RectTransform rectTransform = (RectTransform)command.context;
			Vector3 currentScale = rectTransform.localScale;

			if (currentScale == Vector3.one)
				return;

			Undo.RecordObject(rectTransform, "Bake Scale into Size");

			Vector2 sizeDelta = rectTransform.sizeDelta;
			sizeDelta = new Vector2(
				sizeDelta.x * currentScale.x,
				sizeDelta.y * currentScale.y
			);
			rectTransform.sizeDelta = sizeDelta;
			rectTransform.localScale = Vector3.one;

			EditorUtility.SetDirty(rectTransform);
			Debug.Log($"Baked {rectTransform.name} scale {currentScale} into sizeDelta {sizeDelta}");
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
/*                  Copyright © 2021-2026. All rights reserved.                 */
/*                Licensed under the Apache License, Version 2.0.               */
/*                         See LICENSE.md for more info.                        */
/*       ________________________________________________________________       */
/*                                                                              */
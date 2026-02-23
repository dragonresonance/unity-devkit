using DragonResonance.Behaviours;
using DragonResonance.Extensions;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


namespace DragonResonance.GUI
{
	[RequireComponent(typeof(Selectable))]
	public class SelectableAutoColoringTool : PossumBehaviour
	{
		[SerializeField] private bool _includeChildSelectables = false;
		[SerializeField] private bool _includeChildImages = false;
		[HideInInspector] [SerializeField] private Color _cachedBaseColor = Color.white;


		private Selectable _selectable_internal = null;	// Caching only, use the property instead


		#region Publics

			[ContextMenu(nameof(ApplyColoring))]
			public void ApplyColoring() => ApplyColoring(_cachedBaseColor);
			public void ApplyColoring(Color newBaseColor)
			{
				_cachedBaseColor = newBaseColor;

				HashSet<Selectable> selectableTargets = new() { this.Selectable };
				if (_includeChildSelectables)
					selectableTargets.UnionWith(GetComponentsInChildren<Selectable>());
				ColorSelectables(newBaseColor, selectableTargets);

				HashSet<Image> imageTargets = new();
				if (_includeChildImages)
					imageTargets.UnionWith(GetComponentsInChildren<Image>());
				ColorImages(newBaseColor, imageTargets);
			}

		#endregion


		#region Privates

			private void ColorSelectables(Color color, IEnumerable<Selectable> targets)
			{
				foreach (Selectable target in targets) {
					target.colors = new ColorBlock() {
						normalColor = color.Mask(ColorBlock.defaultColorBlock.normalColor),
						highlightedColor = color.Mask(ColorBlock.defaultColorBlock.highlightedColor).AddLinearBrightness(0.1f),
						pressedColor = color.Mask(color.Mask(ColorBlock.defaultColorBlock.pressedColor)).AddLinearBrightness(0.1f),
						selectedColor = color.Mask(color).AddLinearBrightness(0.1f),
						disabledColor = color.Mask(ColorBlock.defaultColorBlock.disabledColor).ToGreyscale().AddLinearBrightness(0.05f),
						colorMultiplier = target.colors.colorMultiplier,
						fadeDuration = target.colors.fadeDuration,
					};

					#if UNITY_EDITOR
						UnityEditor.EditorUtility.SetDirty(this);
						UnityEditor.EditorUtility.SetDirty(target);
					#endif
				}
			}

			private void ColorImages(Color color, IEnumerable<Image> target)
			{
				foreach (Image selectableTarget in target) {
					selectableTarget.color = color;

					#if UNITY_EDITOR
						UnityEditor.EditorUtility.SetDirty(this);
						UnityEditor.EditorUtility.SetDirty(selectableTarget);
					#endif
				}
			}

		#endregion


		#region Properties

			public Color CachedBaseColor => _cachedBaseColor;
			public Selectable Selectable => (_selectable_internal = GetComponentIfNull(_selectable_internal));

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
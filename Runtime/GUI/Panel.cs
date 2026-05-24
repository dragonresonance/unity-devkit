using DragonResonance.Behaviours;
using DragonResonance.Extensions;
using System.Collections.Generic;
using System;
using UnityEngine;


namespace DragonResonance.GUI
{
	[DisallowMultipleComponent]
	[RequireComponent(typeof(CanvasGroup))]
	public class Panel<T> : PossumBehaviour where T : Panel<T>
	{
		[SerializeField] private bool _alsoHandleInteractivity = true;


		private static readonly List<Panel<T>> _currentPanels = new();
		private CanvasGroup _canvasGroup_internal = null;	// Caching only, use the property instead

		public event Action<bool> OnVisibilityChange;


		#region Events

			protected void Awake() => _currentPanels.Add(this);
			protected void OnDestroy() => _currentPanels.Remove(this);

		#endregion


		#region Publics - Search

			public static TTarget Find<TTarget>() where TTarget : Panel<TTarget> => FindAnyObjectByType<TTarget>();

			protected TTarget SwapTo<TTarget>() where TTarget : Panel<TTarget>
			{
				TTarget target = Find<TTarget>();
				this.Hide();
				target.Show();
				return target;
			}

		#endregion


		#region Publics - Visibility

			public virtual Action<CanvasGroup, bool> CanvasGroupVisibilityChangeAction => (canvasGroup, visible) => { canvasGroup.alpha = visible.AsInt(); };

			[ContextMenu(nameof(Toggle))] public void Toggle() => SetVisibility(Mathf.RoundToInt(this.Alpha.Complementary()).AsBool());
			[ContextMenu(nameof(Show))] public void Show() => SetVisibility(true);
			[ContextMenu(nameof(Hide))] public void Hide() => SetVisibility(false);

			public void SetVisibility(bool visible)
			{
				CanvasGroupVisibilityChangeAction.Invoke(this.CanvasGroup, visible);
				if (_alsoHandleInteractivity)
					this.CanvasGroup.interactable = this.CanvasGroup.blocksRaycasts = visible;
				OnVisibilityChange?.Invoke(visible);
			}

		#endregion


		#region Properties

			public List<Panel<T>> CurrentPanels => _currentPanels;

			public bool IsVisible => Mathf.RoundToInt(this.CanvasGroup.alpha).AsBool();
			public bool IsFullyVisible => this.CanvasGroup.IsFullyVisible();
			public bool IsFullyInvisible => this.CanvasGroup.IsFullyInvisible();
			public float Alpha => this.CanvasGroup.alpha;
			public CanvasGroup CanvasGroup => (_canvasGroup_internal = GetComponentIfNull(_canvasGroup_internal));

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
/*                  Copyright © 2021-2026. All rights reserved.                 */
/*                Licensed under the Apache License, Version 2.0.               */
/*                         See LICENSE.md for more info.                        */
/*       ________________________________________________________________       */
/*                                                                              */
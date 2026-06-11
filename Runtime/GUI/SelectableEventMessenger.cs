using DragonResonance.Behaviours;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class SelectableEventMessenger : PossumBehaviour,
	IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler,
	IInitializePotentialDragHandler, IDragHandler, IBeginDragHandler, IEndDragHandler, IDropHandler,
	IUpdateSelectedHandler, ISelectHandler, IDeselectHandler,
	IScrollHandler, IMoveHandler,
	ISubmitHandler, ICancelHandler
{
	private Selectable _selectable_internal = null;	// Caching only, use the property instead
	private bool _locked = false;


	#region Events

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (_locked) return;
			_locked = true;
			BroadcastMessage(nameof(OnPointerEnter), eventData);
			_locked = false;
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			if (_locked) return;
			_locked = true;
			BroadcastMessage(nameof(OnPointerExit), eventData);
			_locked = false;
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			if (_locked) return;
			_locked = true;
			BroadcastMessage(nameof(OnPointerDown), eventData);
			_locked = false;
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			if (_locked) return;
			_locked = true;
			BroadcastMessage(nameof(OnPointerUp), eventData);
			_locked = false;
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			if (_locked) return;
			_locked = true;
			BroadcastMessage(nameof(OnPointerClick), eventData);
			_locked = false;
		}

		public void OnInitializePotentialDrag(PointerEventData eventData)
		{
			if (_locked) return;
			_locked = true;
			BroadcastMessage(nameof(OnInitializePotentialDrag), eventData);
			_locked = false;
		}

		public void OnDrag(PointerEventData eventData)
		{
			if (_locked) return;
			_locked = true;
			BroadcastMessage(nameof(OnDrag), eventData);
			_locked = false;
		}

		public void OnBeginDrag(PointerEventData eventData)
		{
			if (_locked) return;
			_locked = true;
			BroadcastMessage(nameof(OnBeginDrag), eventData);
			_locked = false;
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			if (_locked) return;
			_locked = true;
			BroadcastMessage(nameof(OnEndDrag), eventData);
			_locked = false;
		}

		public void OnDrop(PointerEventData eventData)
		{
			if (_locked) return;
			_locked = true;
			BroadcastMessage(nameof(OnDrop), eventData);
			_locked = false;
		}

		public void OnUpdateSelected(BaseEventData eventData)
		{
			if (_locked) return;
			_locked = true;
			BroadcastMessage(nameof(OnUpdateSelected), eventData);
			_locked = false;
		}

		public void OnSelect(BaseEventData eventData)
		{
			if (_locked) return;
			_locked = true;
			BroadcastMessage(nameof(OnSelect), eventData);
			_locked = false;
		}

		public void OnDeselect(BaseEventData eventData)
		{
			if (_locked) return;
			_locked = true;
			BroadcastMessage(nameof(OnDeselect), eventData);
			_locked = false;
		}

		public void OnScroll(PointerEventData eventData)
		{
			if (_locked) return;
			_locked = true;
			BroadcastMessage(nameof(OnScroll), eventData);
			_locked = false;
		}

		public void OnMove(AxisEventData eventData)
		{
			if (_locked) return;
			_locked = true;
			BroadcastMessage(nameof(OnMove), eventData);
			_locked = false;
		}

		public void OnSubmit(BaseEventData eventData)
		{
			if (_locked) return;
			_locked = true;
			BroadcastMessage(nameof(OnSubmit), eventData);
			_locked = false;
		}

		public void OnCancel(BaseEventData eventData)
		{
			if (_locked) return;
			_locked = true;
			BroadcastMessage(nameof(OnCancel), eventData);
			_locked = false;
		}

	#endregion


	#region Properties

		public Selectable Selectable => (_selectable_internal = GetComponentIfNull(_selectable_internal));

	#endregion
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
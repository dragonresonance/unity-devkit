using DragonResonance.Behaviours;
using DragonResonance.Extensions;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;


public class SelectableHandlerInvoker : PossumBehaviour,
	IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler,
	IInitializePotentialDragHandler, IDragHandler, IBeginDragHandler, IEndDragHandler, IDropHandler,
	IUpdateSelectedHandler, ISelectHandler, IDeselectHandler,
	IScrollHandler, IMoveHandler,
	ISubmitHandler, ICancelHandler
{
	[SerializeField] private bool _childrenOnly = false;	// Caching only, use the property instead


	private Selectable _selectable_internal = null;	// Caching only, use the property instead
	private bool _locked = false;


	#region Events

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (_locked) return;
			_locked = true;
			foreach (Transform child in base.children)
				child.GetComponentsInChildren<IPointerEnterHandler>().ForEach(handler => handler.OnPointerEnter(eventData));
			if (!_childrenOnly)
				GetComponents<IPointerEnterHandler>().ForEach(handler => handler.OnPointerEnter(eventData));
			_locked = false;
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			if (_locked) return;
			_locked = true;
			foreach (Transform child in base.children)
				child.GetComponentsInChildren<IPointerExitHandler>().ForEach(handler => handler.OnPointerExit(eventData));
			if (!_childrenOnly)
				GetComponents<IPointerExitHandler>().ForEach(handler => handler.OnPointerExit(eventData));
			_locked = false;
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			if (_locked) return;
			_locked = true;
			foreach (Transform child in base.children)
				child.GetComponentsInChildren<IPointerDownHandler>().ForEach(handler => handler.OnPointerDown(eventData));
			if (!_childrenOnly)
				GetComponents<IPointerDownHandler>().ForEach(handler => handler.OnPointerDown(eventData));
			_locked = false;
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			if (_locked) return;
			_locked = true;
			foreach (Transform child in base.children)
				child.GetComponentsInChildren<IPointerUpHandler>().ForEach(handler => handler.OnPointerUp(eventData));
			if (!_childrenOnly)
				GetComponents<IPointerUpHandler>().ForEach(handler => handler.OnPointerUp(eventData));
			_locked = false;
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			if (_locked) return;
			_locked = true;
			foreach (Transform child in base.children)
				child.GetComponentsInChildren<IPointerClickHandler>().ForEach(handler => handler.OnPointerClick(eventData));
			if (!_childrenOnly)
				GetComponents<IPointerClickHandler>().ForEach(handler => handler.OnPointerClick(eventData));
			_locked = false;
		}

		public void OnInitializePotentialDrag(PointerEventData eventData)
		{
			if (_locked) return;
			_locked = true;
			foreach (Transform child in base.children)
				child.GetComponentsInChildren<IInitializePotentialDragHandler>().ForEach(handler => handler.OnInitializePotentialDrag(eventData));
			if (!_childrenOnly)
				GetComponents<IInitializePotentialDragHandler>().ForEach(handler => handler.OnInitializePotentialDrag(eventData));
			_locked = false;
		}

		public void OnDrag(PointerEventData eventData)
		{
			if (_locked) return;
			_locked = true;
			foreach (Transform child in base.children)
				child.GetComponentsInChildren<IDragHandler>().ForEach(handler => handler.OnDrag(eventData));
			if (!_childrenOnly)
				GetComponents<IDragHandler>().ForEach(handler => handler.OnDrag(eventData));
			_locked = false;
		}

		public void OnBeginDrag(PointerEventData eventData)
		{
			if (_locked) return;
			_locked = true;
			foreach (Transform child in base.children)
				child.GetComponentsInChildren<IBeginDragHandler>().ForEach(handler => handler.OnBeginDrag(eventData));
			if (!_childrenOnly)
				GetComponents<IBeginDragHandler>().ForEach(handler => handler.OnBeginDrag(eventData));
			_locked = false;
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			if (_locked) return;
			_locked = true;
			foreach (Transform child in base.children)
				child.GetComponentsInChildren<IEndDragHandler>().ForEach(handler => handler.OnEndDrag(eventData));
			if (!_childrenOnly)
				GetComponents<IEndDragHandler>().ForEach(handler => handler.OnEndDrag(eventData));
			_locked = false;
		}

		public void OnDrop(PointerEventData eventData)
		{
			if (_locked) return;
			_locked = true;
			foreach (Transform child in base.children)
				child.GetComponentsInChildren<IDropHandler>().ForEach(handler => handler.OnDrop(eventData));
			if (!_childrenOnly)
				GetComponents<IDropHandler>().ForEach(handler => handler.OnDrop(eventData));
			_locked = false;
		}

		public void OnUpdateSelected(BaseEventData eventData)
		{
			if (_locked) return;
			_locked = true;
			foreach (Transform child in base.children)
				child.GetComponentsInChildren<IUpdateSelectedHandler>().ForEach(handler => handler.OnUpdateSelected(eventData));
			if (!_childrenOnly)
				GetComponents<IUpdateSelectedHandler>().ForEach(handler => handler.OnUpdateSelected(eventData));
			_locked = false;
		}

		public void OnSelect(BaseEventData eventData)
		{
			if (_locked) return;
			_locked = true;
			foreach (Transform child in base.children)
				child.GetComponentsInChildren<ISelectHandler>().ForEach(handler => handler.OnSelect(eventData));
			if (!_childrenOnly)
				GetComponents<ISelectHandler>().ForEach(handler => handler.OnSelect(eventData));
			_locked = false;
		}

		public void OnDeselect(BaseEventData eventData)
		{
			if (_locked) return;
			_locked = true;
			foreach (Transform child in base.children)
				child.GetComponentsInChildren<IDeselectHandler>().ForEach(handler => handler.OnDeselect(eventData));
			if (!_childrenOnly)
				GetComponents<IDeselectHandler>().ForEach(handler => handler.OnDeselect(eventData));
			_locked = false;
		}

		public void OnScroll(PointerEventData eventData)
		{
			if (_locked) return;
			_locked = true;
			foreach (Transform child in base.children)
				child.GetComponentsInChildren<IScrollHandler>().ForEach(handler => handler.OnScroll(eventData));
			if (!_childrenOnly)
				GetComponents<IScrollHandler>().ForEach(handler => handler.OnScroll(eventData));
			_locked = false;
		}

		public void OnMove(AxisEventData eventData)
		{
			if (_locked) return;
			_locked = true;
			foreach (Transform child in base.children)
				child.GetComponentsInChildren<IMoveHandler>().ForEach(handler => handler.OnMove(eventData));
			if (!_childrenOnly)
				GetComponents<IMoveHandler>().ForEach(handler => handler.OnMove(eventData));
			_locked = false;
		}

		public void OnSubmit(BaseEventData eventData)
		{
			if (_locked) return;
			_locked = true;
			foreach (Transform child in base.children)
				child.GetComponentsInChildren<ISubmitHandler>().ForEach(handler => handler.OnSubmit(eventData));
			if (!_childrenOnly)
				GetComponents<ISubmitHandler>().ForEach(handler => handler.OnSubmit(eventData));
			_locked = false;
		}

		public void OnCancel(BaseEventData eventData)
		{
			if (_locked) return;
			_locked = true;
			foreach (Transform child in base.children)
				child.GetComponentsInChildren<ICancelHandler>().ForEach(handler => handler.OnCancel(eventData));
			if (!_childrenOnly)
				GetComponents<ICancelHandler>().ForEach(handler => handler.OnCancel(eventData));
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
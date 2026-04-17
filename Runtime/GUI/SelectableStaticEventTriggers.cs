using DragonResonance.Behaviours;
using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class SelectableStaticEventTriggers : PossumBehaviour,
	IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler,
	IInitializePotentialDragHandler, IDragHandler, IBeginDragHandler, IEndDragHandler, IDropHandler,
	IUpdateSelectedHandler, ISelectHandler, IDeselectHandler,
	IScrollHandler, IMoveHandler,
	ISubmitHandler, ICancelHandler
{
	private Selectable _selectable_internal = null;	// Caching only, use the property instead

	public static event Action<Selectable> OnPointerEnterEvent = delegate { };
	public static event Action<Selectable> OnPointerExitEvent = delegate { };
	public static event Action<Selectable> OnPointerDownEvent = delegate { };
	public static event Action<Selectable> OnPointerUpEvent = delegate { };
	public static event Action<Selectable> OnPointerClickEvent = delegate { };
	public static event Action<Selectable> OnInitializePotentialDragEvent = delegate { };
	public static event Action<Selectable> OnDragEvent = delegate { };
	public static event Action<Selectable> OnBeginDragEvent = delegate { };
	public static event Action<Selectable> OnEndDragEvent = delegate { };
	public static event Action<Selectable> OnDropEvent = delegate { };
	public static event Action<Selectable> OnUpdateSelectedEvent = delegate { };
	public static event Action<Selectable> OnSelectEvent = delegate { };
	public static event Action<Selectable> OnDeselectEvent = delegate { };
	public static event Action<Selectable> OnScrollEvent = delegate { };
	public static event Action<Selectable> OnMoveEvent = delegate { };
	public static event Action<Selectable> OnSubmitEvent = delegate { };
	public static event Action<Selectable> OnCancelEvent = delegate { };


	#region Events

		public void OnPointerEnter(PointerEventData eventData) => OnPointerEnterEvent?.Invoke(this.Selectable);
		public void OnPointerExit(PointerEventData eventData) => OnPointerExitEvent?.Invoke(this.Selectable);
		public void OnPointerDown(PointerEventData eventData) => OnPointerDownEvent?.Invoke(this.Selectable);
		public void OnPointerUp(PointerEventData eventData) => OnPointerUpEvent?.Invoke(this.Selectable);
		public void OnPointerClick(PointerEventData eventData) => OnPointerClickEvent?.Invoke(this.Selectable);
		public void OnInitializePotentialDrag(PointerEventData eventData) => OnInitializePotentialDragEvent?.Invoke(this.Selectable);
		public void OnDrag(PointerEventData eventData) => OnDragEvent?.Invoke(this.Selectable);
		public void OnBeginDrag(PointerEventData eventData) => OnBeginDragEvent?.Invoke(this.Selectable);
		public void OnEndDrag(PointerEventData eventData) => OnEndDragEvent?.Invoke(this.Selectable);
		public void OnDrop(PointerEventData eventData) => OnDropEvent?.Invoke(this.Selectable);
		public void OnUpdateSelected(BaseEventData eventData) => OnUpdateSelectedEvent?.Invoke(this.Selectable);
		public void OnSelect(BaseEventData eventData) => OnSelectEvent?.Invoke(this.Selectable);
		public void OnDeselect(BaseEventData eventData) => OnDeselectEvent?.Invoke(this.Selectable);
		public void OnScroll(PointerEventData eventData) => OnScrollEvent?.Invoke(this.Selectable);
		public void OnMove(AxisEventData eventData) => OnMoveEvent?.Invoke(this.Selectable);
		public void OnSubmit(BaseEventData eventData) => OnSubmitEvent?.Invoke(this.Selectable);
		public void OnCancel(BaseEventData eventData) => OnCancelEvent?.Invoke(this.Selectable);

	#endregion

	#region Properties

		public Selectable Selectable => (_selectable_internal = GetComponentIfNull(_selectable_internal));

	#endregion
}


/*                                                                                */
/*        Windmill                                   Copyright © 2025-2026        */
/*        Praenaris                                    All rights reserved        */
/*                                                                                */
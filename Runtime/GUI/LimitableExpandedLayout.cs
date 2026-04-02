using DragonResonance.Attributes;
using DragonResonance.Extensions;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;




namespace DragonResonance.GUI
{
	[AddComponentMenu("Layout/Limitable Expanded Layout")]
	[ExecuteAlways]
	public class LimitableExpandedLayout : UIBehaviour, ILayoutSelfController
	{
		[Header("Horizontal")]
		[SerializeField] private bool _handleMaxWidth = false;
		[ShowIf(nameof(_handleMaxWidth))] [SerializeField] private Vector2 _horizontalMargins = new(8f, 8f);
		[ShowIf(nameof(_handleMaxWidth))] [SerializeField] private float _horizontalOffset = 0f;
		[ShowIf(nameof(_handleMaxWidth))] [SerializeField] [Min(0)] private float _maxWidth = 800f;

		[Header("Vertical")]
		[SerializeField] private bool _handleMaxHeight = false;
		[ShowIf(nameof(_handleMaxHeight))] [SerializeField] private Vector2 _verticalMargins = new(8f, 8f);
		[ShowIf(nameof(_handleMaxHeight))] [SerializeField] private float _verticalOffset = 0f;
		[ShowIf(nameof(_handleMaxHeight))] [SerializeField] [Min(0)] private float _maxHeight = 400f;


		#pragma warning disable 649
		private DrivenRectTransformTracker m_Tracker;
		#pragma warning restore 649




		#region Events


			#if UNITY_EDITOR
			protected override void OnValidate()
			{
				SetDirty();
			}
			#endif


			protected override void OnEnable()
			{
				base.OnEnable();
				SetDirty();
			}

			protected override void OnDisable()
			{
				m_Tracker.Clear();
				LayoutRebuilder.MarkLayoutForRebuild(rectTransform);
				base.OnDisable();
			}


		#endregion




		#region Publics


			public void SetLayoutHorizontal()
			{
				m_Tracker.Clear();
				if (!_handleMaxWidth) return;

				m_Tracker.Add(this, this.rectTransform, DrivenTransformProperties.AnchorMinX);
				m_Tracker.Add(this, this.rectTransform, DrivenTransformProperties.AnchorMaxX);
				m_Tracker.Add(this, this.rectTransform, DrivenTransformProperties.AnchoredPositionX);
				m_Tracker.Add(this, this.rectTransform, DrivenTransformProperties.SizeDeltaX);

				float anchoredPositionX = ((_horizontalMargins.x + _horizontalOffset) - (_horizontalMargins.y - _horizontalOffset)) / 2f;
				//float marginsWidth = _horizontalMargins.x + _horizontalMargins.y;
				//float finalMaxWidth = _maxWidth - marginsWidth;
				//float widthExcess = this.rectTransform.rect.width - finalMaxWidth;

				Vector2 currentSizeDelta = this.rectTransform.sizeDelta;
				this.rectTransform.anchorMin = new Vector2(0f, this.rectTransform.anchorMin.y);
				this.rectTransform.anchorMax = new Vector2(1f, this.rectTransform.anchorMax.y);
				this.rectTransform.anchoredPosition = new Vector2(anchoredPositionX, this.rectTransform.anchoredPosition.y);
				//this.rectTransform.sizeDelta = new Vector2((currentSizeDelta.x - widthExcess).UpperClamp(marginsWidth), currentSizeDelta.y);
				this.rectTransform.sizeDelta = new Vector2(0f, currentSizeDelta.y);
				this.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, this.rectTransform.rect.width.UpperClamp(_maxWidth));
			}


			public void SetLayoutVertical()
			{
				//m_Tracker.Clear();	// No need, always goes after Horizontal
				if (!_handleMaxHeight) return;

				m_Tracker.Add(this, this.rectTransform, DrivenTransformProperties.AnchorMinY);
				m_Tracker.Add(this, this.rectTransform, DrivenTransformProperties.AnchorMaxY);
				m_Tracker.Add(this, this.rectTransform, DrivenTransformProperties.AnchoredPositionY);
				m_Tracker.Add(this, this.rectTransform, DrivenTransformProperties.SizeDeltaY);

				float anchoredPositionY = -((_verticalMargins.x + _verticalOffset) - (_verticalMargins.y - _verticalOffset)) / 2f;
				//float marginsHeight = _verticalMargins.x + _verticalMargins.y;
				//float finalMaxHeight = _maxHeight - marginsHeight;
				//float heightExcess = this.rectTransform.rect.height - finalMaxHeight;

				Vector2 currentSizeDelta = this.rectTransform.sizeDelta;
				this.rectTransform.anchorMin = new Vector2(this.rectTransform.anchorMin.x, 0f);
				this.rectTransform.anchorMax = new Vector2(this.rectTransform.anchorMax.x, 1f);
				this.rectTransform.anchoredPosition = new Vector2(this.rectTransform.anchoredPosition.x, anchoredPositionY);
				//this.rectTransform.sizeDelta = new Vector2(currentSizeDelta.x, (currentSizeDelta.y - heightExcess).UpperClamp(marginsHeight));
				this.rectTransform.sizeDelta = new Vector2(currentSizeDelta.x, 0f);
				this.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, this.rectTransform.rect.height.UpperClamp(_maxHeight));
			}


		#endregion




		#region Privates


			protected override void OnRectTransformDimensionsChange()
			{
				SetDirty();
			}

			protected void SetDirty()
			{
				if (!IsActive())
					return;

				LayoutRebuilder.MarkLayoutForRebuild(rectTransform);
			}


		#endregion




		#region Properties


			public RectTransform rectTransform => (RectTransform)base.transform;


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
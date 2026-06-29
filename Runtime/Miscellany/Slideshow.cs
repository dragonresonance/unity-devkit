using DragonResonance.Behaviours;
using DragonResonance.Extensions;
using UnityEngine;


public class Slideshow : PossumBehaviour
{
	[SerializeField] private int _slideIndex = 0;
	[SerializeField] private bool _cyclical = true;
	[SerializeField] private GameObject[] _slides = { };


	#region Events

		private void OnValidate() => GoTo(_slideIndex);

	#endregion


	#region Publics

		public void Previous()
		{
			if (_cyclical)
				GoTo(_slideIndex.PreviousCyclic(_slides.Length));
			else
				GoTo((_slideIndex - 1).LowerClamp(this.FirstSlideIndex));
		}

		public void Next()
		{
			if (_cyclical)
				GoTo(_slideIndex.NextCyclic(_slides.Length));
			else
				GoTo((_slideIndex + 1).UpperClamp(this.LastSlideIndex));
		}


		public void GoTo(int index)
		{
			_slideIndex = SanitizedIndex(index);
			UpdateSlide();
		}

	#endregion


	#region Privates

		private int SanitizedIndex(int index) => _slides.IsEmpty() ? -1 : index.Clamp(0, (_slides.Length - 1));

		private void UpdateSlide()
		{
			for (int index = 0; index < _slides.Length; index++)
				_slides[index].SetActive(index == _slideIndex);
		}

	#endregion


	#region Properties

		public int FirstSlideIndex => 0;
		public int LastSlideIndex => _slides.Length - 1;
		public bool IsFirstSlide => (_slideIndex == this.FirstSlideIndex);
		public bool IsLastSlide => (_slideIndex == this.LastSlideIndex);

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
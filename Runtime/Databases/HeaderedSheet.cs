using System.Collections.Generic;
using System.Linq;


namespace PossumScream.Databases
{
	public class HeaderedSheet<T> : Sheet<T>
	{
		#region Constructors

			public HeaderedSheet() { }

			public HeaderedSheet(List<List<T>> data) : base(data) { }

		#endregion


		#region Publics

			public int GetHeadingColumnIndex(T cellContent) => (this.HeadingRow?.IndexOf(cellContent) ?? -1);
			public int GetHeadingRowIndex(T cellContent) => (this.HeadingColumn?.IndexOf(cellContent) ?? -1);


			public bool TryGet(T headingColumn, T headingRow, out T cellContent)
			{
				int columnIndex = GetHeadingColumnIndex(headingColumn);
				int rowIndex = GetHeadingRowIndex(headingRow);

				if ((columnIndex == -1) || (rowIndex == -1)) {
					cellContent = default;
					return false;
				}
				else {
					cellContent = base.Get(columnIndex, rowIndex);
					return true;
				}
			}

			public bool TrySet(T headingColumn, T headingRow, T cellContent)
			{
				int rowIndex = GetHeadingRowIndex(headingRow);
				int columnIndex = GetHeadingColumnIndex(headingColumn);

				if ((columnIndex == -1) || (rowIndex == -1)) {
					return false;
				}
				else {
					base.Set(columnIndex, rowIndex, cellContent);
					return true;
				}
			}

		#endregion


		#region Properties

			public List<T> HeadingColumn => (base._data.Any() ? base._data.Select(row => row.FirstOrDefault()).ToList() : null);	// Returns null if none or empty rows
			public List<T> HeadingRow => base._data.FirstOrDefault();	// Returns null if none

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
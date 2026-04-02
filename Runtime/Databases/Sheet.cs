using System.Collections.Generic;
using System.Linq;


namespace PossumScream.Databases
{
	public partial class Sheet<T>
	{
		protected List<List<T>> _data = new();


		#region Constructors

			public Sheet()
			{
				Clear();
			}

			public Sheet(List<List<T>> data)
			{
				_data = data;
				NormalizeDataMatrix();
			}

		#endregion


		#region Publics

			public void Clear() => _data.Clear();

			public void AddRow() => AddRow(Enumerable.Empty<T>());
			public void AddRow(IEnumerable<T> data)
			{
				_data.Add(data.ToList());
				NormalizeDataMatrix();
			}

			public void AddColumn() => AddColumn(Enumerable.Empty<T>());
			public void AddColumn(IEnumerable<T> data)
			{
				List<T> column = data.ToList();

				int neededRows = column.Count;
				while (_data.Count < neededRows)
					AddRow();

				for (int cellIndex = 0; cellIndex < column.Count; cellIndex++)
					_data[cellIndex].Add(column[cellIndex]);

				NormalizeDataMatrix();
			}

			public T Get(int column, int row) => _data[row][column];
			public void Set(int column, int row, T value) => _data[row][column] = value;

		#endregion


		#region Privates

			private void NormalizeDataMatrix()
			{
				foreach (List<T> row in _data)
					while (row.Count < this.ColumnCount)
						row.Add(default);
			}

		#endregion


		#region Properties

			public int ColumnCount => _data.Max(row => row.Count);
			public int RowCount => _data.Count;

			public T this[int column, int row]
			{
				get => Get(column, row);
				set => Set(column, row, value);
			}

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
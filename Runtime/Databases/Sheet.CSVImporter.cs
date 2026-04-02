using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;


namespace PossumScream.Databases
{
	public partial class Sheet<T>	// CSV Importer
	{
		#region Publics

			public void ImportTSV(string content, string separator = "\t", string delimiter = "\'") => ImportCSV(content, separator, delimiter);
			public void ImportCSV(string content, string separator = ";", string delimiter = "\"")
			{
				Clear();
				JoinCSV(content, separator, delimiter);
			}

			public void JoinTSV(string content, string separator = "\t", string delimiter = "\'") => JoinCSV(content, separator, delimiter);
			public void JoinCSV(string content, string separator = ";", string delimiter = "\"")
			{
				foreach (List<string> row in ParseCSV(content, separator, delimiter))
					AddRow(row.Cast<T>());
			}

		#endregion


		#region Privates

			public IEnumerable<List<string>> ParseCSV(string content, string separator, string delimiter)
			{
				string[] lines = content.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);

				foreach (string line in lines) {
					List<string> row = new();
					if (string.IsNullOrWhiteSpace(line)) {
						yield return row;
						continue;
					}

					StringBuilder current = new();
					bool insideDelimiter = false;
					for (int charIndex = 0; charIndex < line.Length; charIndex++) {
						string character = line[charIndex].ToString();

						if (character == delimiter) {
							//	Escapes quote delimiters ("""hello"" world" → "hello" world)
							if (insideDelimiter && ((charIndex + 1) < line.Length) && (line[charIndex + 1].ToString() == delimiter)) {
								current.Append(delimiter);
								charIndex++; // Skip the escaped character
							}
							else {
								insideDelimiter = !insideDelimiter;
							}
						}
						else if (character == separator && !insideDelimiter) {
							row.Add(current.ToString());
							current.Clear();
						}
						else {
							current.Append(character);
						}
					}

					row.Add(current.ToString());	// Add the last cell's content
					yield return row;
				}
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
/*                  Copyright © 2021-2025. All rights reserved.                 */
/*                Licensed under the Apache License, Version 2.0.               */
/*                         See LICENSE.md for more info.                        */
/*       ________________________________________________________________       */
/*                                                                              */
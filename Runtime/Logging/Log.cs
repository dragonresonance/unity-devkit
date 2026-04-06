using Debug = UnityEngine.Debug;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System;
using UnityObject = UnityEngine.Object;


namespace DragonResonance.Logging
{
	public static class Log
	{
		#region Publics

			[Conditional("ENABLE_LOGGING")]
			public static void Info(string message = "", UnityObject context = null, [CallerMemberName] string callerName = null, [CallerFilePath] string callerPath = null)
			{
				string callerFile = GetFileName(callerPath);
				Debug.Log(FormatForDebug(message, ELogSeverity.INFO, callerName, callerFile), context);
				Console.Out.WriteLine(FormatForConsole(message, ELogSeverity.INFO, callerName, callerFile));
			}


			[Conditional("ENABLE_LOGGING")]
			public static void Emphasis(string message = "", UnityObject context = null, [CallerMemberName] string callerName = null, [CallerFilePath] string callerPath = null)
			{
				string callerFile = GetFileName(callerPath);
				Debug.Log(FormatForDebug(message, ELogSeverity.EMPH, callerName, callerFile), context);
				Console.Out.WriteLine(FormatForConsole(message, ELogSeverity.EMPH, callerName, callerFile));
			}


			[Conditional("ENABLE_LOGGING")]
			public static void Warning(string message = "", UnityObject context = null, [CallerMemberName] string callerName = null, [CallerFilePath] string callerPath = null)
			{
				string callerFile = GetFileName(callerPath);
				Debug.LogWarning(FormatForDebug(message, ELogSeverity.WARN, callerName, callerFile), context);
				Console.Out.WriteLine(FormatForConsole(message, ELogSeverity.WARN, callerName, callerFile));
			}


			[Conditional("ENABLE_LOGGING")]
			public static void Error(string message = "", UnityObject context = null, [CallerMemberName] string callerName = null, [CallerFilePath] string callerPath = null)
			{
				string callerFile = GetFileName(callerPath);
				Debug.LogError(FormatForDebug(message, ELogSeverity.ERR, callerName, callerFile), context);
				Console.Error.WriteLine(FormatForConsole(message, ELogSeverity.ERR, callerName, callerFile));
			}


			[Conditional("ENABLE_LOGGING")]
			public static void Exception(Exception exception, string message = "", UnityObject context = null, [CallerMemberName] string callerName = null, [CallerFilePath] string callerPath = null)
			{
				string callerFile = GetFileName(callerPath);
				Debug.LogError(FormatForDebug(message, ELogSeverity.EXC, callerName, callerFile), context);
				Debug.LogException(exception, context);
				Console.Error.WriteLine(FormatForConsole(message, ELogSeverity.EXC, callerName, callerFile));
			}

		#endregion


		#region Privates

			private static string GetFileName(string filePath) => Path.GetFileNameWithoutExtension(filePath);

			private static string FormatForDebug(string message, ELogSeverity severity, string callerName, string callerClass) =>
				$"<color=#{(int)severity:X}><b>{callerClass}::{callerName} → </b></color>{message}";
			private static string FormatForConsole(string message, ELogSeverity severity, string callerName, string callerClass) =>
				$"{$"[{severity}]", -6} {callerClass}::{callerName} → {message}";

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
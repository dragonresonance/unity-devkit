using DragonResonance.Logging;
using System.Runtime.CompilerServices;
using System;
using UnityEngine;
using UnityObject = UnityEngine.Object;


namespace DragonResonance.Behaviours
{
	public abstract partial class PossumBehaviour	// Logging
	{
		[UnityEngine.Serialization.FormerlySerializedAs("_loggingMask")] [SerializeField] private ELogLevel _logMask = ELogLevel.Info | ELogLevel.Emphasis | ELogLevel.Warning | ELogLevel.Error | ELogLevel.Exception;


		#region Inheritables

			protected void Log(string message, [CallerMemberName] string callerName = null) => Log(message, this, callerName);
			protected void Log(string message, UnityObject context, [CallerMemberName] string callerName = null)
			{
				if (!_logMask.HasFlag(ELogLevel.Info)) return;
				Logging.Log.Info(message, context, callerName);
			}

			protected void Emphasis(string message, [CallerMemberName] string callerName = null) => Emphasis(message, this, callerName);
			protected void Emphasis(string message, UnityObject context, [CallerMemberName] string callerName = null)
			{
				if (!_logMask.HasFlag(ELogLevel.Emphasis)) return;
				Logging.Log.Emphasis(message, context, callerName);
			}

			protected void Warning(string message, [CallerMemberName] string callerName = null) => Warning(message, this, callerName);
			protected void Warning(string message, UnityObject context, [CallerMemberName] string callerName = null)
			{
				if (!_logMask.HasFlag(ELogLevel.Warning)) return;
				Logging.Log.Warning(message, context, callerName);
			}

			protected void Error(string message, [CallerMemberName] string callerName = null) => Error(message, this, callerName);
			protected void Error(string message, UnityObject context, [CallerMemberName] string callerName = null)
			{
				if (!_logMask.HasFlag(ELogLevel.Error)) return;
				Logging.Log.Error(message, context, callerName);
			}

			protected void Exception(Exception exception, string message, [CallerMemberName] string callerName = null) => Exception(exception, message, this, callerName);
			protected void Exception(Exception exception, string message, UnityObject context, [CallerMemberName] string callerName = null)
			{
				if (!_logMask.HasFlag(ELogLevel.Exception)) return;
				Logging.Log.Exception(exception, message, context, callerName);
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
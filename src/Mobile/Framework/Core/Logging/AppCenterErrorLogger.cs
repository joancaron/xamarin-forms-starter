using System;
using System.Collections.Generic;
using EnsureThat;
using JetBrains.Annotations;
using Microsoft.AppCenter.Crashes;

namespace Mobile.Framework.Core.Logging
{
	[Preserve(AllMembers = true)]
	public class AppCenterErrorLogger : IErrorLogger
	{
		/// <inheritdoc />
		public void LogError([NotNull] string error)
		{
			EnsureArg.IsNotNullOrWhiteSpace(error, nameof(error));
			LogException(new Exception(error));
		}

		/// <inheritdoc />
		public void LogException([NotNull] Exception exception)
		{
			EnsureArg.IsNotNull(exception, nameof(exception));
			Crashes.TrackError(exception);
		}

		/// <inheritdoc />
		public void LogException(Exception exception, string message)
		{
			if (string.IsNullOrWhiteSpace(message))
			{
				LogException(exception);
			}

			Crashes.TrackError(
				exception,
				new Dictionary<string, string> {{nameof(message), Truncate(message)}});
		}

		string Truncate(string stringToTruncate)
		{
			return string.IsNullOrWhiteSpace(stringToTruncate)
				? string.Empty
				: stringToTruncate.Substring(0, Math.Min(stringToTruncate.Length, 150));
		}
	}
}

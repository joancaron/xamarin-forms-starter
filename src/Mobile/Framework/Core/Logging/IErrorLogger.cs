using System;

namespace Mobile.Framework.Core.Logging
{
    public interface IErrorLogger
    {
        /// <summary>
        ///     Logs an error eventName
        /// </summary>
        /// <param name="error">
        ///     Error eventName
        /// </param>
        void LogError(string error);

        /// <summary>
        ///     Logs an Exception
        /// </summary>
        /// <param name="exception">
        ///     The exception
        /// </param>
        void LogException(Exception exception);

        /// <summary>
        /// Logs an Exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="message">The eventName.</param>
        void LogException(Exception exception, string message);
    }
}

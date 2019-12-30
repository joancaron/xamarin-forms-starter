using System;
using System.Diagnostics;

namespace Mobile.Framework.Core.Logging
{
    [Preserve(AllMembers = true)]
    public class DebugErrorLogger : IErrorLogger
    {
        private const string Category = "########## ERROR ##########";

        /// <inheritdoc />
        public void LogError(string error)
        {
            Debug.WriteLine(error, Category);
        }

        /// <inheritdoc />
        public void LogException(Exception exception)
        {
            Debug.WriteLine(exception, Category);
        }

        /// <inheritdoc />
        public void LogException(Exception exception, string message)
        {
            Debug.WriteLine(message, Category);
            Debug.WriteLine(exception, Category);
        }
    }
}

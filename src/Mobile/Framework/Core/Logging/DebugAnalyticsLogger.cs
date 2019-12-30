using System.Diagnostics;

namespace Mobile.Framework.Core.Logging
{
    [Preserve(AllMembers = true)]
    public class DebugAnalyticsLogger : IAnalyticsLogger
    {
        private const string Category = "########## ANALYTICS EVENT ##########";

        /// <inheritdoc />
        public void LogEvent(IAnalyticsEvent analyticsEvent)
        {
            Debug.WriteLine(analyticsEvent.ToString(), Category);
        }

        /// <inheritdoc />
        public void LogPageChangedEvent(string pageName)
        {
            Debug.WriteLine($"Page changed : {pageName}", Category);
        }

        /// <inheritdoc />
        public void SetUserContext(IAnalyticsEvent analyticsEvent)
        {
            Debug.WriteLine(analyticsEvent.ToString(), Category);
        }
    }
}

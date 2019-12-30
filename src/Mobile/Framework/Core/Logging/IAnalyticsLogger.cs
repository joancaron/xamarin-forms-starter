namespace Mobile.Framework.Core.Logging
{
    public interface IAnalyticsLogger
    {
        /// <summary>
        /// Logs an analytics event.
        /// </summary>
        /// <param name="analyticsEvent">The analytics event.</param>
        void LogEvent(IAnalyticsEvent analyticsEvent);

        /// <summary>
        /// Logs page changed event.
        /// </summary>
        /// <param name="pageName">Name of the page.</param>
        void LogPageChangedEvent(string pageName);

        /// <summary>
        /// Sets user context for log providers.
        /// </summary>
        /// <param name="analyticsEvent">The analytics event.</param>
        void SetUserContext(IAnalyticsEvent analyticsEvent);
    }
}

using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using EnsureThat;
using JetBrains.Annotations;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;

namespace Mobile.Framework.Core.Logging
{
    [Preserve(AllMembers = true)]
    public class AppCenterAnalyticsLogger : IAnalyticsLogger
    {
        /// <inheritdoc />
        public void LogEvent([NotNull] IAnalyticsEvent analyticsEvent)
        {
            EnsureArg.IsNotNull(analyticsEvent, nameof(analyticsEvent));
            Analytics.TrackEvent(analyticsEvent.Key, analyticsEvent.Properties);
        }

        /// <inheritdoc />
        public void LogPageChangedEvent([NotNull] string pageName)
        {
            EnsureArg.IsNotNull(pageName, nameof(pageName));
            Analytics.TrackEvent("page_changed", new Dictionary<string, string> { { "page", pageName } });
        }

        /// <inheritdoc />
        public void SetUserContext([NotNull] IAnalyticsEvent analyticsEvent)
        {
            EnsureArg.IsNotNull(analyticsEvent, nameof(analyticsEvent));

            AppCenter.SetUserId(analyticsEvent.Key);

            if (analyticsEvent.Properties != null)
            {
                var customProperties = new CustomProperties();

                foreach (var property in analyticsEvent.Properties)
                {
                    // property keys must be normalized for appcenter
                    var keyWords = property.Key.Split('_')
                                           .Select(word => CultureInfo.InvariantCulture.TextInfo.ToTitleCase(word));
                    customProperties.Set(string.Join(string.Empty, keyWords), property.Value);
                }

                AppCenter.SetCustomProperties(customProperties);
            }
        }
    }
}

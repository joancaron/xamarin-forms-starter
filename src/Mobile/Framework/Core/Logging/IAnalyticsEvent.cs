using System;
using System.Collections.Generic;

namespace Mobile.Framework.Core.Logging
{
    public interface IAnalyticsEvent : IDisposable
    {
        string Key { get; set; }

        IDictionary<string, string> Properties { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mobile.Framework.Core.Logging
{
	public class BaseAnalyticsEvent : IDisposable
	{
		public string Key { get; set; }

		public IDictionary<string, string> Properties { get; set; }

		/// <inheritdoc />
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
			}
		}

		/// <inheritdoc />
		public override string ToString()
		{
			var sb = new StringBuilder();

			sb.AppendLine(Key);

			if (Properties?.Any() ?? false)
			{
				foreach (var property in Properties)
				{
					sb.AppendLine($"{property.Key} => {property.Value}");
				}
			}

			return sb.ToString();
		}
	}
}

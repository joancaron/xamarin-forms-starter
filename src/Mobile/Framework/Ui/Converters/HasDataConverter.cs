using System;
using System.Collections;
using System.Globalization;
using Xamarin.Forms;

namespace Mobile.Framework.Ui
{
	public class HasDataConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null)
			{
				return false;
			}

			if (value is string s)
			{
				return !string.IsNullOrWhiteSpace(s);
			}

			return value is IList list ? list.Count > 0 : (object)true;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}

		public static void Init()
		{
			var time = DateTime.UtcNow;
		}
	}
}

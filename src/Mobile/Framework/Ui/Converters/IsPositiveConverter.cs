using System;
using System.Globalization;
using Xamarin.Forms;

namespace Mobile.Framework.Ui
{
	public class IsPositiveConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is string stringValue && string.IsNullOrWhiteSpace(stringValue))
			{
				return false;
			}

			return double.Parse(value.ToString()) > 0.0;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => value;
	}
}

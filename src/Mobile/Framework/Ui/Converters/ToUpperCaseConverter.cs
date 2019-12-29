using System;
using System.Globalization;
using Xamarin.Forms;

namespace Mobile.Framework.Ui
{
	public class ToUpperCaseConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
			value?.ToString().ToUpper(culture);

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => string.Empty;
	}
}

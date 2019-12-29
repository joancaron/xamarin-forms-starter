using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Framework.Ui
{
	public class BoolToValueConverter<T> : IValueConverter, IMarkupExtension
	{
		public T FalseValue { get; set; }
		public T TrueValue { get; set; }

		public object ProvideValue(IServiceProvider serviceProvider)
		{
			return this;
		}

		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return value == null ? FalseValue : (bool)value ? TrueValue : FalseValue;
		}

		public object ConvertBack(object value, Type targetType, object parameter,
			System.Globalization.CultureInfo culture)
		{
			return value?.Equals(TrueValue) ?? false;
		}
	}
}

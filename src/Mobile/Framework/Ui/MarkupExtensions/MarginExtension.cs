using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Framework.Ui
{
	public class ThicknessExtension : IMarkupExtension
	{
		const double DefaultValue = -1;
		public double Top { get; set; } = DefaultValue;
		public double Right { get; set; } = DefaultValue;
		public double Left { get; set; } = DefaultValue;
		public double Bottom { get; set; } = DefaultValue;
		public double Horizontal { get; set; } = DefaultValue;
		public double Vertical { get; set; } = DefaultValue;
		public double Uniform { get; set; } = DefaultValue;

		public object ProvideValue(IServiceProvider serviceProvider)
		{
			if (Uniform != DefaultValue)
			{
				return new Thickness(Uniform);
			}

			if (Horizontal != DefaultValue)
			{
				Left = Horizontal;
				Right = Horizontal;
			}

			if (Vertical != DefaultValue)
			{
				Top = Vertical;
				Bottom = Vertical;
			}

			Top = GetValueOrDefaultThicknessValue(Top);
			Right = GetValueOrDefaultThicknessValue(Right);
			Left = GetValueOrDefaultThicknessValue(Left);
			Bottom = GetValueOrDefaultThicknessValue(Bottom);

			return new Thickness(Left, Top, Right, Bottom);
		}

		double GetValueOrDefaultThicknessValue(double value)
		{
			return value == DefaultValue ? 0 : value;
		}
	}
}

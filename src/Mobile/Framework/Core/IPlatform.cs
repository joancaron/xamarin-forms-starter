using System.Globalization;
using Mobile.Framework.Ui;
using Xamarin.Forms;

namespace Mobile.Framework.Core
{
	public interface IPlatform
	{
		void Vibrate(VibrationType vibrationType);
		CultureInfo GetCurrentCultureInfo();
		Themes GetOperatingSystemTheme();
		void SetStatusBarColor(Color background, bool hasDarkTint);
	}
}

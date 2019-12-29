using System.Globalization;
using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Mobile.Framework.Core;
using Mobile.Framework.Ui;
using Plugin.CurrentActivity;
using Xamarin.Forms.Platform.Android;

namespace Mobile.Droid.Services
{
	public class Platform : IPlatform
	{
		public void Vibrate(VibrationType vibrationType)
		{
			var vibrator = CrossCurrentActivity.Current.Activity.GetSystemService(Context.VibratorService) as Vibrator;
			if (vibrator?.HasVibrator == true)
			{
				switch (vibrationType)
				{
					case VibrationType.Success:
						vibrator.Vibrate(VibrationEffect.CreateOneShot(50, VibrationEffect.DefaultAmplitude));
						break;
					case VibrationType.Error:
						vibrator.Vibrate(VibrationEffect.CreateOneShot(500, VibrationEffect.DefaultAmplitude));
						break;
					case VibrationType.Warning:
						vibrator.Vibrate(VibrationEffect.CreateOneShot(250, VibrationEffect.DefaultAmplitude));
						break;
					case VibrationType.Heavy:
						vibrator.Vibrate(VibrationEffect.CreateOneShot(100, VibrationEffect.DefaultAmplitude));
						break;
					case VibrationType.Medium:
						vibrator.Vibrate(VibrationEffect.CreateOneShot(40, VibrationEffect.DefaultAmplitude));
						break;
					case VibrationType.Selection:
					case VibrationType.Light:
						vibrator.Vibrate(VibrationEffect.CreateOneShot(10, VibrationEffect.DefaultAmplitude));
						break;
				}
			}
		}

		public CultureInfo GetCurrentCultureInfo()
		{
			// For instance only english is supported
			return new CultureInfo("en");
		}

		public Themes GetOperatingSystemTheme()
		{
			if (Build.VERSION.SdkInt >= BuildVersionCodes.Froyo)
			{
				return (Application.Context.Resources.Configuration.UiMode & UiMode.NightMask) switch
				{
					UiMode.NightYes => Themes.Dark,
					UiMode.NightNo => Themes.Light,
					_ => Themes.Light
				};
			}

			return Themes.Light;
		}

		public void SetStatusBarColor(Xamarin.Forms.Color background, bool darkStatusBarTint)
		{
			if (Build.VERSION.SdkInt < BuildVersionCodes.Lollipop)
			{
				return;
			}

			var activity = CrossCurrentActivity.Current.Activity;
			var window = activity.Window;
			window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
			window.ClearFlags(WindowManagerFlags.TranslucentStatus);
			window.SetStatusBarColor(background.ToAndroid());
			window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
			if (Build.VERSION.SdkInt < BuildVersionCodes.M)
			{
				return;
			}

			const StatusBarVisibility flag = (StatusBarVisibility)SystemUiFlags.LightStatusBar;
			window.DecorView.SystemUiVisibility = darkStatusBarTint ? flag : 0;
		}
	}
}
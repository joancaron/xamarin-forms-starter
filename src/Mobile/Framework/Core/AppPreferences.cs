using System;
using Mobile.Framework.Ui;
using Xamarin.Essentials;

namespace Mobile.Framework.Core
{
	public class AppPreferences
	{
		Themes _theme;

		public static Themes Theme
		{
			get => (Themes)Preferences.Get(nameof(Theme), (int)Themes.Auto);
			set => Preferences.Set(nameof(Theme), (int)value);
		}
	}
}

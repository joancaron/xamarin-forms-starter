using System;
using System.Linq;
using AsyncAwaitBestPractices;
using Mobile.Framework.Core;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Mobile.Framework.Ui
{
	public static class ThemeManager
	{
		static readonly IPlatform Platform;
		static readonly WeakEventManager<Themes> ThemeChangedEventManager = new WeakEventManager<Themes>();

		static ThemeManager()
		{
			Platform = DependencyInjectionHelper.Instance.GetService<IPlatform>();
		}

		public static event EventHandler<Themes> ThemeChanging
		{
			add => ThemeChangedEventManager.AddEventHandler(value);
			remove => ThemeChangedEventManager.RemoveEventHandler(value);
		}

		public static event EventHandler<Themes> ThemeChanged
		{
			add => ThemeChangedEventManager.AddEventHandler(value);
			remove => ThemeChangedEventManager.RemoveEventHandler(value);
		}

		public static bool SupportsAutomaticTheme
		{
			get;
		} = DeviceInfo.Version >= (DeviceInfo.Platform == DevicePlatform.Android
			    ? new Version(10, 0)
			    : new Version(13, 0));

		public static void InitializeTheme()
		{
			var currentTheme = AppPreferences.Theme;

			if (currentTheme == Themes.Auto)
			{
				if (SupportsAutomaticTheme)
				{
					currentTheme = Platform.GetOperatingSystemTheme();
				}
				else
				{
					currentTheme = AppPreferences.Theme = Themes.Light;
				}
			}

			SetTheme(currentTheme);
		}

		public static void SetTheme(Themes theme)
		{
			ThemeChangedEventManager.HandleEvent(null, AppPreferences.Theme, nameof(ThemeChanging));

			var resources = Application.Current.Resources;
			var mergedDictionaries = resources.MergedDictionaries;

			switch (theme)
			{
				case Themes.Dark:
					var lightTheme = mergedDictionaries.OfType<LightTheme>().FirstOrDefault();

					if (lightTheme != null)
					{
						mergedDictionaries.Remove(lightTheme);
					}

					mergedDictionaries.Add(new DarkTheme());
					break;

				default:
					var darkTheme = mergedDictionaries.OfType<DarkTheme>().FirstOrDefault();

					if (darkTheme != null)
					{
						mergedDictionaries.Remove(darkTheme);
					}

					mergedDictionaries.Add(new LightTheme());

					break;
			}

			var background = (Color)resources["SurfaceColor"];
			Platform.SetStatusBarColor(background, theme != Themes.Dark);

			ThemeChangedEventManager.HandleEvent(null, theme, nameof(ThemeChanged));
		}
	}
}

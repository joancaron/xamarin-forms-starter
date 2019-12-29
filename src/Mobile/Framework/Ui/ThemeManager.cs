using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AsyncAwaitBestPractices;
using Mobile.Framework.Core;
using Xamarin.Forms;

namespace Mobile.Framework.Ui
{
	public class ThemeManager
	{
		readonly WeakEventManager<Themes> _themeChangedEventManager = new WeakEventManager<Themes>();
		public event EventHandler<Themes> ThemeChanged
		{
			add => _themeChangedEventManager.AddEventHandler(value);
			remove => _themeChangedEventManager.RemoveEventHandler(value);
		}

		static readonly IPlatform Platform;

		static ThemeManager()
		{
			Platform = DependencyInjectionHelper.Instance.GetService<IPlatform>();
		}

		public static void SetTheme(Themes theme = Themes.UnSpecified)
		{
			if (theme == Themes.UnSpecified)
			{
				theme = Platform.GetOperatingSystemTheme();
			}

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
		}
	}
}

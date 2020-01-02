using System;
using System.Collections.Generic;
using System.Linq;
using FFImageLoading.Forms.Platform;
using FFImageLoading.Svg.Forms;
using Foundation;
using Mobile.Framework.Core;
using Mobile.Framework.Ui;
using Mobile.iOS.Services;
using Rg.Plugins.Popup;
using UIKit;

namespace Mobile.iOS
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to
	// application events from iOS.
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		//
		// This method is invoked when the application has loaded and is ready to run. In this
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();

			CachedImageRenderer.Init();
			var ignore = typeof(SvgCachedImage);

			Popup.Init();

			LoadApplication(Startup.Init(PlatformServicesRegistrar.ConfigureServices));

			if (UIDevice.CurrentDevice.CheckSystemVersion(13, 0))
			{
				ThemeManager.ThemeChanging += OnThemeChanging;
			}

			return base.FinishedLaunching(app, options);
		}

		void OnThemeChanging(object sender, Themes theme)
		{
			var style = UIUserInterfaceStyle.Unspecified;

			if (theme == Themes.Light)
			{
				style = UIUserInterfaceStyle.Light;
			}
			else if (theme == Themes.Dark)
			{
				style = UIUserInterfaceStyle.Dark;
			}

			Window.OverrideUserInterfaceStyle = style;
		}
	}
}

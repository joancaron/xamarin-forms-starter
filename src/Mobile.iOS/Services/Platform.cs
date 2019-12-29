using System.Globalization;
using System.Linq;
using Mobile.Framework.Core;
using Mobile.Framework.Ui;
using UIKit;
using Xamarin.Forms;

namespace Mobile.iOS.Services
{
	public class Platform : IPlatform
	{
		public void Vibrate(VibrationType vibrationType)
		{
			if (UIDevice.CurrentDevice.CheckSystemVersion(10, 0))
			{
				switch (vibrationType)
				{
					case VibrationType.Success:
						Notification(UINotificationFeedbackType.Success);
						break;
					case VibrationType.Error:
						Notification(UINotificationFeedbackType.Error);
						break;
					case VibrationType.Warning:
						Notification(UINotificationFeedbackType.Warning);
						break;
					case VibrationType.Selection:
						using (var selection = new UISelectionFeedbackGenerator())
						{
							selection.Prepare();
							selection.SelectionChanged();
						}

						break;
					case VibrationType.Heavy:
						Impact(UIImpactFeedbackStyle.Heavy);
						break;
					case VibrationType.Medium:
						Impact(UIImpactFeedbackStyle.Medium);
						break;

					case VibrationType.Light:
					default:
						Impact(UIImpactFeedbackStyle.Light);
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
			if (!UIDevice.CurrentDevice.CheckSystemVersion(13, 0))
			{
				return Themes.Light;
			}

			var viewController = GetVisibleViewController();
			if (viewController != null)
			{
				return viewController.TraitCollection.UserInterfaceStyle switch
				{
					UIUserInterfaceStyle.Light => Themes.Light,
					UIUserInterfaceStyle.Dark => Themes.Dark,
					_ => Themes.Light
				};
			}

			return Themes.Light;
		}

		public void SetStatusBarColor(Color background, bool hasDarkTint)
		{
		}

		static UIViewController GetVisibleViewController()
		{
			UIViewController viewController = null;

			var window = UIApplication.SharedApplication.KeyWindow;

			if (window.WindowLevel == UIWindowLevel.Normal)
			{
				viewController = window.RootViewController;
			}

			if (viewController == null)
			{
				window = UIApplication.SharedApplication
					.Windows
					.OrderByDescending(w => w.WindowLevel)
					.FirstOrDefault(w => w.RootViewController != null && w.WindowLevel == UIWindowLevel.Normal);

				if (window == null)
				{
					return null;
				}

				viewController = window.RootViewController;
			}

			while (viewController.PresentedViewController != null)
			{
				viewController = viewController.PresentedViewController;
			}

			return viewController;
		}

		void Impact(UIImpactFeedbackStyle feedbackStyle)
		{
			using var impact = new UIImpactFeedbackGenerator(feedbackStyle);
			impact.Prepare();
			impact.ImpactOccurred();
		}

		void Notification(UINotificationFeedbackType feedbackType)
		{
			using var notification = new UINotificationFeedbackGenerator();
			notification.Prepare();
			notification.NotificationOccurred(feedbackType);
		}
	}
}

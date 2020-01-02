using CoreGraphics;
using Mobile.Framework.Ui;
using Mobile.iOS.Helpers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace Mobile.iOS.Renderers.Shell
{
	public class AppTabbarAppearance : ShellTabBarAppearanceTracker
	{
		public override void SetAppearance(UITabBarController controller, ShellAppearance appearance)
		{
			base.SetAppearance(controller, appearance);

			var myTabBar = controller.TabBar;
			var tabs = TabIconsHelper.GetTabs();

			if (myTabBar.Items?.Length == tabs.Count)
			{
				IShellAppearanceElement appearanceElement = appearance;
				var unselectedColor = appearanceElement.EffectiveTabBarUnselectedColor.ToUIColor();
				var selectedColor = appearanceElement.EffectiveTabBarForegroundColor.ToUIColor();
				var iconsize = new CGSize(TabIconsHelper.Size, TabIconsHelper.Size);

				for (int i = 0; i < tabs.Count; i++)
				{
					var tab = myTabBar.Items[i];

					tab.Image =
						ImageHelper.ImageFromFont(
							tabs[i].IconGlyph,
							unselectedColor,
							iconsize);

					tab.SelectedImage =
						ImageHelper.ImageFromFont(
							tabs[i].IconSelectedGlyph,
							selectedColor,
							iconsize);
				}
			}
		}
	}
}

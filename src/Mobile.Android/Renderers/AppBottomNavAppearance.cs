using Android.Content;
using Android.Support.Design.BottomNavigation;
using Android.Support.Design.Widget;
using Mobile.Droid.Helpers;
using Mobile.Framework.Ui;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace Mobile.Droid.Renderers
{
	public class AppBottomNavAppearance : ShellBottomNavViewAppearanceTracker
	{
		readonly Context _context;

		public AppBottomNavAppearance(IShellContext shellContext, ShellItem shellItem, Context context)
			: base(shellContext, shellItem)
		{
			_context = context;
		}

		public AppBottomNavAppearance(IShellContext shellContext, ShellItem shellItem)
			: base(shellContext, shellItem)
		{
		}

		public override void SetAppearance(BottomNavigationView bottomView, ShellAppearance appearance)
		{
			base.SetAppearance(bottomView, appearance);
			IShellAppearanceElement appearanceElement = appearance;
			var unselectedColor = appearanceElement.EffectiveTabBarUnselectedColor.ToAndroid();
			var selectedColor = appearanceElement.EffectiveTabBarForegroundColor.ToAndroid();

			bottomView.LabelVisibilityMode = LabelVisibilityMode.LabelVisibilityUnlabeled;

			var myMenu = bottomView.Menu;
			var tabs = TabIconsHelper.GetTabs();

			for (var i = 0; i < tabs.Count; i++)
			{
				var menu = myMenu.GetItem(i);
				var tab = tabs[i];
				menu.SetIcon(
					menu.IsChecked
						? new FontDrawable(_context, tab.IconSelectedGlyph, selectedColor, TabIconsHelper.Size)
						: new FontDrawable(_context, tab.IconGlyph, unselectedColor, TabIconsHelper.Size));
			}
		}
	}
}

using UIKit;
using Xamarin.Forms.Platform.iOS;

namespace Mobile.iOS.Renderers.Shell
{
	public class AppShellSectionRenderer : ShellSectionRenderer
	{
		public AppShellSectionRenderer(IShellContext context)
			: base(context)
		{
		}

		protected override void UpdateTabBarItem()
		{
			base.UpdateTabBarItem();
			TabBarItem.Title = string.Empty;
			TabBarItem.ImageInsets = new UIEdgeInsets(-6, 0, -6, 0);
		}
	}
}

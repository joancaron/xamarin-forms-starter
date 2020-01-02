using Mobile;
using Mobile.iOS.Renderers.Shell;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(AppShell), typeof(AppShellRenderer))]
namespace Mobile.iOS.Renderers.Shell
{
	public class AppShellRenderer : ShellRenderer
	{
		protected override IShellSectionRenderer CreateShellSectionRenderer(ShellSection shellSection)
		{
			return new AppShellSectionRenderer(this);
		}

		protected override IShellTabBarAppearanceTracker CreateTabBarAppearanceTracker()
		{
			return new AppTabbarAppearance();
		}
	}
}

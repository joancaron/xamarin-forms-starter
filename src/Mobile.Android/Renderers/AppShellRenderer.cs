using Android.Content;
using Mobile;
using Mobile.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(AppShell), typeof(AppShellRenderer))]

namespace Mobile.Droid.Renderers
{
	public class AppShellRenderer : ShellRenderer
	{
		public AppShellRenderer(Context context)
			: base(context)
		{
		}

		protected override IShellBottomNavViewAppearanceTracker CreateBottomNavViewAppearanceTracker(
			ShellItem shellItem)
		{
			return new AppBottomNavAppearance(this, shellItem, AndroidContext);
		}
	}
}

using Mobile.Framework.Ui;
using Mobile.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ContentPage), typeof(AppPageRenderer))]

namespace Mobile.iOS.Renderers
{
	public class AppPageRenderer : PageRenderer
	{
		public override void TraitCollectionDidChange(UITraitCollection previousTraitCollection)
		{
			base.TraitCollectionDidChange(previousTraitCollection);


			if (TraitCollection.UserInterfaceStyle != previousTraitCollection.UserInterfaceStyle)
			{
				ThemeManager.SetTheme(TraitCollection.UserInterfaceStyle == UIUserInterfaceStyle.Dark
					? Themes.Dark
					: Themes.Light);
			}
		}
	}
}

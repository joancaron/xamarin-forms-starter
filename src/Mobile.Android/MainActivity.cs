using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using FFImageLoading.Forms.Platform;
using Mobile.Framework.Ui;
using Plugin.CurrentActivity;
using Rg.Plugins.Popup;

namespace Mobile.Droid
{
	[Activity(
		Label = "Mobile",
		Icon = "@mipmap/ic_launcher",
		Theme = "@style/LaunchTheme",
		LaunchMode = LaunchMode.SingleTop,
		MainLauncher = true,
		ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.SetTheme(Resource.Style.MainTheme);

			base.OnCreate(savedInstanceState);

			Xamarin.Essentials.Platform.Init(this, savedInstanceState);
			Xamarin.Forms.Forms.Init(this, savedInstanceState);

			CachedImageRenderer.Init(true);

			CrossCurrentActivity.Current.Init(this, savedInstanceState);

			Popup.Init(this, savedInstanceState);

			LoadApplication(Startup.Init(PlatformServicesRegistrar.ConfigureServices));

			ThemeManager.ThemeChanging += OnThemeChanging;
		}

		void OnThemeChanging(object sender, Themes theme)
		{
			var nightMode = AppCompatDelegate.ModeNightFollowSystem;
			if (theme == Themes.Light)
			{
				nightMode = AppCompatDelegate.ModeNightNo;
			}
			else if(theme == Themes.Dark)
			{
				nightMode = AppCompatDelegate.ModeNightYes;
			}

			Delegate.SetLocalNightMode(nightMode);
		}

		public override void OnRequestPermissionsResult(int requestCode, string[] permissions,
			[GeneratedEnum] Permission[] grantResults)
		{
			Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

			base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
		}

		public override void OnBackPressed()
		{
			base.OnBackPressed();
			Popup.SendBackPressed(base.OnBackPressed);
		}
	}
}

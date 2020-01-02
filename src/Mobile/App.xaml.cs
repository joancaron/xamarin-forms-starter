using FFImageLoading;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Distribute;
using Mobile.Framework.Core.Settings;
using Mobile.Framework.Ui;
using Syncfusion.Licensing;
using Xamarin.Forms;
using Device = Xamarin.Forms.Device;

namespace Mobile
{
	[Preserve(AllMembers = true)]
	public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Device.SetFlags(new[] {
                "CarouselView_Experimental",
                "IndicatorView_Experimental",
                "SwipeView_Experimental"
            });

			MainPage = new AppShell();
		}

		public static AppConfiguration Configuration { get; set; }

        protected override void OnStart()
        {
			base.OnStart();

            ThemeManager.InitializeTheme();

            Configuration.IsInBackground = false;

            if (Configuration.Stage != Stage.Local)
            {
				AppCenter.Start(
					$"android={Configuration.AppCenter.AndroidToken};" +
					$"ios={Configuration.AppCenter.iOSToken}",
					typeof(Analytics), typeof(Crashes), typeof(Distribute));
			}

            SyncfusionLicenseProvider.RegisterLicense(Configuration.Syncfusion.LicenseKey);

            ImageService.Instance.Initialize(
	            new FFImageLoading.Config.Configuration { HttpHeadersTimeout = 60 });
		}

        protected override void OnSleep()
        {
			base.OnSleep();
            Configuration.IsInBackground = true;
            ImageService.Instance.SetExitTasksEarly(true);
		}

        protected override void OnResume()
        {
			base.OnResume();
            Configuration.IsInBackground = false;
            ImageService.Instance.SetExitTasksEarly(false);
		}
    }
}

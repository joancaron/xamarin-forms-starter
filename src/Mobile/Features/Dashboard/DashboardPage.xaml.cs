using System;
using Mobile.Framework.Core;
using Mobile.Framework.Ui;

namespace Mobile.Features.Dashboard
{
	[Preserve(AllMembers = true)]
	public partial class DashboardPage
    {
        public DashboardPage()
        {
            InitializeComponent();
        }

        void Button_OnClicked(object sender, EventArgs e)
        {
	        AppPreferences.Theme = Themes.Auto;
	        ThemeManager.InitializeTheme();
        }

        void Light_OnClicked(object sender, EventArgs e)
        {
	        AppPreferences.Theme = Themes.Light;
	        ThemeManager.InitializeTheme();
        }

        void Dark_OnClicked(object sender, EventArgs e)
        {
	        AppPreferences.Theme = Themes.Dark;
	        ThemeManager.InitializeTheme();
        }
    }
}
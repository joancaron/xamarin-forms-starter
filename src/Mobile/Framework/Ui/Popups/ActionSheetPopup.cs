using Rg.Plugins.Popup.Animations;
using Rg.Plugins.Popup.Enums;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using Xamarin.Forms.PancakeView;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Application = Xamarin.Forms.Application;

namespace Mobile.Framework.Ui
{
	public class ActionSheetPopup : PopupPage
	{
		public static readonly BindableProperty RootViewProperty =
			BindableProperty.Create(
				nameof(RootView),
				typeof(View),
				typeof(ActionSheetPopup),
				default(View),
				propertyChanged: RootViewOnPropertyChanged);

		readonly PancakeView _container;

		public ActionSheetPopup()
		{
			var resources = Application.Current.Resources;

			BackgroundColor = Color.FromRgba(0, 0, 0, 0.80);
			HasSystemPadding = false;
			HasKeyboardOffset = true;
			CloseWhenBackgroundIsClicked = true;
			Animation = new MoveAnimation(MoveAnimationOptions.Bottom, MoveAnimationOptions.Bottom);

			_container = new PancakeView();
			var radius = (double)resources[SizeKeys.RadiusLarge];
			_container.CornerRadius = new CornerRadius(radius, radius, 0, 0);

			_container.BackgroundColor = (Color)resources[ThemeKeys.SurfaceColor];
			_container.HasShadow = false;
			_container.VerticalOptions = LayoutOptions.EndAndExpand;
			_container.HorizontalOptions = LayoutOptions.FillAndExpand;
			_container.Content = RootView;

			Content = _container;
		}

		public View RootView
		{
			get => (View)GetValue(RootViewProperty);
			set => SetValue(RootViewProperty, value);
		}

		static void RootViewOnPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
		{
			if (bindable is ActionSheetPopup actionSheet && newvalue is View view)
			{
				actionSheet._container.Content = view;
			}
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			var thickness = new Thickness((double)Application.Current.Resources[SizeKeys.NormalSize]);
			if (Device.RuntimePlatform == Device.iOS)
			{
				thickness.Bottom = On<iOS>().SafeAreaInsets().Bottom;
			}

			_container.Padding = thickness;
		}
	}
}

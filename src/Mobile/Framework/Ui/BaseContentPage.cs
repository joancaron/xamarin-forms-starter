using Mobile.Framework.Core;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace Mobile.Framework.Ui
{
	public abstract class BaseContentPage<TViewModel> : ContentPage
		where TViewModel : BaseViewModel
	{
		protected bool IsAlreadyInitialized;

		protected bool IsAlreadyUninitialized;

		protected BaseContentPage()
		{
			BindingContext = ViewModel = DependencyInjectionHelper.Instance.GetService<TViewModel>();
		}

		protected TViewModel ViewModel { get; }

		protected override void OnAppearing()
		{
			base.OnAppearing();

			On<iOS>().SetUseSafeArea(true);


			if (!IsAlreadyInitialized)
			{
				ViewModel.InitializeAsync();
				IsAlreadyInitialized = true;
			}
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();

			if (!IsAlreadyUninitialized)
			{
				ViewModel.UninitializeAsync();
				IsAlreadyUninitialized = true;
			}
		}
	}
}

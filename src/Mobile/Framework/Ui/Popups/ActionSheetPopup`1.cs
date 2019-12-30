namespace Mobile.Framework.Ui
{
	public class ActionSheetPopup<TViewModel> : ActionSheetPopup where TViewModel : BasePopupViewModel

	{
		public ActionSheetPopup(TViewModel vm)
		{
			BindingContext = ViewModel = vm;
		}

		public TViewModel ViewModel { get; set; }

		public bool IsAlreadyInitialized { get; set; }

		protected override void OnAppearing()
		{
			base.OnAppearing();

			if (!IsAlreadyInitialized)
			{
				ViewModel.Navigation = Rg.Plugins.Popup.Services.PopupNavigation.Instance;
				ViewModel.InitializeAsync();
				IsAlreadyInitialized = true;
			}
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			ViewModel.UninitializeAsync();
		}
	}
}

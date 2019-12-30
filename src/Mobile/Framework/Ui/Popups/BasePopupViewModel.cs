using System;
using System.Threading.Tasks;
using System.Windows.Input;
using AsyncAwaitBestPractices;
using MvvmHelpers;
using MvvmHelpers.Commands;
using Rg.Plugins.Popup.Contracts;

namespace Mobile.Framework.Ui
{
	public class BasePopupViewModel : ObservableObject
	{
		readonly WeakEventManager<BasePopupViewModel> _popupSubmittedEventManager =
			new WeakEventManager<BasePopupViewModel>();

		public virtual ICommand ClosePopupCommand => new AsyncCommand(() => Navigation.PopAsync());

		public IPopupNavigation Navigation { get; set; }

		public event EventHandler<BasePopupViewModel> PopupSubmitted
		{
			add => _popupSubmittedEventManager.AddEventHandler(value);
			remove => _popupSubmittedEventManager.RemoveEventHandler(value);
		}

		public void OnPopupSubmitted(BasePopupViewModel vm) =>
			_popupSubmittedEventManager.HandleEvent(this, vm, nameof(PopupSubmitted));

		public virtual Task InitializeAsync()
		{
			return Task.CompletedTask;
		}

		public virtual Task UninitializeAsync()
		{
			return Task.CompletedTask;
		}
	}
}

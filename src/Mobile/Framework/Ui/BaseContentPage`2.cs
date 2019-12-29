namespace Mobile.Framework.Ui
{
	public class BaseContentPage<TViewModel, TPageModel> : BaseContentPage<TViewModel>
		where TViewModel : BaseViewModel<TPageModel>
		where TPageModel : IPageModel

	{
		readonly TPageModel _pageModel;

		protected BaseContentPage(TPageModel model)
		{
			_pageModel = model;
		}

		/// <inheritdoc/>
		protected override void OnAppearing()
		{
			if (!IsAlreadyInitialized)
			{
				ViewModel.InitializeAsync(_pageModel);
				IsAlreadyInitialized = true;
			}

			base.OnAppearing();
		}
	}

	public interface IPageModel
	{
	}
}

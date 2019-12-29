using System.Threading.Tasks;

namespace Mobile.Framework.Ui
{
	public abstract class BaseViewModel<TPageModel> : BaseViewModel
	{
		public abstract Task InitializeAsync(TPageModel pageModel);
	}
}

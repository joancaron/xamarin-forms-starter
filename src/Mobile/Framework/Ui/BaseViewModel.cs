using System.Threading.Tasks;
using MvvmHelpers;

namespace Mobile.Framework.Ui
{
	public abstract class BaseViewModel : ObservableObject
	{
		public virtual Task InitializeAsync() => Task.CompletedTask;

		public virtual Task UninitializeAsync() => Task.CompletedTask;
	}
}

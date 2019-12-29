using System;
using EnsureThat;
using JetBrains.Annotations;

namespace Mobile.Framework.Core
{
	public class DependencyInjectionHelper
	{
		static readonly Lazy<DependencyInjectionHelper>
			Lazy =
				new Lazy<DependencyInjectionHelper>
					(() => new DependencyInjectionHelper());

		public static DependencyInjectionHelper Instance => Lazy.Value;

		IServiceProvider serviceProvider { get; set; }

		public void AddServiceProvider([NotNull] IServiceProvider appServiceProvider)
		{
			EnsureArg.IsNotNull(appServiceProvider);
			serviceProvider = appServiceProvider;
		}

		public TService GetService<TService>() => (TService)serviceProvider.GetService(typeof(TService));
	}
}

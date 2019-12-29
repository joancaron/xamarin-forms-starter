using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Mobile.Droid.Services;
using Mobile.Framework.Core;

namespace Mobile.Droid
{
	public static class PlatformServicesRegistrar
	{
		public static void ConfigureServices(HostBuilderContext ctx, IServiceCollection services)
		{
			services.AddSingleton<IPlatform, Platform>();
		}
	}
}

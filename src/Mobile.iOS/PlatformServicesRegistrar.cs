using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Mobile.Framework.Core;
using Mobile.iOS.Services;

namespace Mobile.iOS
{
	public static class PlatformServicesRegistrar
	{
		public static void ConfigureServices(HostBuilderContext ctx, IServiceCollection services)
		{
			services.AddSingleton<IPlatform, Platform>();
		}
	}
}

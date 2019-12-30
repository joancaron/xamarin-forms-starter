using System;
using System.Linq;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Mobile.Framework.Core;
using Mobile.Framework.Core.Helpers;
using Mobile.Framework.Core.Logging;
using Mobile.Framework.Core.Settings;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Xamarin.Essentials;

namespace Mobile
{
	public class Startup
	{
		public static App Init(Action<HostBuilderContext, IServiceCollection> platformConfigureServices)
		{
			JsonConvert.DefaultSettings = () => new JsonSerializerSettings()
			{
				ContractResolver = new CamelCasePropertyNamesContractResolver(),
				Converters = {new StringEnumConverter()}
			};

			var systemDir = FileSystem.CacheDirectory;
			var appConfig = FileHelper.ExtractAndSaveResourceFile("Mobile.appsettings.json", systemDir);
			var secretsConfig = FileHelper.ExtractAndSaveResourceFile("Mobile.secrets.json", systemDir);

			var host = new HostBuilder().ConfigureHostConfiguration(
				c =>
				{
					c.AddCommandLine(new[] {$"ContentRoot={FileSystem.AppDataDirectory}"});
					c.AddJsonFile(appConfig);
					c.AddJsonFile(secretsConfig);
				}).ConfigureServices(
				(c, x) =>
				{
					var appConfiguration = new AppConfiguration();

					c.Configuration.Bind(appConfiguration);

					App.Configuration = appConfiguration;

					platformConfigureServices(c, x);

					ConfigureServices(c, x);
				}).ConfigureLogging(l => l.AddConsole()).Build();

			DependencyInjectionHelper.Instance.AddServiceProvider(host.Services);
			return DependencyInjectionHelper.Instance.GetService<App>();
		}

		static void ConfigureServices(HostBuilderContext ctx, IServiceCollection services)
		{
			services.AddMediatR(typeof(Startup));
			services.AddAutoMapper(typeof(Startup));
			services.AddSingleton<App>();

			if (App.Configuration.Stage != Stage.Local)
			{
				services.AddSingleton<IErrorLogger, AppCenterErrorLogger>();
				services.AddSingleton<IAnalyticsLogger, AppCenterAnalyticsLogger>();
			}
			else
			{
				services.AddSingleton<IErrorLogger, DebugErrorLogger>();
				services.AddSingleton<IAnalyticsLogger, DebugAnalyticsLogger>();
			}

			// All viewmodels following the convention will be automatically registered (class name ends with ViewModel)
			var viewModelTypes =
				typeof(App).Assembly.ExportedTypes.Where(x => x.Name.EndsWith("ViewModel") && !x.IsAbstract);

			foreach (var viewModelType in viewModelTypes)
			{
				services.AddTransient(viewModelType);
			}
		}
	}
}

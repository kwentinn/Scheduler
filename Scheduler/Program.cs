using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;

namespace Scheduler
{
	public class Program
	{
		public static void Main(string[] args)
		{
			// appsettings.json
			var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
			var jsonSettingsFile = $"appsettings.{env}.json";

			// création de l'objet Configuration
			var configuration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile(jsonSettingsFile)
				.Build();

			CreateWebHostBuilder(args).Build().Run();
		}

		public static IWebHostBuilder CreateWebHostBuilder(string[] args)
		{
			return WebHost.CreateDefaultBuilder(args)
				.UseStartup<Startup>();
		}

	}
}

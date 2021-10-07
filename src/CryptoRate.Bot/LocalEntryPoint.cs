﻿using System.Threading.Tasks;
using CryptoRate.Bot.Services;
using CryptoRate.Common.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CryptoRate.Bot {

	public class LocalEntryPoint {

		private static async Task Main() {
			//var host = GetHost();
			var host = GetWebHost();

			await host.RunAsync();
		}

		private static IHost GetHost()
			=> new HostBuilder()
				.AddConfiguration()
				.UseStartup<Core.Startup>()
				.UseStartup<Startup>()
				.ConfigureServices(services => services.AddHostedService<TelegramBotLocalRunner>())
				.Build();

		private static IWebHost GetWebHost()
			=> new WebHostBuilder()
				.UseUrls("https://*:5930")
				.UseKestrel()
				.AddConfiguration()
				.UseStartup<WebStartup>()
				.Build();

	}

}
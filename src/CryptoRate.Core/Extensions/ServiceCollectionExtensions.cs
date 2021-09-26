﻿using System;
using CryptoRate.Core.Abstractions;
using CryptoRate.Core.Configs;
using CryptoRate.Core.Services;
using CryptoRate.Core.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
// ReSharper disable UnusedMethodReturnValue.Global

namespace CryptoRate.Core.Extensions {

	public static class ServiceCollectionExtensions {

		public static IServiceCollection AddCryptoClientAsSingleton(this IServiceCollection services, IConfiguration configuration) {
			services.Configure<CryptoClientOptions>(configuration.GetSection(CryptoClientOptions.SectionName));
			services.AddOptionsValidator<CryptoClientOptions>();
			services.AddSingleton<ICryptoClient, CryptoClient>();
			return services;
		}

		public static IServiceCollection AddOptionsValidator<TOptions>(this IServiceCollection optionsBuilder) where TOptions : class {
			optionsBuilder.AddSingleton<IValidateOptions<TOptions>, OptionsValidator<TOptions>>();
			return optionsBuilder;
		}

	}

}
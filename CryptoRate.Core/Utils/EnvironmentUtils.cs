﻿using System;

namespace CryptoRate.Core.Utils {

	public static class EnvironmentUtils {
		
		public const string EnvironmentName = "EnvironmentName";

		public static string GetEnvironmentName() => Environment.GetEnvironmentVariable(EnvironmentName);

	}

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KdAPI_Demo.Model;
using Microsoft.Extensions.Configuration;

namespace KdAPI_Demo.Extensions
{
	
	public static class ConfigurationExtension
	{
		public static ExpressBirdModel expressConfig =new ExpressBirdModel
		{
			BusinessID = "123456",
			AppKey = "test"
		};

		public static ApiModel apiConfig = new ApiModel
		{
			Logistics_Trajectory_API = "XXXX"
		};
		public static void TranstionSettingExtension(this IConfiguration configuration)
		{
			var builder = new ConfigurationBuilder();
			builder.AddJsonFile("appsettings.json");
			var configurationRoot = builder.Build();
			configurationRoot.GetSection("ExpressBird").Bind(expressConfig);
			configurationRoot.GetSection("ApiUrl").Bind(apiConfig);
		}
	}
}

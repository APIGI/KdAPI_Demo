using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using KdAPI_Demo._1_Interfaces;
using KdAPI_Demo._2_Services;
using KdAPI_Demo.Extensions;
using KdAPI_Demo.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace KdAPI_Demo
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
			configuration.TranstionSettingExtension();
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			#region Service

				services.AddTransient<IOrderService, OrderService>();

			#endregion

			#region Swagger

			services.AddSwaggerGen(m =>
			{
				m.SwaggerDoc("v1", new OpenApiInfo
				{
					Title = "快递鸟通用API组件",
					Version = "v1",
					Contact = new OpenApiContact
					{
						Name = "潇十一郎",
						Email = "1064938480@qq.com",
						Extensions = null,
						Url = new Uri("http://www.fuyue.xyz/"),
					},
					Description = "此接口文档为帮助广大开发者更加便捷的调试和对接快递鸟平台～"
				});
				var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);
				var xmlPath = Path.Combine(basePath, "KdAPI_Demo.xml");
				m.IncludeXmlComments(xmlPath, true);
			});
			#endregion 

			services.AddControllers();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "快递鸟API组件列表");
				c.DocExpansion(DocExpansion.List);
				c.DefaultModelsExpandDepth(-1);
				c.RoutePrefix = string.Empty;
			});

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}

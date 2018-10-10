using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;

namespace BesiGourmet.StartupRegistrar
{
	public static class SwaggerRegistrar
	{
		/// <summary>
		/// Configure swagger generator
		/// </summary>
		/// <param name="services"></param>
		public static void AddSwagger(IServiceCollection services)
		{
			// add some metadata for the doc to generate
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new Info
				{
					Title = "BesiGourmet.WebApi",
					Version = "v1",
					License = new License
					{
						Name = "(c) by Besi"
					}
				});

				var basePath = AppContext.BaseDirectory;
				var xmlPath = Path.Combine(basePath, "BesiGourmet.WebApi.xml");
				c.IncludeXmlComments(xmlPath);
			});
		}

		/// <summary>
		/// Add swagger middleware / endpoint
		/// </summary>
		/// <param name="app"></param>
		public static void UseSwaggerMiddleware(IApplicationBuilder app)
		{
			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json",
				  "BesiGourmet.WebApi API V1");
			});
		}
	}
}

using BesiGourmet.AAD;
using BesiGourmet.Database;
using BesiGourmet.KeyVault;
using BesiGourmet.StartupRegistrar;
using Microsoft.AspNetCore.Authentication.AzureAD.UI;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace BesiGourmet
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			// setup swagger
			SwaggerRegistrar.AddSwagger(services);

			services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(Configuration["ConnectionString"]));

			////var kvClient = new KVClient(Configuration["KeyVault:VaultUri"]);
			////var connectionString = kvClient.GetValueAsync("ConnectionString").Result;

			services.AddAuthorization(o =>
			{
				o.AddPolicy("default", policy =>
				{
					// Require the basic "Access app-name" claim by default
					policy.RequireClaim(Constants.ScopeClaimType, "user_impersonation");
				});
			});

			services
				.AddAuthentication(o =>
				{
					o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
				})
				.AddJwtBearer(o =>
				{
					o.Authority = $"{Configuration["AzureAd:Instance"]}{Configuration["AzureAd:TenantId"]}";
					o.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
					{
						// Both App ID URI and client id are valid audiences in the access token
						ValidAudiences = new List<string>
						{
							Configuration["AzureAd:AppIdUri"]
						}
					};
				});

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
			services.AddApplicationInsightsTelemetry();

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			// setup swagger middleware
			SwaggerRegistrar.UseSwaggerMiddleware(app);
			////app.UseHttpsRedirection();
			app.UseAuthentication();
			app.UseMvc();
		}
	}
}

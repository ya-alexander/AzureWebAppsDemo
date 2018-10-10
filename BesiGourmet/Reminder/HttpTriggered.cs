
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;

namespace Reminder
{
	public static class HttpTriggered
	{
		private static readonly HttpClient _httpClient;
		private static readonly IConfigurationRoot _config;

		static HttpTriggered()
		{
			_httpClient = new HttpClient();

			_config = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
				.AddEnvironmentVariables()
				.Build();
		}

		[FunctionName("HttpTriggered")]
		public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequest req, ILogger log)
		{
			log.LogInformation("C# HTTP trigger function processed a request.");

			try
			{
				string date = req.Query["date"];
				string userId = req.Query["userid"];

				_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _config["Token"]);

				var result = await _httpClient.GetAsync($"{_config["BesiGourmetUri"]}/api/default/menuorder/missing/{date}/{userId}");
				var content = await result.Content.ReadAsStringAsync();

				// todo: send mails to users

				return (ActionResult)new OkObjectResult(content);
			}
			catch (Exception e)
			{

				log.LogError(e.Message, e.StackTrace);
				return (ActionResult)new BadRequestObjectResult(e);
			}
		}
	}
}

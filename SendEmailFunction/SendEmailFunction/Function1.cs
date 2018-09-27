using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace SendEmailFunction
{
    public static class SendEmail
    {

        [FunctionName("TestSendEmailNew")]
        public static async System.Threading.Tasks.Task RunAsync([TimerTrigger("0 */1 * * * *")] TimerInfo myTimer, ILogger log)
        {
            var apiKey = System.Environment.GetEnvironmentVariable("AzureWebJobsSendGridApiKey", EnvironmentVariableTarget.Process);
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("<email address>", "Example User");
            var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress("<email address>", "Example User");
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var res = await client.SendEmailAsync(msg);
        }
    }
}

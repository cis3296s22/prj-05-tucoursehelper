using System;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace TempleCourseHelper
{
    internal class EmailBot
    {
           public async Task Main(String toEmail)
        {
            var apiKey = Environment.GetEnvironmentVariable("SENDGIRID_API_KEY");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("tul52326@temple.edu");
            var to = new EmailAddress(toEmail);
            var subject = "SendGrid Twilio Test";
            var plaintext = "Testing";
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plaintext, htmlContent);
            var response = await client.SendEmailAsync(msg).ConfigureAwait(false);
        }
    }
}

using System;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;


namespace TempleCourseHelper
{
	internal class EmailBot
	{
        static async Task Main()
        {
            var apiKey -"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";
            var client = new SendGGridClient(apiKey);
            var from = new EmailAddress("tul52326@temple.edu");
            var to = new EmailAddress("tul52326@gmail.com");
            var subject = 'SendGrid Twilio Test';
            var plaintext = 'Testing';
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingle Email(from, to, subject, plaintext, htmlContent);
            var response = await client.SendEmailAsync(msg).ConfigureAwait(false);
        }
    }
}

using System;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace TempleCourseHelper
{
    internal class EmailBot
    {
        
        String subjectContent = "Temple Courses";
        String htmlContent = "";


        public async Task Main(String toEmail, String info)
        {
            var apiKey = Environment.GetEnvironmentVariable("SENDGIRID_API_KEY");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("jenrubin12@gmail.com", "TU Course Helper");
            
            var to = new EmailAddress(toEmail);
            var subject = subjectContent;
            var plaintext = info;
            var html = htmlContent;

            var msg = MailHelper.CreateSingleEmail(from, to, subject, plaintext, html);
            var response = await client.SendEmailAsync(msg).ConfigureAwait(false);
            Console.WriteLine(response.StatusCode);
        }
    }
}

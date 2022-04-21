using System;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace TempleCourseHelper
{
    public  class EmailBot
    {      
        private string subjectContent = "Temple Courses";
        private string htmlContent = "";

        public async Task Main(string toEmail, string info)
        {

            //var apiKey = Key.getKey();

            var apiKey = "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";

            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("jenrubin12@gmail.com", "TU Course Helper");
            
            var to = new EmailAddress(toEmail);
            var subject = subjectContent;
            var plaintext = info;
            var html = "";

            var msg = MailHelper.CreateSingleEmail(from, to, subject, plaintext, html);
            var response = await client.SendEmailAsync(msg).ConfigureAwait(false);
            Console.WriteLine(response.StatusCode);
        }
    }
}

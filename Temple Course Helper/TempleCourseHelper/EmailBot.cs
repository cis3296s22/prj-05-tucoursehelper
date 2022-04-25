using System;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace TempleCourseHelper
{

    /// <summary>  
    /// Email Bot Class that handles sending the email ot the user. 
    /// </summary>  
    public class EmailBot
    {      
        private string subjectContent = "Temple Courses";
        private string htmlContent = "";

        /// <summary>  
        /// Main class that will send the email to the user when EmailBot is called. 
        /// </summary>  
        /// <param name="toEmail">Parameter to specify the address ww will send the email.</param>  
        /// <param name="info">Parameter to specify the info we are sending to the user.</param>  
        /// <returns>Successfull Task. </returns>  
        public async Task Main(string toEmail, string info)
        {
            var apiKey = Key.getKey();

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

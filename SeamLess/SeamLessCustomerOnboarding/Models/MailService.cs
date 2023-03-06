using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

using System.Net.Mail;

namespace SeamLessCustomerOnboarding.Models
{
    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;
        private readonly IConfiguration configuration;
        private IWebHostEnvironment environment;
        public MailService(IConfiguration config, IWebHostEnvironment webHsotEnvironment)
        {
            environment=webHsotEnvironment;
            configuration = config;
            _mailSettings = configuration.GetSection("MailSettings").Get<MailSettings>();
          
        }
        public   string createEmailBody(string bank, string key, string message)

        {

            string body = string.Empty;
            //using streamreader for reading my htmltemplate   

            using (StreamReader reader = new StreamReader(environment.WebRootPath+"/EmailTemplate.html"))

            {

                body = reader.ReadToEnd();

            }
            body = body.Replace("{BANK}", bank);
            body = body.Replace("{Bank}", bank); //replacing the required things  

            body = body.Replace("{key}", key);

            return body;

        }
        public async Task SendEmailAsync(MailRequest mailRequest,string bank,string key,string name)
        {
            try
            {
                var apiKey = _mailSettings.Host;
                var client = new SendGridClient(apiKey);
                var msg = new SendGridMessage()
                {
                    From = new EmailAddress("ayazshaharyar@gmail.com", "Shaharyar Ayaz"),
                    Subject = "Ethereum Addresss Connection",
                    HtmlContent = createEmailBody(bank, key, "")
                 
                };
                msg.AddTo(new EmailAddress("zersgawadri@gmail.com", "Zers"));
                var response = await client.SendEmailAsync(msg);

                
            }catch(Exception ex)
            {
                throw ex;
            }
         
        }
    }
    
}

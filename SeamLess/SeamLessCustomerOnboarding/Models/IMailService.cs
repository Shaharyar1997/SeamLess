namespace SeamLessCustomerOnboarding.Models
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest,string bank,string key,string name);
    }
}

using System.Threading.Tasks;

namespace CompanyLibrary.Website.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}

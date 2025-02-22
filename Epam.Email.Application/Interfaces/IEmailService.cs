using System.Threading.Tasks;

namespace Epam.Email.Application.Interfaces
{
    public interface IEmailService
    {
        Task<string> SendOtpToCustomerAsync(string customerName, string customerEmail);
    }
}

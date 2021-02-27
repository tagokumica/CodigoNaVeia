using System.Threading.Tasks;

namespace Infra.CrossCutting.Messages.MessageServices.Interface
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
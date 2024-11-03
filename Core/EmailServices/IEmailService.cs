using Microsoft.AspNetCore.Http;

namespace Core.EmailServices
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, string body);
        Task SendMailToMultipleRecipientAsync(List<string> emails, string subject, string body);
        Task SendEmailWithPdfAsync(string email, string subject, string body, IFormFile pdfFile);

    }
}

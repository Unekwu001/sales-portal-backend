using System.Net.Mail;
using System.Net;
using Data.ipNXContext;
using Microsoft.AspNetCore.Http;

namespace Core.EmailServices
{
    public class EmailService : IEmailService
    {

        private readonly IpNxDbContext _ipNXDbContext;

        public EmailService(IpNxDbContext ipNXDbContext)
        {
            _ipNXDbContext = ipNXDbContext;
        }

        public async Task SendEmailAsync(string email, string subject, string body)
        {
            var mailRecord = _ipNXDbContext.EmailSettings.FirstOrDefault();

            using (var client = new SmtpClient(mailRecord.SmtpHost, mailRecord.SmtpPort))
            {
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(mailRecord.SmtpUsername, mailRecord.SmtpPassword);
                client.EnableSsl = true;

                var message = new MailMessage(mailRecord.SmtpUsername, email, subject, body);
                message.IsBodyHtml = true;

                await client.SendMailAsync(message);
            }
        }

        public async Task SendMailToMultipleRecipientAsync(List<string> emails, string subject, string body)
        {
            var mailRecord = _ipNXDbContext.EmailSettings.FirstOrDefault();

            using (var client = new SmtpClient(mailRecord.SmtpHost, mailRecord.SmtpPort))
            {
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(mailRecord.SmtpUsername, mailRecord.SmtpPassword);
                client.EnableSsl = true;

                var message = new MailMessage
                {
                    From = new MailAddress(mailRecord.SmtpUsername),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };

                foreach (var email in emails)
                {
                    message.To.Add(new MailAddress(email));
                }

                await client.SendMailAsync(message);
            }
        }


        public async Task SendEmailWithPdfAsync(string email, string subject, string body, IFormFile pdfFile)
        {
            var mailRecord = _ipNXDbContext.EmailSettings.FirstOrDefault();

            using (var client = new SmtpClient(mailRecord.SmtpHost, mailRecord.SmtpPort))
            {
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(mailRecord.SmtpUsername, mailRecord.SmtpPassword);
                client.EnableSsl = true;

                var message = new MailMessage(mailRecord.SmtpUsername, email, subject, body)
                {
                    IsBodyHtml = true
                };

                // Add PDF attachment
                if (pdfFile != null && pdfFile.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        await pdfFile.CopyToAsync(stream);
                        stream.Position = 0;
                        var attachment = new Attachment(stream, pdfFile.FileName, "application/pdf");
                        message.Attachments.Add(attachment);

                        await client.SendMailAsync(message);
                    }
                }
                else
                {
                    await client.SendMailAsync(message);
                }
            }
        }



    }
}

using Asp.Versioning;
using Core.EmailServices;
using Data.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class MailingController : ControllerBase
    {

        private readonly IEmailService _emailService;
        private readonly ILogger<MailingController> _logger;

        public MailingController(IEmailService emailService, ILogger<MailingController> logger)
        {
            _emailService = emailService;
            _logger = logger;
        }


        [Authorize]
        [HttpPost("send-pdf-receipt")]
        public async Task<IActionResult> SendReceipt([FromForm] PdfMailDto pdfMailDto)
        {
            if (string.IsNullOrWhiteSpace(pdfMailDto.Email) || pdfMailDto.PdfFile == null)
            {
                return BadRequest("Email and PDF file are required.");
            }

            try
            {
                await _emailService.SendEmailWithPdfAsync(pdfMailDto.Email, "Plan Purchase Receipt","Congratulations. Please find attached your plan purchase receipt." ,pdfMailDto.PdfFile);
                return Ok($"Receipt sent to {pdfMailDto.Email} successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while sending the receipt.");
                return StatusCode(500, "An error occurred while sending the receipt.");
            }
        }








    }
}

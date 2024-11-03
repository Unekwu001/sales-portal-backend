using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using System.Text;

namespace API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly string logFilePath = Path.Combine("Logs", "log.txt");



        [HttpGet]
        [Route("read")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult ReadLog()
        {
            try
            {
                 

                if (!System.IO.File.Exists(logFilePath))
                {
                    return NotFound("Log file not found.");
                }

                using (FileStream fileStream = new FileStream(logFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (StreamReader reader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    string logContent = reader.ReadToEnd();
                    return Ok(logContent);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while reading the log file: {ex}");
            }
        }





      
    }
}


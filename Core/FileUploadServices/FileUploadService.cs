using Data.ipNXContext;
using Data.Models.FileUploadModel;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;



namespace Core.FileUploadServices
{
    public class FileUploadService : IFileUploadService 
    {
      
        private readonly IWebHostEnvironment _env;

        public FileUploadService(IWebHostEnvironment env)
        {
            _env = env;
        }




        public async Task<string> UploadFileAsync(IFormFile file, string subDirectory)
        {
            if (file == null || file.Length == 0)
                return null;

            // Check if _env.WebRootPath is null
            if (string.IsNullOrEmpty(_env.WebRootPath))
            {
                throw new InvalidOperationException("WebRootPath is not configured.");
            }

            var uploadDir = Path.Combine(_env.WebRootPath, "ipNX_uploads", subDirectory);
            if (!Directory.Exists(uploadDir))
                Directory.CreateDirectory(uploadDir);


            // Remove spaces from the original file name
            var sanitizedFileName = RemoveSpacesFromFileName(file.FileName);

            // Generate a unique file name
            var uniqueFileName = GenerateUniqueFileName(sanitizedFileName);

            var filePath = Path.Combine(uploadDir, uniqueFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }


            return $"/ipNX_uploads/{subDirectory}/{uniqueFileName}";
        }



        private string GenerateUniqueFileName(string originalFileName)
        {
            var extension = Path.GetExtension(originalFileName);
            var uniqueFileName = $"{Path.GetFileNameWithoutExtension(originalFileName)}_{Guid.NewGuid()}{extension}";
            return uniqueFileName;
        }

        private string RemoveSpacesFromFileName(string fileName)
        {
            return fileName.Replace(" ", string.Empty);
        }
    }
}

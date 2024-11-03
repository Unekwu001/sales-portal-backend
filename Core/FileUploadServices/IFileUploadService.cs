using Data.Models.FileUploadModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.FileUploadServices
{
    public interface IFileUploadService
    {
        Task<string> UploadFileAsync(IFormFile file, string subDirectory);
    }
}

using Microsoft.AspNetCore.Http.Features;

namespace API.ProgramSetup
{
    public static class FileUploadSetUp 
    {
        public static void FileUploadSetUpServices(this IServiceCollection services)
        {
            services.Configure<FormOptions>(options =>
            {
                options.MultipartBodyLengthLimit = 1024 * 1024 * 30; // 30 MB limit
            });
          
        }
        
    }
}

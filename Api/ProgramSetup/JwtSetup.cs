namespace API.ProgramSetup
{
    // JwtSetup.cs
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;
    using System.Text;

    namespace ipNXSalesPortalApis.AppStartUpConfig
    {
        public static class JwtSetup
        {
            public static void ConfigureJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
            {
                services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                        .AddJwtBearer(options =>
                        {
                            options.TokenValidationParameters = new TokenValidationParameters
                            {
                                ValidateIssuer = true,
                                ValidateAudience = true,
                                ValidateLifetime = true,
                                ValidateIssuerSigningKey = true,
                                ValidIssuer = configuration.GetSection("JwtSettings")["ValidIssuer"], // Set to the issuer of your JWT tokens
                                ValidAudience = configuration.GetSection("JwtSettings")["ValidAudience"], // Set to the audience of your JWT tokens
                                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("JwtSettings")["AntiHackerSecretkey"]))
                            };
                        });
            }
        }
    }

}

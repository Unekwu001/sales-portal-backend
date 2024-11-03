namespace API.ProgramSetup
{
    // SwaggerConfig.cs
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OpenApi.Models;

    namespace ipNXSalesPortalApis.AppStartUpConfig
    {
        public static class SwaggerSetup
        {
            public static void ConfigureSwagger(this IServiceCollection services)
            {
                services.AddSwaggerGen(c =>
                {
                    // Set the Swagger document properties
                    c.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Title = "ipNX Sales Portal API Service",
                        Version = "v1",
                        Description = "ipNXSalesPortal Backend APIs",
                        Contact = new OpenApiContact
                        {
                            Name = "ipNX Nigeria Limited ",
                            Email = "tshaibu" //TODO:Use an actual email
                        }
                    });
                    // To Enable authorization using Swagger (JWT)
                    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                    {
                        Name = "Authorization",
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = "Bearer",
                        BearerFormat = "JWT",
                        In = ParameterLocation.Header,
                        Description =
                            "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsI\"",
                    });
                    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
                });
            }
        }
    }

}

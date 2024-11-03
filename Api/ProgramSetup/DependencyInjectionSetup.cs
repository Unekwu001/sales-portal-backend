using Asp.Versioning;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using API.AutoMapper;
using Core.AuthServices;
using Core.CoverageServices;
using Core.CoverageServices.GoogleServices;
using Core.CustomerRequestServices;
using Core.EmailServices;
using Core.OtpServices;
using Core.PlanServices;
using Data.ipNXContext;
using Core.OrderServices;
using Core.DashBoardServices;
using Core.AgentServices;
using Core.UserServices;
using Core.FileUploadServices;
using Core.DiscountServices;


namespace API.ProgramSetup
{



    public static class DependencyInjectionSetup
    {
        public static void SetupDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            // Add services to the container.
            services.AddScoped<ICoverageService, CoverageService>();
            services.AddScoped<IGoogleGeoCodingService, GoogleGeoCodingService>();
            services.AddScoped<IPlanService, PlanService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IOtpService, OtpService>();
            services.AddScoped<ICustomerRequestService, CustomerRequestService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IDashBoardService, DashBoardService>();
            services.AddScoped<IAgentService, AgentService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IFileUploadService, FileUploadService>();
            services.AddScoped<IDiscountService, DiscountService>();
            services.AddHttpContextAccessor();

            // Database connection configuration
            var ConnString = configuration.GetConnectionString("SalesPortalDbConnection");
            services.AddDbContext<IpNxDbContext>(options =>
                options.UseNpgsql(ConnString));

            // Adding Automapper
            services.AddAutoMapper(typeof(ipNXAutoMapper));

            // Adding ApiVersioning
            var DefaultApiVersion = new ApiVersion(1, 0);

            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = DefaultApiVersion;
                options.AssumeDefaultVersionWhenUnspecified = false;
                options.ReportApiVersions = true;
                options.ApiVersionReader = new UrlSegmentApiVersionReader();
            }).AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
                options.DefaultApiVersion = DefaultApiVersion;
            }).EnableApiVersionBinding();

            // Adding controllers
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                    options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
                });

            // Adding cross-origin resource sharing
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins("*") // to be replaced: but allowing all for now.
                           .AllowAnyHeader()
                           .AllowAnyMethod()
                           .WithExposedHeaders("Authorization"); // This adds the custom authorization header to response
                });
            });
            services.AddEndpointsApiExplorer();
            services.AddHttpClient();
        }
    }







}




namespace API.ProgramSetup
{
    using Core.OtpServices;
    // HangfireSetup.cs
    using Hangfire;
    using Hangfire.PostgreSql;
    using Microsoft.Extensions.DependencyInjection;

    public static class HangfireSetup
    {
        public static void ConfigureHangfire(this WebApplication app, string connectionString)
        {
            // Configure Hangfire for BackgroundJob/Worker Service
            GlobalConfiguration.Configuration.UsePostgreSqlStorage(connectionString);

            // Get IServiceScopeFactory from application services
            var serviceScopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();

            // Schedule the cleanup job on otps to run daily at midnight using Hangfire
            using (var scope = serviceScopeFactory.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                var otpService = serviceProvider.GetRequiredService<IOtpService>();
                RecurringJob.AddOrUpdate(() => otpService.OtpCleanUpJob(), Cron.Minutely);
            }
        }
    }

}

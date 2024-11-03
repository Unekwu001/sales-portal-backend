using Serilog;
namespace API.ProgramSetup
{
    public static class LoggingSetup
    {
        public static void ConfigureLogging(this WebApplicationBuilder builder)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.Seq(builder.Configuration["Serilog:WriteTo:1:Args:serverUrl"])
                .WriteTo.File("Logs/log.txt")
                .CreateLogger();

            builder.Host.UseSerilog();
        }
    }
}

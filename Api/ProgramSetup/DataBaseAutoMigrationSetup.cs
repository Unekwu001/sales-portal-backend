using Data.ipNXContext;
using Microsoft.EntityFrameworkCore;




namespace API.ProgramSetup
{
    

    public static class DataBaseAutoMigrationSetup
    {
        public static void ApplyDatabaseMigrations(this WebApplication app)
        {
            // This ensures all migrations are applied, ensuring the database has the latest changes
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<IpNxDbContext>();
                dbContext.Database.Migrate();
            }
        }
    }



}

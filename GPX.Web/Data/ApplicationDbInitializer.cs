using Microsoft.EntityFrameworkCore;

namespace GPX.Web.Data
{
    public static class ApplicationDbInitializer
    {
        public static async Task InitializeAsync(IServiceProvider services)
        {
            await using var scope = services.CreateAsyncScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            //await dbContext.Database.MigrateAsync();
        }
    }
}

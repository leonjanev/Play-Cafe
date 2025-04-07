using PlayCafe.Services;

namespace PlayCafe.Extensions
{
    public static class SeedAsyncExtensions
    {
        public static async Task SeedAsync(this IServiceProvider services)
        {
            var scope = services.CreateScope();
            var seedDataService = scope.ServiceProvider.GetRequiredService<ISeedDataService>();
            await seedDataService.SeedDataAsync();
        }
    }
}

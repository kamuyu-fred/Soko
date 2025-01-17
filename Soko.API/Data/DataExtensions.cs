using Microsoft.EntityFrameworkCore;

namespace Soko.API.Data;

public static class DataExtensions
{
    public static async Task MigrateDbAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<SokoContext>();
        await dbContext.Database.MigrateAsync();
    }
}

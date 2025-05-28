using LojaManoel.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LojaManoel.Infrastructure.Migrations;

public static class DatabaseMigration
{
    public static async Task MigrateDatabaseAsync(IServiceProvider serviceProvider)
    {
        var dbContext = serviceProvider.GetRequiredService<LojaManoelDbContext>();
        await dbContext.Database.MigrateAsync();
    }
}
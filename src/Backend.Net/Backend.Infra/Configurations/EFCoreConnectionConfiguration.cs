using Backend.Infra.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Infra.Configurations;

public static class EFCoreConnectionConfiguration
{
    public static IServiceCollection AddDbContextInjector(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connection = configuration.GetConnectionString("SqliteConnection");
        services.AddDbContext<PokedexContext>(options =>
        {
            options.UseSqlite(connection);
        });

        return services;
    }

    public static IApplicationBuilder MigrateDatabase(this IApplicationBuilder builder)
    {
        using var serviceScope = builder.ApplicationServices
            .GetRequiredService<IServiceScopeFactory>().CreateScope();
        using var context = serviceScope.ServiceProvider.GetService<PokedexContext>();

        if (context.MigrateDatabase()) return builder;

        context.Database.Migrate();

        return builder;
    }
}
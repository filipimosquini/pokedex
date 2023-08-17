using Backend.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.Data.Sqlite;

namespace Backend.Infra.Configurations;

public static class EFCoreConnectionConfiguration
{
    public static DbContextOptionsBuilder<PokedexContext> ConfigureBuilder()
    {
        var connectionString = ConfigurationManager.AppSettings["SqliteConnection"];

        var optionsBuilder = new DbContextOptionsBuilder<PokedexContext>();

        var conn = new SqliteConnection(connectionString);

        optionsBuilder.UseSqlite(conn);

        SQLitePCL.Batteries.Init();

        return optionsBuilder;
    }

}
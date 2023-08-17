using System;
using Backend.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.Data.Sqlite;

namespace Backend.Infra.Configurations;

public static class EFCoreConnectionConfiguration
{
    public static DbContextOptionsBuilder<PokedexContext> ConfigureBuilder()
    {
        var optionsBuilder = new DbContextOptionsBuilder<PokedexContext>();

        optionsBuilder.UseSqlite(CriarConnectionString());

        SQLitePCL.Batteries.Init();

        return optionsBuilder;
    }

    private static SqliteConnection CriarConnectionString()
    {
        var connectionString = ConfigurationManager.AppSettings["SqliteConnection"];

        var baseDirectory = AppDomain.CurrentDomain.BaseDirectory.Replace("Backend.Api\\", string.Empty);

        connectionString = connectionString.Replace("{AppDir}", baseDirectory);

        var connection = new SqliteConnection(connectionString);

        return connection;
    }

}
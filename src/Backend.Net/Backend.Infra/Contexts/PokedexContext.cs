﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using System.Data.Common;

namespace Backend.Infra.Contexts;

public class PokedexContext : DbContext
{
    private readonly IConfiguration _configuration;

    public PokedexContext(DbContextOptions<PokedexContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlite(_configuration.GetConnectionString(GetType().Name));

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PokedexContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    public async Task<bool> Commit()
    {
        if (await base.SaveChangesAsync() <= 0)
            return false;

        return true;
    }

    public bool DatabaseExists()
    {
        try
        {
            return Database.GetService<IRelationalDatabaseCreator>().Exists();
        }
        catch (DbException)
        {
            return false;
        }
    }

    public bool MigrateDatabase()
    {
        var idsDasMigrationJaExecutadas = this.GetService<IHistoryRepository>()
            .GetAppliedMigrations()
            .Select(m => m.MigrationId);

        var idsDeTodasAsMigrations = this.GetService<IMigrationsAssembly>()
            .Migrations
            .Select(m => m.Key);

        return !idsDeTodasAsMigrations.Except(idsDasMigrationJaExecutadas).Any();
    }
}
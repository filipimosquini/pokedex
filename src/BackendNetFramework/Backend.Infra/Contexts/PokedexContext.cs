using Backend.Domain.Bases.Repositories;
using Backend.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Infra.Contexts;

public class PokedexContext : DbContext, IUnitOfWork
{
    private readonly string _connectionString;

    public PokedexContext(DbContextOptions<PokedexContext> options, string connectionString) : base(options)
    {
        _connectionString = connectionString;
    }

    public DbSet<Pokemon> Pokemons { get; set; }
    public DbSet<MestrePokemon> MestresPokemon { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlite(_connectionString);

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
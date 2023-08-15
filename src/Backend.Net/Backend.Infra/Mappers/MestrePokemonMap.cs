using Backend.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infra.Mappers;

public class MestrePokemonMap : IEntityTypeConfiguration<MestrePokemon>
{
    public void Configure(EntityTypeBuilder<MestrePokemon> builder)
    {
        builder.ToTable("mestre_pokemon");
        builder.HasKey(x => x.Id);

        builder
            .HasMany(x => x.Pokemons)
            .WithOne(x => x.MestrePokemon)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
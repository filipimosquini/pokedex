using Backend.Domain.ApplicationServices.Pokemons.Requests;
using Backend.Domain.Models;

namespace Backend.Domain.Extensions;

public static class PokemonExtension
{
    public static Pokemon ToModel(this CapturarPokemonRequest request, string nomePokemon)
    {
        if (request is null)
        {
            return null;
        }

        return new Pokemon
        {
            PokemonId = request.PokemonId,
            Nome = nomePokemon,
            MestrePokemonId = request.MestrePokemonId
        };
    }
}
using Backend.Domain.ApplicationServices.Pokemons.Requests;
using Backend.Domain.ApplicationServices.Pokemons.Responses;
using Backend.Domain.Models;
using System.Collections.Generic;
using System.Linq;

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

    public static IEnumerable<PokemonCapturadoResponse> ToResponses(this IEnumerable<Pokemon> pokemons)
    {
        if (pokemons is null)
        {
            return new List<PokemonCapturadoResponse>();
        }

        return pokemons.Select(x => x.ToResponse());
    }


    public static PokemonCapturadoResponse ToResponse(this Pokemon pokemon)
    {
        if (pokemon is null)
        {
            return null;
        }

        return new PokemonCapturadoResponse
        {
            Id = pokemon.PokemonId,
            Nome = pokemon.Nome,
            MestrePokemon = pokemon.MestrePokemon.Nome,
        };
    }
}
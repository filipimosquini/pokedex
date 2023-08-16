using System.Collections.Generic;
using System.Linq;
using Backend.Domain.ApplicationServices.MestresPokemons.Responses;
using Backend.Domain.AppplicationServices.MestresPokemons.Requests;
using Backend.Domain.Models;

namespace Backend.Domain.Extensions;

public static class MestrePokemonExtension
{
    public static MestrePokemon ToModel(this AdicionarMestrePokemonRequest request)
    {
        if (request is null)
        {
            return null;
        }

        return new MestrePokemon
        {
            Nome = request.Nome,
            Idade = request.Idade,
            CPF = request.Cpf
        };
    }

    public static IEnumerable<MestrePokemonResponse> ToResponses(this IEnumerable<MestrePokemon> mestresPokemons)
    {
        if (mestresPokemons is null)
        {
            return new List<MestrePokemonResponse>();
        }

        return mestresPokemons.Select(x => x.ToResponse());
    }

    public static MestrePokemonResponse ToResponse(this MestrePokemon mestrePokemon)
    {
        if (mestrePokemon is null)
        {
            return new MestrePokemonResponse();
        }

        return new MestrePokemonResponse
        {
            Id = mestrePokemon.Id,
            Nome = mestrePokemon.Nome,
            Idade = mestrePokemon.Idade,
            Cpf = mestrePokemon.CPF,
            Pokemons = mestrePokemon.Pokemons.Select(x => x.Nome).ToList() 
        };
    }

    public static FiltroMestrePokemonRequest ToFilter(this AdicionarMestrePokemonRequest mestrePokemon)
        => new FiltroMestrePokemonRequest()
        {
            Nome = mestrePokemon.Nome,
            Cpf = mestrePokemon.Cpf,
            IdadeInicio = mestrePokemon.Idade,
            IdadeFim = mestrePokemon.Idade
        };
}
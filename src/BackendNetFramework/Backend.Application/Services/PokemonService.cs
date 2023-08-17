using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Backend.CrossCutting.Expressions;
using Backend.Domain.ApplicationServices.Pokemons.Requests;
using Backend.Domain.ApplicationServices.Pokemons.Responses;
using Backend.Domain.Gateways;
using Backend.Domain.Gateways.DataTransferObjects.EvolucaoPokemon;
using Backend.Domain.Models;
using Backend.Domain.Queries.Pokemons;
using Backend.Domain.Repositories;
using Backend.Domain.Services;

namespace Backend.Application.Services;

public class PokemonService : IPokemonService
{
    private readonly IPokemonGateway _pokemonGateway;
    private readonly IPokemonRepository _pokemonRepository;

    public PokemonService(IPokemonGateway pokemonGateway, IPokemonRepository pokemonRepository)
    {
        _pokemonGateway = pokemonGateway;
        _pokemonRepository = pokemonRepository;
    }

    public async Task<IEnumerable<Pokemon>> ListarAsync(FiltroPokemonCapturadoRequest filtros)
    {
        Expression<Func<Pokemon, bool>> queryBase = mestrePokemon => 1 == 1;

        if (!string.IsNullOrWhiteSpace(filtros.Nome))
        {
            queryBase = queryBase.JoinExpressions(FiltrarPorNomeQuery.Filtrar(filtros.Nome));
        }

        if (!string.IsNullOrWhiteSpace(filtros.MestrePokemon))
        {
            queryBase = queryBase.JoinExpressions(FiltrarPorNomeMestrePokemonQuery.Filtrar(filtros.MestrePokemon));
        }

        return await _pokemonRepository.ListarAsync(queryBase);
    }

    public async Task<IEnumerable<PokemonResponse>> ListarDeFonteExternaAsync()
    {
        Random random = new Random();
        var pokemonIds = Enumerable.Range(1, 1010).OrderBy(x => random.Next()).Take(10);

        var responses = new List<PokemonResponse>();

        foreach (var pokemonId in pokemonIds)
        {
            responses.Add(await ObterDeFonteExternaAsync(pokemonId));
        }

        return responses;
    }

    public async Task<PokemonResponse> ObterDeFonteExternaAsync(int pokemonId)
    {
        var dadosBasicos = await _pokemonGateway.ObterPokemonAsync(pokemonId);
        var evolucoes = await ObterEvolucoesPokemon(pokemonId);

        return new PokemonResponse()
        {
            Id = dadosBasicos.id,
            Nome = dadosBasicos?.name,
            Evolucoes = evolucoes
        };
    }

    protected async Task<List<string>> ObterEvolucoesPokemon(int pokemonId)
    {
        var dto = await _pokemonGateway.ObterEvolucaoPokemonAsync(pokemonId);

        if (dto is null)
        {
            return new List<string>();
        }

        var nomes = new List<string>();

        var evolucoes = new List<List<EvolvesTo>>();
        evolucoes.Add(dto.chain.evolves_to);

        var index = 0;
        while (evolucoes[index].Count > 0)
        {
            var ev = evolucoes[index][0];

            nomes.Add(ev.species.name);

            evolucoes.Add(ev.evolves_to);

            index++;
        }

        return nomes;
    }
}
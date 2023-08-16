using Backend.Domain.ApplicationServices.Pokemons.Responses;
using Backend.Domain.Gateways;
using Backend.Domain.Gateways.DataTransferObjects.EvolucaoPokemon;
using Backend.Domain.Services;

namespace Backend.Application.Services;

public class PokemonService : IPokemonService
{
    private readonly IPokemonGateway _pokemonGateway;

    public PokemonService(IPokemonGateway pokemonGateway)
    {
        _pokemonGateway = pokemonGateway;
    }

    public async Task<IEnumerable<PokemonResponse>> ListarAsync()
    {
        Random random = new Random();
        var pokemonIds = Enumerable.Range(1, 1010).OrderBy(x => random.Next()).Take(10);

        var responses = new List<PokemonResponse>();

        foreach (var pokemonId in pokemonIds)
        {
            responses.Add(await ObterAsync(pokemonId));
        }

        return responses;
    }

    public async Task<PokemonResponse> ObterAsync(int pokemonId)
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
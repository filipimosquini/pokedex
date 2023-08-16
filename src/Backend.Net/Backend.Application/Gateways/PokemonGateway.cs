using Backend.CrossCutting.Clients.http;
using Backend.CrossCutting.Sections;
using Backend.Domain.Gateways;
using Backend.Domain.Gateways.DataTransferObjects.EvolucaoPokemon;
using Backend.Domain.Gateways.DataTransferObjects.Pokemon;
using Microsoft.Extensions.Options;

namespace Backend.Application.Gateways;

public class PokemonGateway : IPokemonGateway
{ 
    private readonly IHttpClientConnection _httpClientConnection;
    private readonly Pokeapi _pokeapi;

    public PokemonGateway(IHttpClientConnection httpClientConnection, IOptions<Pokeapi> pokeapi)
    {
        _httpClientConnection = httpClientConnection;
        _pokeapi = pokeapi.Value;
    }

    public async Task<PokemonDto?> ObterPokemonAsync(int pokemonId)
    {
        return await _httpClientConnection.GetAsync<PokemonDto>(_pokeapi.BaseAddress, resource: _pokeapi.Pokemon, query: pokemonId.ToString());
    }

    public async Task<EvolucaoPokemonDto?> ObterEvolucaoPokemonAsync(int pokemonId)
    {
        return await _httpClientConnection.GetAsync<EvolucaoPokemonDto>(_pokeapi.BaseAddress, resource: _pokeapi.EvolucaoPokemon, query: pokemonId.ToString());
    }
}
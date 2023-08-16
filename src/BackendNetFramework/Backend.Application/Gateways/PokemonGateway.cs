using System.Configuration;
using System.Threading.Tasks;
using Backend.CrossCutting.Clients.Http;
using Backend.Domain.Gateways;
using Backend.Domain.Gateways.DataTransferObjects.EvolucaoPokemon;
using Backend.Domain.Gateways.DataTransferObjects.Pokemon;

namespace Backend.Application.Gateways;

public class PokemonGateway : IPokemonGateway
{ 
    private readonly IHttpClientConnection _httpClientConnection;

    private readonly string BaseAddressUrl = ConfigurationManager.AppSettings["BaseAddress"];
    private readonly string PokemonUrl = ConfigurationManager.AppSettings["Pokemon"];
    private readonly string EvolucaoPokemonUrl = ConfigurationManager.AppSettings["EvolucaoPokemon"];

    public PokemonGateway(IHttpClientConnection httpClientConnection)
    {
        _httpClientConnection = httpClientConnection;
    }

    public async Task<PokemonDto> ObterPokemonAsync(int pokemonId)
    {
        return await _httpClientConnection.GetAsync<PokemonDto>(BaseAddressUrl, resource: PokemonUrl, query: pokemonId.ToString());
    }

    public async Task<EvolucaoPokemonDto?> ObterEvolucaoPokemonAsync(int pokemonId)
    {
        return await _httpClientConnection.GetAsync<EvolucaoPokemonDto>(BaseAddressUrl, resource: EvolucaoPokemonUrl, query: pokemonId.ToString());
    }
}
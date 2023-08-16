using Backend.Domain.ApplicationServices.Pokemons;
using Backend.Domain.ApplicationServices.Pokemons.Responses;
using Backend.Domain.Services;

namespace Backend.Application.AppplicationServices;

public class PokemonApplicationService : IPokemonApplicationService
{
    private readonly IPokemonService _pokemonService;

    public PokemonApplicationService(IPokemonService pokeService)
    {
        _pokemonService = pokeService;
    }

    public async Task<PokemonResponse> ObterAsync(int pokemonId)
        => await _pokemonService.ObterAsync(pokemonId);

    public async Task<IEnumerable<PokemonResponse>> ListarAsync()
    => await _pokemonService.ListarAsync();
    
}
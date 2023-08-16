using Backend.Domain.ApplicationServices.Pokemons.Responses;

namespace Backend.Domain.Services;

public interface IPokemonService
{
    Task<IEnumerable<PokemonResponse>> ListarAsync();
    Task<PokemonResponse> ObterAsync(int pokemonId);
}
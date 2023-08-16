using Backend.Domain.ApplicationServices.Pokemons.Responses;

namespace Backend.Domain.ApplicationServices.Pokemons;

public interface IPokemonApplicationService
{
    Task<PokemonResponse> ObterAsync(int pokemonId);
    Task<IEnumerable<PokemonResponse>> ListarAsync();
}
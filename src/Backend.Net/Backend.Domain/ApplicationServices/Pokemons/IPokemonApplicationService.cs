using Backend.Domain.ApplicationServices.Pokemons.Requests;
using Backend.Domain.ApplicationServices.Pokemons.Responses;
using Backend.Domain.Bases.ApplicationsServices;
namespace Backend.Domain.ApplicationServices.Pokemons;

public interface IPokemonApplicationService
{
    Task<ICustomValidationResult> CapturarAsync(CapturarPokemonRequest request);
    Task<PokemonResponse> ObterAsync(int pokemonId);
    Task<IEnumerable<PokemonResponse>> ListarAsync();
}
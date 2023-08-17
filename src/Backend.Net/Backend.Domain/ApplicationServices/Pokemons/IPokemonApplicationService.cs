using Backend.Domain.ApplicationServices.Pokemons.Requests;
using Backend.Domain.ApplicationServices.Pokemons.Responses;
using Backend.Domain.Bases.ApplicationsServices;
namespace Backend.Domain.ApplicationServices.Pokemons;

public interface IPokemonApplicationService
{
    Task<ICustomValidationResult> CapturarAsync(CapturarPokemonRequest request);
    Task<IEnumerable<PokemonResponse>> ListarAsync();
    Task<IEnumerable<PokemonCapturadoResponse>> ListarPokemonsCapturadosAsync(FiltroPokemonCapturadoRequest request);
    Task<PokemonResponse> ObterAsync(int pokemonId);
}
using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Domain.ApplicationServices.Pokemons.Responses;

namespace Backend.Domain.Services;

public interface IPokemonService
{
    Task<IEnumerable<PokemonResponse>> ListarDeFonteExternaAsync();
    Task<PokemonResponse> ObterDeFonteExternaAsync(int pokemonId);
}
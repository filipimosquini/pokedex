using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Domain.ApplicationServices.Pokemons.Requests;
using Backend.Domain.ApplicationServices.Pokemons.Responses;
using Backend.Domain.Models;

namespace Backend.Domain.Services;

public interface IPokemonService
{
    Task<IEnumerable<Pokemon>> ListarAsync(FiltroPokemonCapturadoRequest filtros);
    Task<IEnumerable<PokemonResponse>> ListarDeFonteExternaAsync();
    Task<PokemonResponse> ObterDeFonteExternaAsync(int pokemonId);
}
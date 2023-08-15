using Backend.Domain.AppplicationServices.MestresPokemons.Requests;
using Backend.Domain.Models;

namespace Backend.Domain.Services;

public interface IMestrePokemonService
{
    Task<IEnumerable<MestrePokemon>> ListarAsync(FiltroMestrePokemonRequest filtros);
    Task<MestrePokemon> ObterPorIdAsync(string id);
    Task<MestrePokemon> ObterAsync(FiltroMestrePokemonRequest filtros);
}
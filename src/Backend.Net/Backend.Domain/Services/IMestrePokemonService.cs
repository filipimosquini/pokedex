using Backend.Domain.Models;

namespace Backend.Domain.Services;

public interface IMestrePokemonService
{
    Task<IEnumerable<MestrePokemon>> ListarAsync();
}
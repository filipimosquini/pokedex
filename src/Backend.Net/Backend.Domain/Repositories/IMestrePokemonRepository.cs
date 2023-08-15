using Backend.Domain.Models;

namespace Backend.Domain.Repositories;

public interface IMestrePokemonRepository
{
    Task<IEnumerable<MestrePokemon>> ListarAsync();
}
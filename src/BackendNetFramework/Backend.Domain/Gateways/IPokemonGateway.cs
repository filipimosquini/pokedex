using System.Threading.Tasks;
using Backend.Domain.Gateways.DataTransferObjects.EvolucaoPokemon;
using Backend.Domain.Gateways.DataTransferObjects.Pokemon;

namespace Backend.Domain.Gateways;

public interface IPokemonGateway
{
    Task<PokemonDto> ObterPokemonAsync(int pokemonId);
    Task<EvolucaoPokemonDto?> ObterEvolucaoPokemonAsync(int pokemonId);
}
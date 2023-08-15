using Backend.Domain.Models;
using Backend.Domain.Repositories;
using Backend.Domain.Services;

namespace Backend.Application.Services;

public class MestrePokemonService : IMestrePokemonService
{
    private readonly IMestrePokemonRepository _mestrePokemonRepository;

    public MestrePokemonService(IMestrePokemonRepository mestrePokemonRepository)
    {
        _mestrePokemonRepository = mestrePokemonRepository;
    }

    public async Task<IEnumerable<MestrePokemon>> ListarAsync()
    => await _mestrePokemonRepository.ListarAsync();
}
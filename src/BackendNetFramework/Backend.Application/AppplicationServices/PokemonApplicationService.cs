using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Application.Configurations.Bases;
using Backend.Domain.ApplicationServices.Pokemons;
using Backend.Domain.ApplicationServices.Pokemons.Requests;
using Backend.Domain.ApplicationServices.Pokemons.Responses;
using Backend.Domain.Bases.ApplicationsServices;
using Backend.Domain.Extensions;
using Backend.Domain.Queries.Pokemons;
using Backend.Domain.Repositories;
using Backend.Domain.Services;

namespace Backend.Application.AppplicationServices;

public class PokemonApplicationService : BaseApplicationService, IPokemonApplicationService
{
    private readonly IPokemonService _pokemonService;
    private readonly IMestrePokemonService _mestrePokemonService;
    private readonly IPokemonRepository _pokemonRepository;

    public PokemonApplicationService(IPokemonService pokeService, IMestrePokemonService mestrePokemonService, IPokemonRepository pokemonRepository)
    {
        _pokemonService = pokeService;
        _mestrePokemonService = mestrePokemonService;
        _pokemonRepository = pokemonRepository;
    }

    public async Task<ICustomValidationResult> CapturarAsync(CapturarPokemonRequest request)
    {
        var pokemon = await _pokemonService.ObterDeFonteExternaAsync(request.PokemonId);
        var mestrePokemon = await _mestrePokemonService.ObterPorIdAsync(request.MestrePokemonId);
        var pokemonCapturado = await _pokemonRepository.ObterAsync(FiltrarPorIdQuery.Filtrar(request.PokemonId));

        if (pokemon is null)
        {
            AddError("O Pokemon não foi encontrado");
        }

        if (mestrePokemon is null)
        {
            AddError("O Mestre Pokemon não foi encontrado");
        }

        if (!CustomValidationResult.IsValid)
        {
            return CustomValidationResult;
        }

        if (pokemonCapturado is not null)
        {
            AddError("O Pokemon já foi capturado");
            return CustomValidationResult;
        }

        await _pokemonRepository.AddAsync(request.ToModel(pokemon.Nome));
        await CommitAsync(_pokemonRepository.UnitOfWork);

        CustomValidationResult.Data = "Pokemon capturado com sucesso";

        return CustomValidationResult;
    }

    public async Task<PokemonResponse> ObterAsync(int pokemonId)
        => await _pokemonService.ObterDeFonteExternaAsync(pokemonId);

    public async Task<IEnumerable<PokemonResponse>> ListarAsync()
    => await _pokemonService.ListarDeFonteExternaAsync();
    
}
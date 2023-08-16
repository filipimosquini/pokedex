using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Application.Configurations.Bases;
using Backend.Domain.ApplicationServices.MestresPokemons;
using Backend.Domain.ApplicationServices.MestresPokemons.Responses;
using Backend.Domain.AppplicationServices.MestresPokemons.Requests;
using Backend.Domain.Bases.ApplicationsServices;
using Backend.Domain.Extensions;
using Backend.Domain.Repositories;
using Backend.Domain.Services;

namespace Backend.Application.AppplicationServices;

public class MestrePokemonApplicationService : BaseApplicationService, IMestrePokemonApplicationService
{
    private readonly IMestrePokemonService _mestrePokemonService;
    private readonly IMestrePokemonRepository _mestrePokemonRepository;

    public MestrePokemonApplicationService(IMestrePokemonService mestrePokemonService, IMestrePokemonRepository mestrePokemonRepository)
    {
        _mestrePokemonService = mestrePokemonService;
        _mestrePokemonRepository = mestrePokemonRepository;
    }

    public async Task<ICustomValidationResult> AdicionarAsync(AdicionarMestrePokemonRequest request)
    {
        var mestrePokemon = request.ToModel();

        var existeMestrePokemon = await _mestrePokemonService.ObterAsync(request.ToFilter()) is not null;

        if (existeMestrePokemon)
        {
            AddError("O mestre pokemon já está cadastrado");
            return CustomValidationResult;
        }

        await _mestrePokemonRepository.AddAsync(mestrePokemon);

        await CommitAsync(_mestrePokemonRepository.UnitOfWork);

        CustomValidationResult.Data = "Mestre Pokemon adicionado com sucesso";

        return CustomValidationResult;
    }

    public async Task<ICustomValidationResult> AtualizarAsync(AtualizarMestrePokemonRequest request)
    {
        var mestrePokemon = await _mestrePokemonService.ObterPorIdAsync(request.Id);

        if (mestrePokemon is null)
        {
            AddError("O mestre pokemon nao foi encontrado");
            return CustomValidationResult;
        }

        mestrePokemon.Nome = request.Nome;
        mestrePokemon.Idade = request.Idade;
        mestrePokemon.CPF = request.Cpf;

        _mestrePokemonRepository.Update(mestrePokemon);

        await CommitAsync(_mestrePokemonRepository.UnitOfWork);

        CustomValidationResult.Data = "Mestre Pokemon atualizado com sucesso";

        return CustomValidationResult;
    }

    public async Task<IEnumerable<MestrePokemonResponse>> ListarAsync(FiltroMestrePokemonRequest request)
    {
        var resultado = await _mestrePokemonService.ListarAsync(request);
        return resultado.ToResponses();
    }

    public async Task<MestrePokemonResponse> ObterAsync(string id)
    {
        var resultado = await _mestrePokemonService.ObterPorIdAsync(id);
        return resultado.ToResponse();
    }
}
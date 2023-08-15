using Backend.CrossCutting.Expressions;
using Backend.Domain.AppplicationServices.MestresPokemons.Requests;
using Backend.Domain.Models;
using Backend.Domain.Queries.MestresPokemons;
using Backend.Domain.Repositories;
using Backend.Domain.Services;
using System.Linq.Expressions;

namespace Backend.Application.Services;

public class MestrePokemonService : IMestrePokemonService
{
    private readonly IMestrePokemonRepository _mestrePokemonRepository;

    public MestrePokemonService(IMestrePokemonRepository mestrePokemonRepository)
    {
        _mestrePokemonRepository = mestrePokemonRepository;
    }

    public async Task<IEnumerable<MestrePokemon>> ListarAsync(FiltroMestrePokemonRequest filtros)
    {
        Expression<Func<MestrePokemon, bool>> queryBase = mestrePokemon => 1 == 1;

        if (!string.IsNullOrWhiteSpace(filtros.Nome))
        {
            queryBase = queryBase.JoinExpressions(FitrarPorNomeQuery.Filtrar(filtros.Nome));
        }

        if (!string.IsNullOrWhiteSpace(filtros.Cpf))
        {
            queryBase = queryBase.JoinExpressions(FiltrarPorCpfQuery.Filtrar(filtros.Cpf));
        }

        if (filtros.IdadeInicio > 0 || filtros.IdadeFim < Int32.MaxValue)
        {
            queryBase = queryBase.JoinExpressions(FiltrarPorIdadeQuery.Filtrar(filtros.IdadeInicio, filtros.IdadeFim));
        }

        return await _mestrePokemonRepository.ListarAsync(queryBase);
    }

    public async Task<MestrePokemon> ObterPorIdAsync(string id)
        => await _mestrePokemonRepository.ObterAsync(FiltrarPorIdQuery.Filtrar(id));

    public async Task<MestrePokemon> ObterAsync(FiltroMestrePokemonRequest filtros)
    {
        Expression<Func<MestrePokemon, bool>> queryBase = mestrePokemon => 1 == 1;

        if (!string.IsNullOrWhiteSpace(filtros.Nome))
        {
            queryBase = queryBase.JoinExpressions(FitrarPorNomeQuery.Filtrar(filtros.Nome));
        }

        if (!string.IsNullOrWhiteSpace(filtros.Cpf))
        {
            queryBase = queryBase.JoinExpressions(FiltrarPorCpfQuery.Filtrar(filtros.Cpf));
        }

        if (filtros.IdadeInicio > 0 || filtros.IdadeFim < Int32.MaxValue)
        {
            queryBase = queryBase.JoinExpressions(FiltrarPorIdadeQuery.Filtrar(filtros.IdadeInicio, filtros.IdadeFim));
        }

        return await _mestrePokemonRepository.ObterAsync(queryBase);
    }
}
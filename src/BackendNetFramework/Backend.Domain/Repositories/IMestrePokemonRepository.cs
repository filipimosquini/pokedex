using System;
using System.Collections.Generic;
using Backend.Domain.Models;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Backend.Domain.Bases.Repositories;

namespace Backend.Domain.Repositories;

public interface IMestrePokemonRepository : IBaseRepository<MestrePokemon>
{
    Task<IEnumerable<MestrePokemon>> ListarAsync(Expression<Func<MestrePokemon, bool>> filtros);
    Task<MestrePokemon> ObterAsync(Expression<Func<MestrePokemon, bool>> filtros);
}
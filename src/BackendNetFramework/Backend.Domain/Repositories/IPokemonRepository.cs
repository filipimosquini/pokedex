using System;
using Backend.Domain.Bases.Repositories;
using Backend.Domain.Models;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Backend.Domain.Repositories;

public interface IPokemonRepository : IBaseRepository<Pokemon>
{
    Task<IEnumerable<Pokemon>> ListarAsync(Expression<Func<Pokemon, bool>> filtros);
    Task<Pokemon> ObterAsync(Expression<Func<Pokemon, bool>> filtros);
}
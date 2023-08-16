using System;
using Backend.Domain.Bases.Repositories;
using Backend.Domain.Models;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Backend.Domain.Repositories;

public interface IPokemonRepository : IBaseRepository<Pokemon>
{
    Task<Pokemon> ObterAsync(Expression<Func<Pokemon, bool>> filtros);
}
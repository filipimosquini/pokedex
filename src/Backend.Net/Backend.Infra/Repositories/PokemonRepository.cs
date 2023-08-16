using System.Linq.Expressions;
using Backend.Domain.Models;
using Backend.Domain.Repositories;
using Backend.Infra.Bases;
using Backend.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infra.Repositories;

public class PokemonRepository : BaseRepository<Pokemon>, IPokemonRepository
{
    private readonly PokedexContext _context;
    public PokemonRepository(PokedexContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Pokemon> ObterAsync(Expression<Func<Pokemon, bool>> filtros)
        => await _context.Pokemons.FirstOrDefaultAsync(filtros);
}
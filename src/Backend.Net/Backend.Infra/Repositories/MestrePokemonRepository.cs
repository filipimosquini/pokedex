using System.Linq.Expressions;
using Backend.Domain.Models;
using Backend.Domain.Repositories;
using Backend.Infra.Bases;
using Backend.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infra.Repositories;

public class MestrePokemonRepository : BaseRepository<MestrePokemon>, IMestrePokemonRepository
{
    private readonly PokedexContext _context;
    public MestrePokemonRepository(PokedexContext context) : base(context)
    {
        _context = context;
    }

    public async Task<MestrePokemon> ObterAsync(Expression<Func<MestrePokemon, bool>> filtros)
        => await _context.MestresPokemon
            //.Include(x => x.Pokemons)
            .FirstOrDefaultAsync(filtros);

    public async Task<IEnumerable<MestrePokemon>> ListarAsync(Expression<Func<MestrePokemon, bool>> filtros)
        => await _context.MestresPokemon
            .AsNoTracking()
            //.Include(x => x.Pokemons)
            .Where(filtros)
            .ToListAsync();
}
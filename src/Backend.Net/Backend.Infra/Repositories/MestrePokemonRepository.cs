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

    public async Task<IEnumerable<MestrePokemon>> ListarAsync()
        => await _context.MestresPokemon.ToListAsync();
}
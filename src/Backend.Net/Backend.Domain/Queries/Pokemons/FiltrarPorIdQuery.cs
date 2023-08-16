using System.Linq.Expressions;

namespace Backend.Domain.Queries.Pokemons;

public static class FiltrarPorIdQuery
{
    public static Expression<Func<Models.Pokemon, bool>> Filtrar(int id)
    {
        return pokemon => pokemon.PokemonId == id;
    }
}
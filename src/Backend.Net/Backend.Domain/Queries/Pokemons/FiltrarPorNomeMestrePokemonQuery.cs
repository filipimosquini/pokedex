using System.Linq.Expressions;

namespace Backend.Domain.Queries.Pokemons;

public class FiltrarPorNomeMestrePokemonQuery
{
    public static Expression<Func<Models.Pokemon, bool>> Filtrar(string nome)
    {
        return pokemon => pokemon.MestrePokemon.Nome.ToLower().Contains(nome.ToLower());
    }
}
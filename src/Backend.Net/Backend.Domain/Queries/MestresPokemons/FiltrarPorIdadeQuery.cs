using System.Linq.Expressions;

namespace Backend.Domain.Queries.MestresPokemons;

public static class FiltrarPorIdadeQuery
{
    public static Expression<Func<Models.MestrePokemon, bool>> Filtrar(int inicio, int fim)
    {
        return mestrePokemon => mestrePokemon.Idade >= inicio && mestrePokemon.Idade <= fim;
    }
}
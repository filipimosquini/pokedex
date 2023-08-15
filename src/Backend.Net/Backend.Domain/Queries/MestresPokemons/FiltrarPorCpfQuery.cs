using System.Linq.Expressions;

namespace Backend.Domain.Queries.MestresPokemons;

public static class FiltrarPorCpfQuery
{
    public static Expression<Func<Models.MestrePokemon, bool>> Filtrar(string cpf)
    {
        return mestrePokemon => mestrePokemon.CPF == cpf;
    }
}
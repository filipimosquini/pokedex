using System;
using System.Linq.Expressions;

namespace Backend.Domain.Queries.MestresPokemons;

public static class FitrarPorNomeQuery
{
    public static Expression<Func<Models.MestrePokemon, bool>> Filtrar(string nome)
    {
        return mestrePokemon => mestrePokemon.Nome.ToLower().Contains(nome.ToLower());
    }
}
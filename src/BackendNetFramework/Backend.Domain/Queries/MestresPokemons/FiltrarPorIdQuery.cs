using System;
using System.Linq.Expressions;

namespace Backend.Domain.Queries.MestresPokemons;

public static class FiltrarPorIdQuery
{
    public static Expression<Func<Models.MestrePokemon, bool>> Filtrar(string id)
    {
        return mestrePokemon => mestrePokemon.Id == id;
    }
}
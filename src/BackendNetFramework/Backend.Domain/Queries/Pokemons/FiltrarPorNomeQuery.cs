using System;
using System.Linq.Expressions;

namespace Backend.Domain.Queries.Pokemons;

public static class FiltrarPorNomeQuery
{
    public static Expression<Func<Models.Pokemon, bool>> Filtrar(string nome)
    {
        return mestrePokemon => mestrePokemon.Nome.ToLower().Contains(nome.ToLower());
    }
}
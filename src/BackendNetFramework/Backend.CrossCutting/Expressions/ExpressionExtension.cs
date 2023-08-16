using System;
using System.Linq.Expressions;

namespace Backend.CrossCutting.Expressions;

public static class ExpressionExtension
{
    public static Expression<Func<TEntity, bool>> JoinExpressions<TEntity>(this Expression<Func<TEntity, bool>> queryBase, Expression<Func<TEntity, bool>> query)
    {
        var parameters = Expression.Parameter(typeof(TEntity), "entity");
        var body = Expression.AndAlso(Expression.Invoke(queryBase, parameters), Expression.Invoke(query, parameters));

        return Expression.Lambda<Func<TEntity, bool>>(body, parameters);
    }
}
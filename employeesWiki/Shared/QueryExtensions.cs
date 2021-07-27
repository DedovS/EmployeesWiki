using employeesWiki.Contracts;
using employeesWiki.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace employeesWiki.Shared
{
    public static class QueryExtensions
    {
        public static IQueryable<T> SortBy<T>(this IQueryable<T> query, IPageParams pageParams) where T : BaseEntity
        {
            pageParams.OrderDirection = pageParams.OrderDirection == "desc" || pageParams.OrderDirection == "asc"
                ? pageParams.OrderDirection
                : "asc";

            var orderQuery = query.OrderBy(x => 0);

            orderQuery = !String.IsNullOrEmpty(pageParams.OrderColumn)
                   ? orderQuery.ThenBy(($"{pageParams.OrderColumn} {pageParams.OrderDirection}"))
                   : orderQuery;

            return orderQuery;
        }

        public static IQueryable<T> Pagination<T>(this IQueryable<T> query, IPageParams pageParams)
        {
            var skip = pageParams.PageNumber * pageParams.PageSize;
            var pageSize = pageParams.PageSize > 0 ? pageParams.PageSize : 10;

            var result = query
                .Skip(skip)
                .Take(pageSize);

            return result;
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first != null ? first.Compose(second, Expression.AndAlso) : second;
        }

        public static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
        {
            // build parameter map (from parameters of second to parameters of first)
            var map = first.Parameters.Select((f, i) => new { f, s = second.Parameters[i] }).ToDictionary(p => p.s, p => p.f);

            // replace parameters in the second lambda expression with parameters from the first
            var secondBody = ParameterRebinder.ReplaceParameters(map, second.Body);

            // apply composition of lambda expression bodies to parameters from the first expression
            return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
        }
    }

    public class ParameterRebinder : ExpressionVisitor
    {
        private readonly Dictionary<ParameterExpression, ParameterExpression> map;

        public ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
        {
            this.map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
        }

        public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp)
        {
            return new ParameterRebinder(map).Visit(exp);
        }

        protected override Expression VisitParameter(ParameterExpression p)
        {
            ParameterExpression replacement;
            if (map.TryGetValue(p, out replacement))
            {
                p = replacement;
            }
            return base.VisitParameter(p);
        }
    }
}
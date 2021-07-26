using employeesWiki.Contracts;
using employeesWiki.Models;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;

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
    }
}
using employeesWiki.Models;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace employeesWiki.Shared
{
    public static class QueryExtensions
    {
        public static IQueryable<T> SortBy<T>(this IQueryable<T> query, PageParams pageParams) where T : BaseEntity
        {
            var orderQuery = query.OrderBy(x => 0);

            orderQuery = !String.IsNullOrEmpty(pageParams.OrderColumn)
                   ? orderQuery.ThenBy(($"{pageParams.OrderColumn} {pageParams.OrderDirection}"))
                   : orderQuery;

            return orderQuery;
        }

        public static IQueryable<T> Pagination<T>(this IQueryable<T> query, PageParams pageParams)
        {
            var skip = pageParams.PageNumber == 0 ? 1 : pageParams.PageNumber;
            var pageSize = pageParams.PageSize;
            skip = skip * pageSize;

            var result = query
                .Skip(skip - pageSize)
                .Take(pageSize);

            return result;
        }
    }
}
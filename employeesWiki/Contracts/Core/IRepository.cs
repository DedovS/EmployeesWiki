using employeesWiki.Models;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace employeesWiki.Contracts.Core
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);

        Task<T> CreateAsync(T entity);

        Task<bool> DeleteAsync(int id);

        Task<T> UpdateAsync(T entity);

        Task<(List<T> list, int rowCount)> GetListAsync(IPageParams pageParams,
                                    Expression<Func<T, bool>> predicate = null,
                                    bool disableTracking = true,
                                    Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
    }
}
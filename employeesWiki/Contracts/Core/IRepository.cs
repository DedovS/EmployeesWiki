using employeesWiki.Models;
using employeesWiki.Shared;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace employeesWiki.Contracts.Core
{
    public interface IRepository<T> where T: BaseEntity
    { 
        Task<T> GetByIdAsync(int id);
        Task<T> CreateAsync(T entity);
        Task<bool> DeleteAsync(int id);
        Task<T> UpdateAsync(T entity);
        Task<List<T>> GetListAsync(PageParams pageParams,
                                    bool disableTracking = true,
                                    Expression<Func<T, bool>> predicate = null,
                                    Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
    }
}

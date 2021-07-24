using employeesWiki.Contracts.Core;
using employeesWiki.Models;
using employeesWiki.Shared;
using employeesWiki.WikiDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace employeesWiki.Core
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected DbCtx _context;
        internal DbSet<T> _dbSet;
        public readonly ILogger _logger;

        public Repository(DbCtx context,
                          ILogger logger)
        {
            _context = context;
            _dbSet = context.Set<T>();
            _logger = logger;
        }

        public virtual async Task<T> CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public virtual async Task<bool> DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            _dbSet.Remove(entity);
            return true;
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<List<T>> GetListAsync(
            PageParams pageParams,
            bool disableTracking = true,
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            var entityQuery = _dbSet.AsQueryable();

            if (predicate != null)
            {
                entityQuery = entityQuery.Where(predicate);
            }

            if (disableTracking)
            {
                entityQuery = entityQuery.AsNoTracking();
            }

            entityQuery = entityQuery.Pagination(pageParams).SortBy(pageParams);
           
            if (include != null)
            {
                entityQuery = include(entityQuery); 
            }

            return await entityQuery.ToListAsync();
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            return entity;
        }
    }
}
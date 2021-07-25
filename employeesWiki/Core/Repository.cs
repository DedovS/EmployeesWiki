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
        private readonly DbCtx _context;
        private readonly DbSet<T> _dbSet;
        private readonly ILogger _logger;

        public Repository(DbCtx context,
                          ILogger logger)
        {
            _context = context;

            if (_context != null)
            {
                _dbSet = context.Set<T>();
            }
            _logger = logger;
        }

        public virtual async Task<T> CreateAsync(T entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Can't create new {typeof(T)} entity", ex);
                throw;
            }
        }

        public virtual async Task<bool> DeleteAsync(int id)
        {
            try
            {
                if (await _dbSet.AnyAsync(x => x.Id == id))
                {
                    var entity = await GetByIdAsync(id);
                    _dbSet.Remove(entity);
                    return true;
                }
                else
                {
                    _logger.LogError($"Can't find entity to delete with id: {id}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Can't delete {typeof(T)} entity with id: {id}", ex);
                throw;
            }
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public virtual async Task<List<T>> GetListAsync(
            PageParams pageParams,            
            Expression<Func<T, bool>> predicate = null,
            bool disableTracking = true,
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

            var entity = await entityQuery.ToListAsync();
            return entity;
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            try
            {
                if (await _dbSet.AnyAsync(x => x.Id == entity.Id))
                {
                    _dbSet.Update(entity);
                    return entity;
                }
                else
                {
                    _logger.LogError($"Can't find entity to update with id: {entity.Id}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Can't update {typeof(T)} entity with id:  {entity.Id}", ex);
                throw;
            }
        }
    }
}
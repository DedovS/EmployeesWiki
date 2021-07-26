using employeesWiki.Contracts.Core;
using employeesWiki.Contracts.Services;
using employeesWiki.DtoModels.WikiDto;
using employeesWiki.Models;
using employeesWiki.Shared;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace employeesWiki.Services
{
    public class WikiService : IWikiService
    {
        private readonly IUnitOfWork _unitOfWork;
        public readonly ILogger<WikiService> _logger;

        public WikiService(IUnitOfWork unitOfWork,
            ILogger<WikiService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<Wiki> CreateAsync(Wiki wiki)
        {
            try
            {
                wiki.Date = DateTime.Now;

                var newWiki = await _unitOfWork.WikiRepository.CreateAsync(wiki);
                await _unitOfWork.CompleteAsync();
                return newWiki;
            }
            catch (Exception ex)
            {
                _logger.LogError("Can't create new article", ex);
                throw new Exception("Can't create new article");
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
              return await _unitOfWork.WikiRepository.DeleteAsync(id);
               
            }
            catch (Exception ex)
            {
                _logger.LogError("Can't delete this article", ex);
                throw new Exception("Can't delete this article");
            }
        }

        public async Task<Wiki> GetByIdAsync(int id)
        {
            return await _unitOfWork.WikiRepository.GetByIdAsync(id);
        }

        public async Task<(List<Wiki> wikis, int totalCount)> GetListAsync(WikiPageParam pageParams)
        {
            Expression<Func<Wiki, bool>> predicate = null;

            if (pageParams.ArticleType.HasValue && pageParams.ArticleType.Value > 0)
            {
                predicate = x => x.ArticleType == pageParams.ArticleType;
            }

            if (pageParams.Date.HasValue)
            {
                predicate = x => x.Date.Year == pageParams.Date.Value.Year &&
                x.Date.Month == pageParams.Date.Value.Month &&
                x.Date.Day == pageParams.Date.Value.Day;
            }

            if (!string.IsNullOrEmpty(pageParams.Search))
            {
                predicate = x => x.Title.Contains(pageParams.Search) 
                || x.Description.Contains(pageParams.Search);
            }

            var pagnationWiki = await _unitOfWork.WikiRepository.GetListAsync(pageParams, predicate);
            return pagnationWiki;
        }

        public async Task<Wiki> UpdateAsync(Wiki wiki)
        {
            try
            {
                var updatedWiki = await _unitOfWork.WikiRepository.UpdateAsync(wiki);
                await _unitOfWork.CompleteAsync();
                return updatedWiki;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Can't update article with id: {wiki.Id}", ex);
                throw new Exception("Can't update this article");
            }
        }
    }
}
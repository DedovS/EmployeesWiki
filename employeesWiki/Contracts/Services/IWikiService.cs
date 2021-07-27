using employeesWiki.DtoModels.WikiDto;
using employeesWiki.Models;
using employeesWiki.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace employeesWiki.Contracts.Services
{
    public interface IWikiService
    {
        Task<Wiki> CreateAsync(Wiki wiki);

        Task<bool> DeleteAsync(int id);

        Task<Wiki> UpdateAsync(Wiki wiki);

        Task<(List<Wiki> wikis, int totalCount)> GetListAsync(WikiPageParam pageParams);

        Task<Wiki> GetByIdAsync(int id);
    }
}
using employeesWiki.Models;
using employeesWiki.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace employeesWiki.Contracts.Services
{
    public interface IWikiService
    {
        Task<Wiki> CreateAsync(Wiki wiki);

        Task<Wiki> DeleteAsync(int id);

        Task<Wiki> UpdateAsync(Wiki wiki);

        Task<List<Wiki>> GetListAsync(PageParams pageParams);

        Task<Wiki> GetByIdAsync(int id);
    }
}
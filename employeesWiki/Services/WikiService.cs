using employeesWiki.Contracts.Services;
using employeesWiki.Models;
using employeesWiki.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace employeesWiki.Services
{
    public class WikiService : IWikiService
    {
        public Task<Wiki> CreateAsync(Wiki wiki)
        {
            throw new NotImplementedException();
        }

        public Task<Wiki> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Wiki> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Wiki>> GetListAsync(PageParams pageParams)
        {
            throw new NotImplementedException();
        }

        public Task<Wiki> UpdateAsync(Wiki wiki)
        {
            throw new NotImplementedException();
        }
    }
}
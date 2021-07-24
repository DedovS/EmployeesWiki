using employeesWiki.Contracts.Repository;
using employeesWiki.Core;
using employeesWiki.Models;
using employeesWiki.WikiDbContext;
using Microsoft.Extensions.Logging;

namespace employeesWiki.Repository
{
    public class WikiRepository : Repository<Wiki>, IWikiRepository
    {
        public WikiRepository(DbCtx context, ILogger logger) : base(context, logger)
        {
        }
    }
}
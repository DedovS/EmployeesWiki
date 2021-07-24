using employeesWiki.Contracts.Core;
using employeesWiki.Contracts.Repository;
using employeesWiki.Repository;
using employeesWiki.WikiDbContext;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace employeesWiki.Core
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DbCtx _context;
        private readonly ILogger _logger;
        public IWikiRepository WikiRepository { get; private set; }

        public UnitOfWork(DbCtx context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");

            WikiRepository = new WikiRepository(context, _logger);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
using employeesWiki.Contracts.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace employeesWiki.Contracts.Core
{
    public interface IUnitOfWork
    {
        IWikiRepository WikiRepository { get; }
        Task CompleteAsync();
    }
}

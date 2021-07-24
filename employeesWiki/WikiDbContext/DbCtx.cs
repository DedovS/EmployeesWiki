using employeesWiki.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace employeesWiki.WikiDbContext
{
    public class DbCtx : DbContext
    {
        public DbCtx
        (DbContextOptions<DbCtx> dbContextOptions)
            : base(dbContextOptions)
        {

        }
        public DbSet<Wiki> Wiki { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}

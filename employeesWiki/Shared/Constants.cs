using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace employeesWiki.Shared
{
    public static class Constants
    { 
        public const string ConnectionStringConfigName = "ConnectionStrings:EmployeesWikiDbContext";
        public const string DefaultCorsPolicyName = "localhost";
        public const string CorsOriginsConfigName = "App:CorsOrigins";
    }
}

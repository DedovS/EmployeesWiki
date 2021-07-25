using employeesWiki.Shared;
using System;
using static employeesWiki.Shared.Enums;

namespace employeesWiki.DtoModels.WikiDto
{
    public class WikiPageParam : PageParams
    {
        public ArticleType? ArticleType { get; set; }
        public DateTime? Date { get; set; }
    }
}
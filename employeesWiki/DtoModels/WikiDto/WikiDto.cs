using System;
using static employeesWiki.Shared.Enums;

namespace employeesWiki.DtoModels.WikiDto
{
    public class WikiDto : DtoBaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public ArticleType ArticleType { get; set; }
    }
}
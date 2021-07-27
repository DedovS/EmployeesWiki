using System;
using static employeesWiki.Shared.Enums;

namespace employeesWiki.Models
{
    public class Wiki : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public ArticleType ArticleType { get; set; }
    }
}
using employeesWiki.Contracts;

namespace employeesWiki.Shared
{
    public class PageParams : IPageParams
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string OrderColumn { get; set; } = string.Empty;
        public string OrderDirection { get; set; } = string.Empty;
        public string Search { get; set; } = string.Empty;
    }
}
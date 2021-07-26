namespace employeesWiki.Contracts
{
    public interface IPageParams
    {
        int PageNumber { get; set; }
        int PageSize { get; set; }
        string OrderColumn { get; set; }
        string OrderDirection { get; set; }
    }
}
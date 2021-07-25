namespace employeesWiki.Contracts
{
    public interface IPageParam
    {
        int PageNumber { get; set; }
        int PageSize { get; set; }
        string OrderColumn { get; set; }
        string OrderDirection { get; set; }
    }
}
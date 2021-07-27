using System.Collections.Generic;

namespace employeesWiki.DtoModels
{
    public class DtoBaseEntity
    {
        public int Id { get; set; }
    } 
    public class DtoWithPagination<T> where T : DtoBaseEntity
    {
        public DtoWithPagination()
        {
            List = new List<T>();
        }
        public List<T> List { get; set; }
        public int TotalCount { get; set; }
    }
}
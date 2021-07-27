namespace employeesWiki.Shared
{
    public class Enums
    {
        public enum ArticleType
        {
            /// <summary>
            /// support issue resolving description for maintenance department
            /// </summary>
            SupportIssue = 1,

            /// <summary>
            /// technical issue resolving description for development department
            /// </summary>
            TehnicalIssue = 3,

            /// <summary>
            /// company article templates
            /// </summary>
            Template = 5
        }
    }
}
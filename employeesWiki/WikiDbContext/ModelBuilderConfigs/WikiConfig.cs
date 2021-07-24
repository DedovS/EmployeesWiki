using employeesWiki.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace employeesWiki.WikiDbContext.ModelBuilderConfigs
{
    public class WikiConfig : IEntityTypeConfiguration<Wiki>
    {
        public void Configure(EntityTypeBuilder<Wiki> builder)
        {
            builder.Property(x => x.ArticleType).IsRequired();
            builder.Property(x => x.Title).IsRequired().HasMaxLength(50);
        }
    }
}
using BlogPostsManagementSystem.GraphQL.BlogPostQL.Model;
using FluentNHibernate.Mapping;

namespace BlogPostsManagementSystem.DataAccess.SQLServer.Mapping
{
    public class BlogPostMap: ClassMap<BlogPost>
    {
        public BlogPostMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Title);
            References(x => x.AuthorId).Column("AuthorId");
            Table("BlogPost");
        }
    }
}
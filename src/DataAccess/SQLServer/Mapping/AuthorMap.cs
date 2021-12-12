using BlogPostsManagementSystem.GraphQL.AuthorQL.Model;
using FluentNHibernate.Mapping;

namespace BlogPostsManagementSystem.DataAccess.SQLServer.Mapping
{
    public class AuthorMap: ClassMap<Author>
    {
        public AuthorMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Table("Author");
        }
    }
}
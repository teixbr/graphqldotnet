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
            HasMany(x => x.BlogPostList)
                .Inverse()
                .Cascade.All();
            HasMany(x => x.CommentList)
                .Inverse()
                .Cascade.All();
            HasManyToMany(x => x.PrizeList)
                .Cascade.All()
                .Table("AuthorPrize")
                .ParentKeyColumn("AuthorId")
                .ChildKeyColumn("PrizeId");
            Table("Author");
        }
    }
}
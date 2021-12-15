using BlogPostsManagementSystem.GraphQL.BlogPostQL.Model;
using FluentNHibernate.Mapping;

namespace BlogPostsManagementSystem.DataAccess.SQLServer.Mapping
{
    public class CommentMap: ClassMap<Comment>
    {
        public CommentMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Text);
            References(x => x.AuthorId).Column("AuthorId");
            References(x => x.CommentId).Column("CommentId");
            References(x => x.BlogpostId).Column("BlogpostId");
            // Map(x => x.AuthorId);
            // Map(x => x.CommentId);
            // Map(x => x.BlogpostId);
            HasMany(x => x.CommentList)
                .Inverse()
                .Cascade.All();
            Table("Comment");
        }
    }
}
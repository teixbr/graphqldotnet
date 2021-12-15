using BlogPostsManagementSystem.GraphQL.AuthorQL.Repository;
using BlogPostsManagementSystem.GraphQL.BlogPostQL.Repository;
using HotChocolate.Types;

namespace BlogPostsManagementSystem.GraphQL.AuthorQL.Model
{
    public class AuthorType : ObjectType<Author>
    {
        protected override void Configure(IObjectTypeDescriptor<Author> descriptor)
        {
            descriptor.Field(a => a.Id).Type<IdType>();
            descriptor.Field(a => a.FirstName).Type<StringType>();
            descriptor.Field(a => a.LastName).Type<StringType>();
            descriptor.Field<BlogPostResolver>(b => 
                b.GetBlogPostsByAuthor(default, default));
            descriptor.Field<CommentResolver>(c => 
                c.GetCommentsByAuthor(default, default));
            descriptor.Field<PrizeResolver>(c => 
                c.GetPrizesByAuthor(default, default));
        }
    }
}
using BlogPostsManagementSystem.GraphQL.AuthorQL.Repository;
using BlogPostsManagementSystem.GraphQL.BlogPostQL.Repository;
using HotChocolate.Types;

namespace BlogPostsManagementSystem.GraphQL.BlogPostQL.Model
{
    public class CommentType : ObjectType<Comment>
    {
        protected override void Configure(IObjectTypeDescriptor<Comment> descriptor)
        {
            descriptor.Field(b => b.Id).Type<IdType>();
            descriptor.Field(b => b.Text).Type<StringType>();
            descriptor.Field<AuthorResolver>(t => t.GetAuthorByComment(default, default));
            descriptor.Field<CommentResolver>(t => t.GetCommentsByComment(default, default));
        }
    }
}
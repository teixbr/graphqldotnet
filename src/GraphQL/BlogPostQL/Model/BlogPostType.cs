using BlogPostsManagementSystem.GraphQL.AuthorQL.Repository;
using BlogPostsManagementSystem.GraphQL.BlogPostQL.Repository;
using HotChocolate.Types;

namespace BlogPostsManagementSystem.GraphQL.BlogPostQL.Model
{
    public class BlogPostType : ObjectType<BlogPost>
    {
        protected override void Configure(IObjectTypeDescriptor<BlogPost> descriptor)
        {
            descriptor.Field(b => b.Id).Type<IdType>();
            descriptor.Field(b => b.Title).Type<StringType>();
            descriptor.Field(b => b.AuthorId).Type<IntType>();
            descriptor.Field<AuthorResolver>(t => t.GetAuthor(default, default));
            descriptor.Field<CommentResolver>(c => 
                c.GetCommentsByBlogPost(default, default));
        }
    }
}
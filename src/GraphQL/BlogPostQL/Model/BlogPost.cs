using System.Collections.Generic;
using BlogPostsManagementSystem.GraphQL.AuthorQL.Model;
using HotChocolate;
using HotChocolate.Types;

namespace BlogPostsManagementSystem.GraphQL.BlogPostQL.Model
{
    public class BlogPost
    {
        [GraphQLType(typeof(NonNullType<IdType>))]
        public virtual int Id { get; set; }
        [GraphQLType(typeof(NonNullType<StringType>))]
        public virtual string Title { get; set; }
        [GraphQLNonNullType]
        public virtual Author AuthorId { get; set; }
        
        public virtual IList<Comment> CommentList { get; set; }

        public BlogPost()
        {
            CommentList = new List<Comment>();
        }
    }
}
using System.Collections.Generic;
using BlogPostsManagementSystem.GraphQL.AuthorQL.Model;
using HotChocolate;
using HotChocolate.Types;

namespace BlogPostsManagementSystem.GraphQL.BlogPostQL.Model
{
    public class Comment
    {
        [GraphQLType(typeof(NonNullType<IdType>))]
        public virtual int Id { get; set; }
        
        [GraphQLType(typeof(StringType))]
        public virtual string Text { get; set; }
        
        [GraphQLType(typeof(AuthorType))]
        public virtual Author AuthorId { get; set; }
        
        [GraphQLType(typeof(BlogPostType))]
        public virtual BlogPost BlogpostId { get; set; }
        
        [GraphQLType(typeof(CommentType))]
        public virtual Comment CommentId { get; set; }
        
        
        public virtual IList<Comment> CommentList { get; set; }

        public Comment()
        {
            CommentList = new List<Comment>();
        }
    }
}
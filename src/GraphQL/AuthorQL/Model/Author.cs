using System.Collections.Generic;
using BlogPostsManagementSystem.GraphQL.BlogPostQL.Model;
using HotChocolate;
using HotChocolate.Types;

namespace BlogPostsManagementSystem.GraphQL.AuthorQL.Model
{
    public class Author
    {
        [GraphQLType(typeof(NonNullType<IdType>))]
        public virtual int Id { get; set; }
        [GraphQLNonNullType]
        public virtual string FirstName { get; set; }
        [GraphQLNonNullType]
        public virtual string LastName { get; set; }
        // [GraphQLType(ListType<PrizeType>)]
        public virtual IList<Prize> PrizeList { get; set; }
        
        public virtual IList<BlogPost> BlogPostList { get; set; }
        
        public virtual IList<Comment> CommentList { get; set; }

        public Author()
        {
            BlogPostList = new List<BlogPost>();
            PrizeList = new List<Prize>();
            CommentList = new List<Comment>();
        }
    }
}
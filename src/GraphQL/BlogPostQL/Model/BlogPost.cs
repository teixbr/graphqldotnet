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
        public virtual int AuthorId { get; set; }
    }
}
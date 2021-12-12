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
    }
}
using System.Collections.Generic;
using HotChocolate;
using HotChocolate.Types;

namespace BlogPostsManagementSystem.GraphQL.AuthorQL.Model
{
    public class Prize
    {
        [GraphQLType(typeof(NonNullType<IdType>))]
        public virtual int Id { get; set; }
        [GraphQLNonNullType]
        public virtual string Name { get; set; }
        
        // [GraphQLType(typeof(ListType<AuthorType>))]
        public virtual IList<Author> AuthorList { get; set; }
        
        public Prize()
        {
            AuthorList = new List<Author>();
        }
    }
}
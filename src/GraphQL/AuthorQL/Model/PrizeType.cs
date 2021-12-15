using HotChocolate.Types;

namespace BlogPostsManagementSystem.GraphQL.AuthorQL.Model
{
    public class PrizeType : ObjectType<Prize>
    {
        protected override void Configure(IObjectTypeDescriptor<Prize> descriptor)
        {
            descriptor.Field(a => a.Id).Type<IdType>();
            descriptor.Field(a => a.Name).Type<StringType>();
        }
    }
}
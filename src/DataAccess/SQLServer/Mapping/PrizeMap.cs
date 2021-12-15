using BlogPostsManagementSystem.GraphQL.AuthorQL.Model;
using FluentNHibernate.Mapping;

namespace BlogPostsManagementSystem.DataAccess.SQLServer.Mapping
{
    public class PrizeMap: ClassMap<Prize>
    {
        public PrizeMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name);
            HasManyToMany(x => x.AuthorList)
                .Cascade.All()
                .Inverse()
                .Table("AuthorPrize")
                .ParentKeyColumn("PrizeId")
                .ChildKeyColumn("AuthorId");
            Table("Prize");
        }
    }
}
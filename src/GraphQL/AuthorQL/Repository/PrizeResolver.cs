using System.Collections.Generic;
using System.Linq;
using BlogPostsManagementSystem.GraphQL.AuthorQL.Model;
using HotChocolate;
using HotChocolate.Resolvers;

namespace BlogPostsManagementSystem.GraphQL.AuthorQL.Repository
{
    public class PrizeResolver
    {
        private readonly IPrizeRepository _prizeRepository;
        
        public PrizeResolver([Service] IPrizeRepository prizeService)
        {
            _prizeRepository = prizeService;
        }
        
        public IEnumerable<Prize> GetPrizesByAuthor([Parent] Author author, IResolverContext ctx)
        {
            return author.PrizeList;
        }
    }
}
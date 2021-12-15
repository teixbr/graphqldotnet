using System.Collections.Generic;
using BlogPostsManagementSystem.GraphQL.AuthorQL.Model;

namespace BlogPostsManagementSystem.GraphQL.AuthorQL.Repository
{
    public interface IPrizeRepository
    {
        public List<Prize> GetPrizes();
    }
}
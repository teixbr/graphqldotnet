using System;
using System.Collections.Generic;
using System.Linq;
using BlogPostsManagementSystem.GraphQL.AuthorQL.Model;
using BlogPostsManagementSystem.GraphQL.BlogPostQL.Model;
using HotChocolate;
using HotChocolate.Resolvers;

namespace BlogPostsManagementSystem.GraphQL.BlogPostQL.Repository
{
    public class BlogPostResolver
    {
        private readonly IBlogPostRepository _blogPostRepository;
        
        public BlogPostResolver([Service] IBlogPostRepository blogPostRepository)
        {
            _blogPostRepository = blogPostRepository;
        }
        
        public IEnumerable<BlogPost> GetBlogPosts([Parent] Author author, IResolverContext ctx)
        {
            if (ctx.ContextData.ContainsKey("Authorization"))
            {
                Console.WriteLine(ctx.ContextData["Authorization"]);
            }

            return _blogPostRepository.GetBlogPosts().Where(b => b.AuthorId == author.Id);
        }
    }
}
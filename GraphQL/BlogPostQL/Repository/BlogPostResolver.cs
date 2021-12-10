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
        
        public IEnumerable<BlogPost> GetBlogPosts(Author author, IResolverContext ctx)
        {
            return _blogPostRepository.GetBlogPosts().Where(b => b.AuthorId == author.Id);
        }
    }
}
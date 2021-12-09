using System.Collections.Generic;
using System.Threading.Tasks;
using BlogPostsManagementSystem.DataAccess;
using BlogPostsManagementSystem.GraphQL.BlogPostQL.Model;
using BlogPostsManagementSystem.GraphQL.BlogPostQL.Repository;
using HotChocolate;
using HotChocolate.Subscriptions;

namespace BlogPostsManagementSystem.GraphQL.BlogPostQL.Query
{
    public class BlogPostQuery
    {
        public async Task<List<BlogPost>> GetAllBlogPosts([Service] IBlogPostRepository blogPostRepository,
            [Service] ITopicEventSender eventSender)
        {
            List<BlogPost> blogPosts = blogPostRepository.GetBlogPosts();
            await eventSender.SendAsync("ReturnedBlogPosts", blogPosts);
            return blogPosts;
        }
        
        public async Task<BlogPost> GetBlogPostById([Service] IBlogPostRepository blogPostRepository,
            [Service] ITopicEventSender eventSender, int id)
        {
            BlogPost blogPost = blogPostRepository.GetBlogPostById(id);
            await eventSender.SendAsync("ReturnedBlogPost", blogPost);
            return blogPost;
        }
    }
}
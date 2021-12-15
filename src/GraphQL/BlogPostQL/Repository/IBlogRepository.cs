using System.Collections.Generic;
using BlogPostsManagementSystem.GraphQL.AuthorQL.Model;
using BlogPostsManagementSystem.GraphQL.BlogPostQL.Model;

namespace BlogPostsManagementSystem.GraphQL.BlogPostQL.Repository
{
    public interface IBlogPostRepository
    {
        public List<BlogPost> GetBlogPosts();
        public BlogPost GetBlogPostById(int id);
        public List<BlogPost> GetBlogPostsByAuthor(Author author);
    }
}
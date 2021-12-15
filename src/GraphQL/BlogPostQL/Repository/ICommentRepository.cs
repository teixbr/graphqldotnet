using System.Collections.Generic;
using BlogPostsManagementSystem.GraphQL.AuthorQL.Model;
using BlogPostsManagementSystem.GraphQL.BlogPostQL.Model;

namespace BlogPostsManagementSystem.GraphQL.BlogPostQL.Repository
{
    public interface ICommentRepository
    {
        List<Comment> GetCommentsByAuthor(Author author);
        List<Comment> GetCommentsByBlogPost(BlogPost blogPost);
        List<Comment> GetCommentsByComment(Comment comment);
        public Comment GetCommentById(int id);
    }
}
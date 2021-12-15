using System.Collections.Generic;
using System.Linq;
using BlogPostsManagementSystem.GraphQL.AuthorQL.Model;
using BlogPostsManagementSystem.GraphQL.BlogPostQL.Model;
using HotChocolate;
using HotChocolate.Resolvers;

namespace BlogPostsManagementSystem.GraphQL.BlogPostQL.Repository
{
    public class CommentResolver
    {
        private readonly ICommentRepository _commentRepository;
        
        public CommentResolver([Service] ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        
        public IEnumerable<Comment> GetCommentsByAuthor([Parent] Author author, IResolverContext ctx)
        {
            return _commentRepository.GetCommentsByAuthor(author);
            //return author.CommentList;
        }
        
        public IEnumerable<Comment> GetCommentsByComment([Parent] Comment comment, IResolverContext ctx)
        {
            return _commentRepository.GetCommentsByComment(comment);
            //return comment.CommentList;
        }
        
        public IEnumerable<Comment> GetCommentsByBlogPost([Parent] BlogPost blogpost, IResolverContext ctx)
        {
            return _commentRepository.GetCommentsByBlogPost(blogpost);
            //return blogpost.CommentList;
        }
    }
}
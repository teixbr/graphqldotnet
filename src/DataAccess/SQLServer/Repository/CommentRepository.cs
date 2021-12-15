using System;
using System.Collections.Generic;
using System.Linq;
using BlogPostsManagementSystem.GraphQL.AuthorQL.Model;
using BlogPostsManagementSystem.GraphQL.BlogPostQL.Model;
using BlogPostsManagementSystem.GraphQL.BlogPostQL.Repository;
using log4net;
using NHibernate;
using NHibernate.Criterion;

namespace BlogPostsManagementSystem.DataAccess.SQLServer.Repository
{
    public class CommentRepository: ICommentRepository
    {
        private ISession _daoHandler { get; set; }
        
        private static ILog _logger = LogManager.GetLogger(typeof(CommentRepository));

        public CommentRepository()
        {
            DaoHandler handler = new DaoHandler();
            _daoHandler = handler.GetSession();
        }
        
        public List<Comment> GetCommentsByAuthor( Author author )
        {
            _logger.Debug("IN - GetCommentsByAuthor()");

            List<Comment> answer = null;

            try
            {
                answer = (List<Comment>)_daoHandler.CreateCriteria<Comment>()
                                    .Add(Restrictions.Eq("AuthorId", author))
                                    .List<Comment>();
            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw;
            }

            _logger.Debug("OUT - GetCommentsByAuthor()");

            return answer;
        }

        public List<Comment> GetCommentsByBlogPost(BlogPost blogPost)
        {
            _logger.Debug("IN - GetCommentsByBlogPost()");

            List<Comment> answer = null;

            try
            {
                answer = (List<Comment>) _daoHandler.CreateCriteria<Comment>()
                    .Add(Restrictions.Eq("BlogPostId", blogPost))
                    .List<Comment>();
            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw;
            }

            _logger.Debug("OUT - GetCommentsByBlogPost()");

            return answer;
        }
        
        public List<Comment> GetCommentsByComment(Comment comment)
        {
            _logger.Debug("IN - GetCommentsByComment()");

            List<Comment> answer = null;

            try
            {
                answer = (List<Comment>) _daoHandler.CreateCriteria<Comment>()
                    .Add(Restrictions.Eq("CommentId", comment))
                    .List<Comment>();
            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw;
            }

            _logger.Debug("OUT - GetCommentsByComment()");

            return answer;
        }
        
        public Comment GetCommentById(int id)
        {
            _logger.Debug("IN - GetCommentById()");

            Comment answer = null;

            try
            {
                answer = _daoHandler.CreateCriteria<Comment>()
                    .Add(Restrictions.IdEq(id))
                    .List<Comment>().FirstOrDefault();
            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw;
            }

            _logger.Debug("OUT - GetCommentById()");

            return answer;
        }
    }
}
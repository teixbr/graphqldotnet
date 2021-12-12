using System;
using System.Collections.Generic;
using System.Linq;
using BlogPostsManagementSystem.GraphQL.BlogPostQL.Model;
using BlogPostsManagementSystem.GraphQL.BlogPostQL.Repository;
using log4net;
using Microsoft.EntityFrameworkCore;
using NHibernate;
using NHibernate.Criterion;

namespace BlogPostsManagementSystem.DataAccess.SQLServer.Repository
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private ISession _daoHandler { get; set; }
        private static ILog _logger = LogManager.GetLogger(typeof(AuthorRepository));

        public BlogPostRepository()
        {
            DaoHandler handler = new DaoHandler();
            _daoHandler = handler.GetSession();
        }
        
        public List<BlogPost> GetBlogPosts()
        {
            _logger.Debug("IN - GetBlogPosts()");

            List<BlogPost> answer = null;

            try
            {
                answer = _daoHandler.Query<BlogPost>()
                    .ToList();
            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw;
            }

            _logger.Debug("OUT - GetBlogPosts()");

            return answer;
        }
        public BlogPost GetBlogPostById(int id)
        {
            _logger.Debug("IN - GetBlogPostById()");

            BlogPost answer = null;

            try
            {
                answer = _daoHandler.CreateCriteria<BlogPost>()
                    .Add(Restrictions.IdEq(id))
                    .List<BlogPost>().FirstOrDefault();
            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw;
            }

            _logger.Debug("OUT - GetBlogPostById()");

            return answer;
        }
    }
}
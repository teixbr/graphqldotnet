using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogPostsManagementSystem.GraphQL.AuthorQL.Model;
using BlogPostsManagementSystem.GraphQL.AuthorQL.Repository;
using log4net;
using NHibernate;
using NHibernate.Criterion;

namespace BlogPostsManagementSystem.DataAccess.SQLServer.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private ISession _daoHandler { get; set; }
        private static ILog _logger = LogManager.GetLogger(typeof(AuthorRepository));

        public AuthorRepository()
        {
            DaoHandler handler = new DaoHandler();
            _daoHandler = handler.GetSession();
        }
        
        public List<Author> GetAuthors()
        {
            _logger.Debug("IN - GetAuthors()");

            List<Author> answer = null;

            try
            {
                answer = _daoHandler.Query<Author>().ToList();
            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw;
            }

            _logger.Debug("OUT - GetAuthors()");

            return answer;
        }
        
        public Author GetAuthorById(int id)
        {
            _logger.Debug("IN - GetAuthorById()");

            Author answer = null;

            try
            {
                answer = _daoHandler.CreateCriteria<Author>()
                    .Add(Restrictions.IdEq(id))
                    .List<Author>().FirstOrDefault();
            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw;
            }

            _logger.Debug("OUT - GetAuthorById()");

            return answer;
        }
        public async Task<Author> CreateAuthor(Author entity)
        {
            _logger.Debug("IN - CreateAuthor()");

            try
            { 
                _daoHandler.Save(entity);
            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw;
            }

            _logger.Debug("OUT - CreateAuthor()");

            return entity;
        }
    }
}
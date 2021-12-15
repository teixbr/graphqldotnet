using System;
using System.Collections.Generic;
using System.Linq;
using BlogPostsManagementSystem.GraphQL.AuthorQL.Model;
using BlogPostsManagementSystem.GraphQL.AuthorQL.Repository;
using log4net;
using NHibernate;
using NHibernate.Criterion;

namespace BlogPostsManagementSystem.DataAccess.SQLServer.Repository
{
    public class PrizeRepository: IPrizeRepository
    {
        private ISession _daoHandler { get; set; }
        private static ILog _logger = LogManager.GetLogger(typeof(PrizeRepository));

        public PrizeRepository()
        {
            DaoHandler handler = new DaoHandler();
            _daoHandler = handler.GetSession();
        }
        
        public List<Prize> GetPrizes()
        {
            _logger.Debug("IN - GetPrizes()");

            List<Prize> answer = null;

            try
            {
                answer = _daoHandler.Query<Prize>()
                    .ToList();
            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw;
            }

            _logger.Debug("OUT - GetPrizes()");

            return answer;
        }   
    }
}
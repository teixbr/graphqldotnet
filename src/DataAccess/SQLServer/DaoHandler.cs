using System;
using BlogPostsManagementSystem.Common.Utils;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using log4net;
using NHibernate;

namespace BlogPostsManagementSystem.DataAccess.SQLServer
{
    public class DaoHandler
    {
        static readonly object factorylock = new object();

        private static ISessionFactory _factory;

        private static ISession _session;

        private static ILog _logger = LogManager.GetLogger(typeof(DaoHandler));

        public DaoHandler()
        {
            _logger.Debug("IN - DaoHandler()");

            try
            {
                if (_session == null)
                {
                    _session = GetSession();
                }
            }
            catch (Exception e)
            {
                _logger.Error(e);
            }

            _logger.Debug("OUT - DaoHandler()");
        }

        public ISession GetSession()
        {
            _logger.Debug("IN - GetSession()");

            try
            {
                lock (factorylock)
                {
                    if (_factory == null)
                    {
                        var cfg = Fluently.Configure()
                            .Database(MsSqlConfiguration.MsSql2012.ConnectionString(ReadProperty.DB_CONNECTION))
                            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Program>());
                            // .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Program>())
                            // .Cache(x => x.Not.UseSecondLevelCache())
                            // .Cache(x => x.Not.UseQueryCache());

                            _factory = cfg.BuildSessionFactory();
                    }
                }

                _logger.Debug("OUT - GetSession()");

                return _factory.OpenSession();            
            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw;
            }
        }
    }
}
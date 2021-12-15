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
                        if (ReadProperty.DATABASE_ENGINE.Equals("PostgreSQL"))
                        {
                            _factory = Fluently.Configure()
                                .Database( PostgreSQLConfiguration.Standard.ConnectionString( 
                                    c=> c.Host( ReadProperty.POSTGRESQL_HOST )
                                        .Port( ReadProperty.POSTGRESQL_PORT )
                                        .Database( ReadProperty.POSTGRESQL_DATABASE )
                                        .Username( ReadProperty.POSTGRESQL_USER )
                                        .Password( ReadProperty.POSTGRESQL_PASSWORD ))
                                )
                                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Program>())
                                .BuildSessionFactory();
                        }
                        else
                        {
                            _factory = Fluently.Configure()
                                .Database(MsSqlConfiguration.MsSql2012.ConnectionString( ReadProperty.SQL_SERVER_STRING ))
                                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Program>())
                                .BuildSessionFactory();
                        }
                        
                            // .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Program>())
                            // .Cache(x => x.Not.UseSecondLevelCache())
                            // .Cache(x => x.Not.UseQueryCache());
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
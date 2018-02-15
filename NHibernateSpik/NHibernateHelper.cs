using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NHibernateSpik.EntityModeMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateSpik
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                    InitializeSessionFactory(); return _sessionFactory;
            }
        }

        private static void InitializeSessionFactory()
        {
            _sessionFactory = Fluently
                .Configure(CreateConfig())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Customer>())
                .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(true, true))
                .BuildConfiguration()
                .BuildSessionFactory();

        }

        private static Configuration CreateConfig()
        {
            Configuration cfg = new Configuration();

            return cfg.DataBaseIntegration(x =>
            {
                x.ConnectionString = @"data source=C:\temp\test4.db;
                        foreign keys=True;datetimeformat=ISO8601;page size=4096;cache size=100000;journal mode=Wal";
                x.Driver<NHibernate.Driver.CsharpSqliteDriver>();
                x.Dialect<NHibernate.Dialect.SQLiteDialect>();
                
            });
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}

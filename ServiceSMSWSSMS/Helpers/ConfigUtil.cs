using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using FluentNHibernate.Cfg;
using NHibernate.ByteCode.Castle;
using FluentNHibernate.Cfg.Db;
using ServiceSMS.Properties;
using SMSLibrary.Mapping;


namespace ServiceSMS.Helpers
{
    public class ConfigUtil
    {
        
        public static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .ProxyFactoryFactory<ProxyFactoryFactory>()
                .Database(MsSqlConfiguration.MsSql2008
                .ConnectionString(c => c
                .Server(Settings.Default.ServerDatabase)
                .Username(Settings.Default.UsernameDatabase)
                .Password(Settings.Default.PasswordDatabase)
                .Database(Settings.Default.Database)))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<LogSMSMap>())
                .ExposeConfiguration(c => c.SetProperty("current_session_context_class", "thread_static"))
                .BuildSessionFactory();
        }

    }
}

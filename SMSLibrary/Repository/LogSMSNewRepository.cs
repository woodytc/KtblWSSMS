using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMSLibrary.Domain;
using NHibernate;
using FluentNHibernate.Cfg;
using NHibernate.ByteCode.Castle;
using FluentNHibernate.Cfg.Db;
using NHibernate.Cfg;

namespace SMSLibrary.Repository
{
    public class LogSMSNewRepository : NhRepository, ILogSMSNewRepository
    {
        public LogSMSNewRepository()
        {

        }
             
        public LogSMSNewRepository(ISessionFactory sessionFactory)
        {
            SessionFactory = sessionFactory;    
        }
        public void Insert(LogSMSNew entity)
        {
            using (var session = SessionFactory.OpenStatelessSession())
            using (var ts = session.BeginTransaction())
            {
                try
                {
                    entity.Id = Guid.NewGuid();
                    session.Insert(entity);
                    ts.Commit();
                }
                catch (Exception ex)
                {
                    ts.Dispose();
                }
                //session.Close();
            }
        }

        public void Update(LogSMSNew entity)
        {
            using (var session = SessionFactory.OpenSession())
            using (var ts = session.BeginTransaction())
            {
                try
                {
                    session.Update(entity);
                    ts.Commit();
                }
                catch (Exception ex)
                {
                    ts.Dispose();
                }
            }
        }

        public void SaveOrUpdate(LogSMSNew entity)
        {
            using (var session = SessionFactory.OpenSession())
            using (var ts = session.BeginTransaction())
            {
                try
                {
                    session.SaveOrUpdate(entity);
                    ts.Commit();
                }
                catch (Exception ex)
                {
                    ts.Dispose();
                }
            }
        }

        public List<LogSMSNew> Get()
        {
            using (var session = SessionFactory.OpenStatelessSession())
            {
                var result = session.QueryOver<LogSMSNew>().List() as List<LogSMSNew>;
                return result;
            }
        }         
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMSLibrary.Domain;

namespace SMSLibrary.Repository
{
    public interface ILogSMSNewRepository
    {
         void Insert(LogSMSNew entity);
         void Update(LogSMSNew entity);
         void SaveOrUpdate(LogSMSNew entity);
         List<LogSMSNew> Get();
    }
}

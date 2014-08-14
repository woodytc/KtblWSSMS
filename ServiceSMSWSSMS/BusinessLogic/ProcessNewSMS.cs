using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using SMSLibrary.Domain;
using SMSLibrary.Repository;
using ServiceSMS.Contract;
using ServiceSMS.Helpers;

namespace ServiceSMS.BusinessLogic
{
    public class ProcessNewSMS
    {
        private ISessionFactory sessionFactory { get; set; }
        private LogSMSNew LogSMSNew { get; set; }
        public ILogSMSNewRepository LogSMSNewRepository { get; set; }

        public ProcessNewSMS()
        {
            
        }


        public bool InsetSMS(LogSMSNewData data, bool smsStatus, string requestdetail,string responseDetail)
        {
            this.LogSMSNewRepository = new LogSMSNewRepository(ConfigUtil.CreateSessionFactory());
            
            this.LogSMSNew = new LogSMSNew();
            this.LogSMSNew.Agrcode = data.Agrcode;
            this.LogSMSNew.Branchid = data.Branchid;
            this.LogSMSNew.Cuscode = data.Cuscode;
            this.LogSMSNew.Depcode = data.Depcode;
            this.LogSMSNew.Mobilenumber = data.Mobilenumber;
            this.LogSMSNew.Remark = data.Remark;
            this.LogSMSNew.Resultdetail = data.SMSDetail;
            this.LogSMSNew.Senddate = DateTime.Now;
            this.LogSMSNew.Senttime = DateTime.Now.ToString();
            this.LogSMSNew.Smid = data.Smid;
            this.LogSMSNew.Smsstatus = smsStatus;
            this.LogSMSNew.Typecode = data.Typecode;
            this.LogSMSNew.Updatedate = DateTime.Now;
            this.LogSMSNew.Userid = data.Userid;
            this.LogSMSNew.RequestDetail = requestdetail;
            this.LogSMSNew.RequestDetail = responseDetail;
            try
            {
                this.LogSMSNewRepository.Insert(this.LogSMSNew);
                return true;
            }
            catch (Exception ex)
            {

                ex.StackTrace.ToString();
                return false;
            }

            
        }
    }
}
using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using SMSLibrary.Domain; 

namespace SMSLibrary.Mapping {
    
    
    public class LogSMSNewMap : ClassMap<LogSMSNew> {
        
        public LogSMSNewMap() {
			Table("LogSmsNew");
			LazyLoad();
			Id(x => x.Id).GeneratedBy.Assigned().Column("Id");
			Map(x => x.Userid).Column("UserID");
			Map(x => x.Smid).Column("SMID");
			Map(x => x.Mobilenumber).Column("MobileNumber");
			Map(x => x.Branchid).Column("BranchId");
			Map(x => x.Typecode).Column("TypeCode");
			Map(x => x.Agrcode).Column("AGRCode");
			Map(x => x.Cuscode).Column("CUSCode");
			Map(x => x.Depcode).Column("DEPCode");
			Map(x => x.Smsstatus).Column("SMSStatus");
			Map(x => x.Senddate).Column("SendDate");
			Map(x => x.Senttime).Column("SentTime");
			Map(x => x.Resultdetail).Column("ResultDetail");
			Map(x => x.Remark).Column("Remark");
			Map(x => x.Updatedate).Column("UpdateDate");
            Map(x => x.SMSDetail).Column("SMSDetail");
            Map(x => x.RequestDetail).Column("RequestDetail");
            Map(x => x.ResponseDetail).Column("ResponseDetail");
            
        }
    }
}

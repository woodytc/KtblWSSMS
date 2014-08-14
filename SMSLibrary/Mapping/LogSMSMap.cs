using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using SMSLibrary.Domain; 

namespace SMSLibrary.Mapping {
    
    
    public class LogSMSMap : ClassMap<LogSMS> {
        
        public LogSMSMap() {
			Table("logsms");
			LazyLoad();
			CompositeId().KeyProperty(x => x.Userid, "userid")
			             .KeyProperty(x => x.Branchid, "branchid")
			             .KeyProperty(x => x.Seq, "seq")
			             .KeyProperty(x => x.Sdate, "sdate")
			             .KeyProperty(x => x.Typecode, "typecode");
			Map(x => x.Stime).Column("stime");
			Map(x => x.Remark).Column("remark");
			Map(x => x.Telsent).Column("telsent");
			Map(x => x.Agrcode).Column("agrcode");
			Map(x => x.Cuscode).Column("cuscode");
			Map(x => x.Depcode).Column("depcode");
        }
    }
}

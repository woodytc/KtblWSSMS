using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using SMSLibrary.Domain; 

namespace SMSLibrary.Mapping {
    
    
    public class LogAISMap : ClassMap<LogAIS> {
        
        public LogAISMap() {
			Table("LogAIS");
			LazyLoad();
			CompositeId().KeyProperty(x => x.Seq, "seq")
			             .KeyProperty(x => x.Mobilenumber, "Mobilenumber");
			Map(x => x.Smsstatus).Column("SMSStatus");
			Map(x => x.Resultdetail).Column("resultDetail");
			Map(x => x.Smid).Column("SMID");
			Map(x => x.Modifidate).Column("modifidate");
        }
    }
}

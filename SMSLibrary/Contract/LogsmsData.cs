using System; 
using System.Collections.Generic; 
using System.Text; 
using SMSLibrary.Domain;


namespace SMSLibrary.Domain {
    
    
    [DataContract(Name="LogsmsData" , Namespace="")]
    public class LogsmsData {
        
        [DataMember()]
        public virtual Int32 Id {
            get;
            set;
        }
        
        [DataMember()]
        public virtual String Id {
            get;
            set;
        }
        
        [DataMember()]
        public virtual Int32 Id {
            get;
            set;
        }
        
        [DataMember()]
        public virtual DateTime Id {
            get;
            set;
        }
        
        [DataMember()]
        public virtual String Stime {
            get;
            set;
        }
        
        [DataMember()]
        public virtual String Id {
            get;
            set;
        }
        
        [DataMember()]
        public virtual String Remark {
            get;
            set;
        }
        
        [DataMember()]
        public virtual String Telsent {
            get;
            set;
        }
        
        [DataMember()]
        public virtual String Agrcode {
            get;
            set;
        }
        
        [DataMember()]
        public virtual String Cuscode {
            get;
            set;
        }
        
        [DataMember()]
        public virtual String Depcode {
            get;
            set;
        }
    }
}

using System; 
using System.Collections.Generic; 
using System.Text; 
using SMSLibrary.Domain;


namespace SMSLibrary.Domain {
    
    
    [DataContract(Name="LogsmsnewData" , Namespace="")]
    public class LogsmsnewData {
        
        [DataMember()]
        public virtual Guid Id {
            get;
            set;
        }
        
        [DataMember()]
        public virtual Int32 Userid {
            get;
            set;
        }
        
        [DataMember()]
        public virtual String Smid {
            get;
            set;
        }
        
        [DataMember()]
        public virtual String Mobilenumber {
            get;
            set;
        }
        
        [DataMember()]
        public virtual String Branchid {
            get;
            set;
        }
        
        [DataMember()]
        public virtual String Typecode {
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
        
        [DataMember()]
        public virtual String Smsstatus {
            get;
            set;
        }
        
        [DataMember()]
        public virtual DateTime Senddate {
            get;
            set;
        }
        
        [DataMember()]
        public virtual String Senttime {
            get;
            set;
        }
        
        [DataMember()]
        public virtual String Resultdetail {
            get;
            set;
        }
        
        [DataMember()]
        public virtual String Remark {
            get;
            set;
        }
        
        [DataMember()]
        public virtual DateTime Updatedate {
            get;
            set;
        }
    }
}

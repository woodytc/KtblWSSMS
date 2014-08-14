using System; 
using System.Collections.Generic; 
using System.Text; 
using SMSLibrary.Domain;


namespace SMSLibrary.Domain {
    
    
    [DataContract(Name="LogaisData" , Namespace="")]
    public class LogaisData {
        
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
        public virtual String Smsstatus {
            get;
            set;
        }
        
        [DataMember()]
        public virtual String Resultdetail {
            get;
            set;
        }
        
        [DataMember()]
        public virtual String Smid {
            get;
            set;
        }
        
        [DataMember()]
        public virtual DateTime Modifidate {
            get;
            set;
        }
    }
}

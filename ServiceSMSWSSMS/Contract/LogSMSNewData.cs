using System; 
using System.Collections.Generic; 
using System.Text; 
using SMSLibrary.Domain;
using System.Runtime.Serialization;


namespace ServiceSMS.Contract{
    
    
    [DataContract]
    public class LogSMSNewData {
        
        [DataMember]
        public virtual Int32 Userid {
            get;
            set;
        }
        
        [DataMember]
        public virtual String Smid {
            get;
            set;
        }
        
        [DataMember]
        public virtual String Mobilenumber {
            get;
            set;
        }
        
        [DataMember]
        public virtual String Branchid {
            get;
            set;
        }
        
        [DataMember]
        public virtual String Typecode {
            get;
            set;
        }
        
        [DataMember]
        public virtual String Agrcode {
            get;
            set;
        }
        
        [DataMember]
        public virtual String Cuscode {
            get;
            set;
        }
        
        [DataMember]
        public virtual String Depcode {
            get;
            set;
        }
        
        [DataMember]
        public virtual String SMSDetail {
            get;
            set;
        }
        
        [DataMember]
        public virtual String Remark {
            get;
            set;
        }

        [DataMember]
        public virtual String Language
        {
            get;
            set;
        }
    }
}

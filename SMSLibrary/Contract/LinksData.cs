using System; 
using System.Collections.Generic; 
using System.Text; 
using SMSLibrary.Domain;


namespace SMSLibrary.Domain {
    
    
    [DataContract(Name="LinksData" , Namespace="")]
    public class LinksData {
        
        [DataMember()]
        public virtual Int32 Id {
            get;
            set;
        }
        
        [DataMember()]
        public virtual Int32 Source {
            get;
            set;
        }
        
        [DataMember()]
        public virtual Int32 Target {
            get;
            set;
        }
        
        [DataMember()]
        public virtual String Type {
            get;
            set;
        }
    }
}

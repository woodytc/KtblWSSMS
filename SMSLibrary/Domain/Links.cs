using System;
using System.Text;
using System.Collections.Generic;

namespace SMSLibrary.Domain {
    
    public class Links {
        public virtual int Id { get; set; }
        public virtual int Source { get; set; }
        public virtual int Target { get; set; }
        public virtual string Type { get; set; }
    }
}

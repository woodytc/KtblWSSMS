using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace ServiceSMS.Contract
{
    [DataContract]
    public class SMSResult
    {
        [DataMember]
        public bool IsCompleted { get; set; }

        [DataMember]
        public string Message { get; set; }
    }
}
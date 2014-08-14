using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ServiceSMS.Contract;

namespace ServiceSMS
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IWSSMS
    {
        [OperationContract]
        string PostSMS(string numbersent, string bodysent, string lang, string AGRCODE);

        [OperationContract]
        string DataDetail(string numbersent, string bodysent, string lang, string AGRCODE);

        [OperationContract]
        SMSResult SMSAISNew(LogSMSNewData entity);

        [OperationContract]
        string TestService(string str);

    }
}

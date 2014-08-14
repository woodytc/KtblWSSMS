using System;
using System.Text;
using System.Collections.Generic;
//using NHibernate.Validator.Constraints;


namespace SMSLibrary.Domain {
    
    public class LogSMSNew {
        //private System.Guid _id;
        public virtual string SMSDetail{ get; set;}
        //public virtual System.Guid Id
        //{
        //    get {
        //        return this._id;
        //    }
        //    set
        //    {
        //        this._id = Guid.NewGuid();
        //    }
        //}
        public virtual System.Guid Id { get; set; }
        public virtual int? Userid { get; set; }
        public virtual string Smid { get; set; }
        public virtual string Mobilenumber { get; set; }
        public virtual string Branchid { get; set; }
        public virtual string Typecode { get; set; }
        public virtual string Agrcode { get; set; }
        public virtual string Cuscode { get; set; }
        public virtual string Depcode { get; set; }
        public virtual bool Smsstatus { get; set; }
        public virtual DateTime Senddate { get; set; }
        public virtual string Senttime { get; set; }
        public virtual string Resultdetail { get; set; }
        public virtual string Remark { get; set; }
        public virtual DateTime Updatedate { get; set; }
        public virtual string RequestDetail { get; set; }
        public virtual string ResponseDetail { get; set; }
    }
}

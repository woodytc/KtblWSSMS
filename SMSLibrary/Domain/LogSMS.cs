using System;
using System.Text;
using System.Collections.Generic;
//using NHibernate.Validator.Constraints;


namespace SMSLibrary.Domain {
    
    public class LogSMS {
        public virtual int Userid { get; set; }
        public virtual string Branchid { get; set; }
        public virtual int Seq { get; set; }
        public virtual DateTime Sdate { get; set; }
        public virtual string Typecode { get; set; }
        public virtual string Stime { get; set; }
        public virtual string Remark { get; set; }
        public virtual string Telsent { get; set; }
        public virtual string Agrcode { get; set; }
        public virtual string Cuscode { get; set; }
        public virtual string Depcode { get; set; }
        #region NHibernate Composite Key Requirements
        public override bool Equals(object obj) {
			if (obj == null) return false;
			var t = obj as LogSMS;
			if (t == null) return false;
			if (Userid == t.Userid
			 && Branchid == t.Branchid
			 && Seq == t.Seq
			 && Sdate == t.Sdate
			 && Typecode == t.Typecode)
				return true;

			return false;
        }
        public override int GetHashCode() {
			int hash = GetType().GetHashCode();
			hash = (hash * 397) ^ Userid.GetHashCode();
			hash = (hash * 397) ^ Branchid.GetHashCode();
			hash = (hash * 397) ^ Seq.GetHashCode();
			hash = (hash * 397) ^ Sdate.GetHashCode();
			hash = (hash * 397) ^ Typecode.GetHashCode();

			return hash;
        }
        #endregion
    }
}

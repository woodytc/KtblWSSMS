using System;
using System.Text;
using System.Collections.Generic;
//using NHibernate.Validator.Constraints;


namespace SMSLibrary.Domain {
    
    public class LogAIS {
        public virtual int Seq { get; set; }
        public virtual string Mobilenumber { get; set; }
        public virtual string Smsstatus { get; set; }
        public virtual string Resultdetail { get; set; }
        public virtual string Smid { get; set; }
        public virtual DateTime? Modifidate { get; set; }
        #region NHibernate Composite Key Requirements
        public override bool Equals(object obj) {
			if (obj == null) return false;
			var t = obj as LogAIS;
			if (t == null) return false;
			if (Seq == t.Seq
			 && Mobilenumber == t.Mobilenumber)
				return true;

			return false;
        }
        public override int GetHashCode() {
			int hash = GetType().GetHashCode();
			hash = (hash * 397) ^ Seq.GetHashCode();
			hash = (hash * 397) ^ Mobilenumber.GetHashCode();

			return hash;
        }
        #endregion
    }
}

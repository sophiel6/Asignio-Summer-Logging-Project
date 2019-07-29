using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsignioInternship.Data.LogWebRequest
{

    [PetaPoco.TableName("logwebrequest")]
    [PetaPoco.PrimaryKey("UserID", autoIncrement = false)] 
    internal class LogWebRequestPoco
    {

        #region SQL

        internal static readonly string BaseSQL = @"
            SELECT
           * from logwebrequest";
        internal static readonly string SelectByIDSQL = BaseSQL + "" + " where UserID=@0;";
        internal static readonly string SelectAll = BaseSQL + " ORDER BY TimeStamp desc;";
        #endregion


        public DateTime TimeStamp { get; set; }
        public byte[] WebRequestID { get; set; }
        public byte[] UserID { get; set; }
       // public string HostAddress { get; set; }
        //public string ServerIP { get; set; }
        public string RawURL { get; set; }
        public string Parameters { get; set; }
        //public string UserAgent { get; set; }
        //public string UserLanguages { get; set; }
        public string Important { get; set; }
    }
}

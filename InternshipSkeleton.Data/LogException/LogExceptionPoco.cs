using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsignioInternship.Data.LogException
{

    [PetaPoco.TableName("logexception")]
    [PetaPoco.PrimaryKey("UserID", autoIncrement = false)] //is this what I should have as primary key? it said ExampleID before
    internal class LogExceptionPoco
    {
        #region SQL

        internal static readonly string BaseSQL = @"
            SELECT
           * from logexception";
        internal static readonly string SelectByIDSQL = BaseSQL + "" + " where UserID=@0;";
        //internal static readonly string SelectAll = BaseSQL + " ORDER BY TimeStamp desc;";
        internal static readonly string SelectAll = BaseSQL + " ORDER BY ";
        //internal static readonly string PageUsersByUserIDSearchSQL = BaseSQL + " where 
        #endregion


        public DateTime TimeStamp { get; set; }
        public byte[] WebRequestID { get; set; }
        public byte[] UserID { get; set; }
        public string Message { get; set; }
        public string MethodName { get; set; }
        public string Source { get; set; }
        public string StackTrace { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsignioInternship.Data.CombinedLogException
{
    /* may not need this file */

    //[PetaPoco.TableName("logexception")] //what's the correct table name here? 
    //[PetaPoco.PrimaryKey("UserID", autoIncrement = false)] //is this what I should have as primary key? it said ExampleID before
    internal class CombinedLogExceptionPoco
    {
        #region SQL
        /*
        internal static readonly string BaseSQL = @"
            SELECT
           * from logexception";
        internal static readonly string SelectByIDSQL = BaseSQL + "" + " where UserID=@0;";
        internal static readonly string SelectAll = BaseSQL + " ORDER BY TimeStamp desc";
        internal static readonly string PageUsersByUserIDSearchSQL = " where UserID=@0";
        */
        #endregion


        public string EmailAddress { get; set; }
        public DateTime TimeStamp { get; set; }
        public byte[] WebRequestID { get; set; }
        public byte[] UserID { get; set; }
        public string Message { get; set; }
        public string MethodName { get; set; }
        public string Source { get; set; }
        public string StackTrace { get; set; }

    }
}
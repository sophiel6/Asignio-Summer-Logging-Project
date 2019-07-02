using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsignioInternship.Data.Log
{

    [PetaPoco.TableName("log")]
    [PetaPoco.PrimaryKey("UserID", autoIncrement = false)] //is thC:\Users\Asignio Intern\Work\Asignio-Interns-Logging\InternshipSkeleton.Data\Log\LogPoco.csis what I should have as primary key? it said ExampleID before
    internal class LogPoco
    {

        #region SQL

        internal static readonly string BaseSQL = @"
            SELECT
           * from log";
        //uncommented ID part of string
        internal static readonly string SelectByIDSQL = BaseSQL + "" + " where UserID=@0;";
        internal static readonly string SelectAll = BaseSQL + " ORDER BY TimeStamp desc;";
        #endregion


        public DateTime TimeStamp { get; set; }
        public byte[] LogID { get; set; }
        public byte[] UserID { get; set; }
        public string Message { get; set; }
        public string Username { get; set; }
        public string Source { get; set; }
        public int Level { get; set; }
    }
}

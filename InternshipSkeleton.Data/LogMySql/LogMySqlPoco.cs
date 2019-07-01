using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsignioInternship.Data.LogMySql
{

    [PetaPoco.TableName("logmysql")]
   // [PetaPoco.PrimaryKey("Message", autoIncrement = false)] //is this what I should have as primary key? it said ExampleID before
    internal class LogMySqlPoco
    {

        #region SQL

        internal static readonly string BaseSQL = @"
            SELECT
           * from logmysql";
        internal static readonly string SelectByIDSQL = BaseSQL + ""; // + " where ExampleID=@0;";
        internal static readonly string SelectAll = BaseSQL + " ORDER BY TimeStamp desc;";
        #endregion


        public DateTime TimeStamp { get; set; }
        public string Message { get; set; }
        public string Function { get; set; }
        public int Type { get; set; }
    }
}

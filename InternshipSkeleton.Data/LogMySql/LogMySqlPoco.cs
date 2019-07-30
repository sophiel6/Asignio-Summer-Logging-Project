using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsignioInternship.Data.LogMySql
{

    [PetaPoco.TableName("logmysql")]
    [PetaPoco.PrimaryKey("DateTimeStamp", autoIncrement = false)] 
    internal class LogMySqlPoco
    {

        #region SQL

        internal static readonly string BaseSQL = @"SELECT * from logmysql";
        internal static readonly string SelectByIDSQL = BaseSQL + ""; // + " where ExampleID=@0;";
        internal static readonly string SelectAll = BaseSQL + " ORDER BY DateTimeStamp desc;";
        #endregion


        public DateTime DateTimeStamp { get; set; }
        public string Message { get; set; }
        public string Function { get; set; }
        public int Type { get; set; }
        public string Important { get; set; }
    }
}

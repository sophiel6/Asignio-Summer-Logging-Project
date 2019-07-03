﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsignioInternship.Data.LogControllerAction
{

    [PetaPoco.TableName("logcontrolleraction")]
    [PetaPoco.PrimaryKey("UserID", autoIncrement = false)] //is this what I should have as primary key? it said ExampleID before
    internal class LogControllerActionPoco
    {

        #region SQL

        internal static readonly string BaseSQL = @"
            SELECT
           * from logcontrolleraction";
        internal static readonly string SelectByIDSQL = BaseSQL + "" + " where UserID=@0;";
        internal static readonly string SelectAll = BaseSQL + " ORDER BY TimeStamp desc;";
        #endregion


        public DateTime TimeStamp { get; set; }
        public byte[] WebRequestID { get; set; }
        public byte[] UserID { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string Parameters { get; set; }
    }
}

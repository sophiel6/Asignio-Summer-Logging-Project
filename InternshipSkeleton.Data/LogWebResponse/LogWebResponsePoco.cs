﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsignioInternship.Data.LogWebResponse
{

    [PetaPoco.TableName("logwebresponse")]
    [PetaPoco.PrimaryKey("UserID", autoIncrement = false)] //is this what I should have as primary key? it said ExampleID before
    internal class LogWebResponsePoco
    {

        #region SQL

        internal static readonly string BaseSQL = @"
            SELECT
           * from logwebresponse";
        internal static readonly string SelectByIDSQL = BaseSQL + "" + " where UserID=@0;";
        internal static readonly string SelectAll = BaseSQL + " ORDER BY TimeStamp desc;";
        #endregion


        public DateTime TimeStamp { get; set; }
        public byte[] WebRequestID { get; set; }
        public byte[] UserID { get; set; }
        public string Status { get; set; }
        public int StatusCode { get; set; }
        public string StatusDescription { get; set; }
        public string RedirectLocation { get; set; }
    }
}

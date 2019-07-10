using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsignioInternship.Data.User
{

    [PetaPoco.TableName("user")]
    [PetaPoco.PrimaryKey("UserID", autoIncrement = false)] //is this what I should have as primary key? 
    internal class UserPoco
    {
        #region SQL

        internal static readonly string BaseSQL = @"
            SELECT
           * from user";
        //internal static readonly string SelectByIDSQL = BaseSQL + "" + " where UserID=@0;";
        internal static readonly string SelectAll = BaseSQL;
        //internal static readonly string PageUsersByUserIDSearchSQL = " where UserID=@0";
        #endregion


        public string EmailAddress { get; set; }
        public byte[] UserID { get; set; }

    }
}

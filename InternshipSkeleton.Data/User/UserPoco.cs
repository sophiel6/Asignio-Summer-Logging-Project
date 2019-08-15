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
        public string EmailAddress { get; set; }
        public byte[] UserID { get; set; }

    }
}

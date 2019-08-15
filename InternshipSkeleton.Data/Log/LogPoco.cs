using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsignioInternship.Data.Log
{
    [PetaPoco.TableName("log")]
    [PetaPoco.PrimaryKey("UserID", autoIncrement = false)] //is this what I should have as primary key?
    internal class LogPoco
    {
        public DateTime TimeStamp { get; set; }
        public byte[] LogID { get; set; }
        public byte[] UserID { get; set; }
        public string Message { get; set; }
        public string Username { get; set; }
        public string Source { get; set; }
        public int Level { get; set; }
    }
}

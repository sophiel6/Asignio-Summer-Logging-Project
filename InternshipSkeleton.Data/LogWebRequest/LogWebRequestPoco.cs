using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsignioInternship.Data.LogWebRequest
{
    [PetaPoco.TableName("logwebrequest")]
    [PetaPoco.PrimaryKey("UserID", autoIncrement = false)] 
    internal class LogWebRequestPoco
    {
        public DateTime TimeStamp { get; set; }
        public byte[] WebRequestID { get; set; }
        public byte[] UserID { get; set; }
        public string RawURL { get; set; }
        public string Parameters { get; set; }
        public string Important { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsignioInternship.Data.LogControllerAction
{
    [PetaPoco.TableName("logcontrolleraction")]
    [PetaPoco.PrimaryKey("UserID", autoIncrement = false)]
    internal class LogControllerActionPoco
    {
        public DateTime TimeStamp { get; set; }
        public byte[] WebRequestID { get; set; }
        public byte[] UserID { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string Parameters { get; set; }
    }
}

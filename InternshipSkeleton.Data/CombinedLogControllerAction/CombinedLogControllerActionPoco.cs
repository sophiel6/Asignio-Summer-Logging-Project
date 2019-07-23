using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsignioInternship.Data.CombinedLogControllerAction
{
    internal class CombinedLogControllerActionPoco
    {
        public string EmailAddress { get; set; }
        public DateTime TimeStamp { get; set; }
        public byte[] WebRequestID { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string Parameters { get; set; }
        public byte[] UserID { get; set; }
        public string Important { get; set; }
    }
}
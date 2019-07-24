using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsignioInternship.Data.LogWebRequest
{
    public class LogWebRequestDataModel
    {
        public DateTime TimeStamp { get; set; }
        public Guid WebRequestID { get; set; }
        public Guid UserID { get; set; }
        public string HostAddress { get; set; }
        public string ServerIP { get; set; }
        public string RawURL { get; set; }
        public string Parameters { get; set; }
        public string UserAgent { get; set; }
        public string UserLanguages { get; set; }
        public string Important { get; set; }

    }
}
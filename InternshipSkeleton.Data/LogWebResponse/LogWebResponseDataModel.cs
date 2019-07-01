using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsignioInternship.Data.LogWebResponse
{
    public class LogWebResponseDataModel
    {
        public DateTime TimeStamp { get; set; }
        public Guid WebRequestID { get; set; }
        public Guid UserID { get; set; }
        public string Status { get; set; }
        public int StatusCode { get; set; }
        public string StatusDescription { get; set; }
        public string RedirectLocation { get; set; }

    }
}
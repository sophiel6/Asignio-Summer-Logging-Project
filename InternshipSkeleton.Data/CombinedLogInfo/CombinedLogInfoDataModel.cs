using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsignioInternship.Data.CombinedLogInfo
{
    public class CombinedLogInfoDataModel
    {
        public string EmailAddress { get; set; }
        public DateTime TimeStamp { get; set; }
        public Guid WebRequestID { get; set; }
        public string Message { get; set; }
        public string MethodName { get; set; }
        public string Object { get; set; }
    }
}

